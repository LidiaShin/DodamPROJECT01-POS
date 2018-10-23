using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _003customer : System.Web.UI.Page
    {

        //DataTable CustomerTable { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                // 최초 접속시
            {
                BtnAddnew.Attributes.Add("onmouseover", "this.style.backgroundColor='#c1eec8'");
                BtnAddnew.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3e6f4'");


                List<string> searchKeywords = new List<string>();
                searchKeywords.Add("Name");
                searchKeywords.Add("E-mail");

                searchKeyWordList.DataSource = searchKeywords;
                searchKeyWordList.DataBind();

                CustomerListView();
            }
            else
            {
                //CustomerListView();
            }
        }


        public void CustomerListView()
        {
            CsCustomerlist customerlists = new CsCustomerlist(CustomerTable);

            try
            {
                ConnectionClass.GetCustomerList(customerlists);

                cListBoard.DataSource = customerlists.customerList;
                
                cListBoard.DataBind();
            }

            catch
            {
                testlabel.Text = "fail";
            }

            finally
            {

            }
        }

        DataTable CustomerTable { get; set; }
        string nameKeyword { get; set; }
        string emailKeyword { get; set; }

        public void SearchListView()
        {

            nameKeyword = keywordbox.Text;
            CsFilteredCustomerList nfcustomerlist = new CsFilteredCustomerList(nameKeyword, emailKeyword, CustomerTable);

            try
            {
                ConnectionClass.SearchCustomerByName(nfcustomerlist);

                cListBoard.DataSource = nfcustomerlist.fCustomerList;
                
                cListBoard.DataBind();

                //keywordbox.Text = string.Empty;
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
            }

            finally
            {
               
            }
        }

        public void SearchListViewByEmail()
        {

            emailKeyword = keywordbox.Text;
            CsFilteredCustomerList nfcustomerlist = new CsFilteredCustomerList(nameKeyword, emailKeyword, CustomerTable);

            try
            {
                ConnectionClass.SearchCustomerByEmail(nfcustomerlist);

                cListBoard.DataSource = nfcustomerlist.fCustomerList;

                cListBoard.DataBind();

                //keywordbox.Text = string.Empty;
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
            }

            finally
            {

            }
        }



        // 검색버튼 눌렀을때
        protected void Button1_Click(object sender, EventArgs e)
        {
            // 이름으로 검색시
            if (Convert.ToString(searchKeyWordList.SelectedValue) == "Name")
            {
                SearchListView();
            }

            //이메일로 검색시
            else if (Convert.ToString(searchKeyWordList.SelectedValue) == "E-mail")
            {
                SearchListViewByEmail();
            }

            else
            {
                CustomerListView();
            }
            
        }

        
        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (cListBoard.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //if (hdnText.Value != "")
            //{
            //    string yourValue = hdnText.Value.ToString();
            //    if (yourValue == "Ddddddd")

            //    {
            //        //CustomerListView();
            //        SearchListView();
            //    }
            //    else
            //    {
            //        //this.CustomerListView();
            //        SearchListView();
            //    }
            //}
            //else
            //{
            //this.CustomerListView();

            //}

            if (Convert.ToString(searchKeyWordList.SelectedValue) == "Name")
            {
                SearchListView();
            }

            else if (Convert.ToString(searchKeyWordList.SelectedValue) == "E-mail")
            {
                SearchListViewByEmail();
            }

            else
            {
                CustomerListView();
            }
        }
        protected void BtnAddnew_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "",
  "window.open('031customer_addnew.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
        }

        /*protected void cListBoard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
        //int cNum { get; set; }
        protected void SeeDetail(object sender, EventArgs e)
        {
            try
            {
               // Response.Write("<script language=javascript>alert('test ')</script>");

                LinkButton lbtn = (LinkButton)(sender);
               

                Session["customerNum"] = Convert.ToString(lbtn.CommandArgument);

                ClientScript.RegisterStartupScript(this.Page.GetType(), "",
   "window.open('032customer_seedetail.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
            }

            finally
            {

            }
        }

      
    }
}