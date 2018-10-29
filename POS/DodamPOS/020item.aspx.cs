using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _002item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                // SEARCH DDL
                List<string> searchKeywords = new List<string>();
                searchKeywords.Add("Name");
                searchKeywords.Add("Note");

                searchKeyWordList.DataSource = searchKeywords;
                searchKeyWordList.DataBind();



                // DISPLAY WHOLE ITEM LIST
                ItemListView();
            }
        }

        // PRESS ADD NEW ITEM
        protected void BtnAddNewItem_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "",
"window.open('021item_addnew.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
        }

        // CLICK ITEM NAME TO SEE DETAIL

        protected void SeeItemDetail(object sender, EventArgs e)
        {
            try
            {
                // Response.Write("<script language=javascript>alert('test ')</script>");

                LinkButton lbtn = (LinkButton)(sender);

                // 아이템 number를 세션으로 넘겨줌 
                Session["itemNum"] = Convert.ToString(lbtn.CommandArgument);

                ClientScript.RegisterStartupScript(this.Page.GetType(), "",
   "window.open('022item_seedetail.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
            }

            finally
            {

            }
        }





        // SEE WHOLE ITEM LIST METHOD
        DataTable itemTable { get; set; }
        public void ItemListView()
        {
            CsItemlist itemlist = new CsItemlist(itemTable);

            try
            {
                ConnectionClass.GetItemList(itemlist);
                itemListBoard.DataSource = itemlist.itemList;
                itemListBoard.DataBind();
            }
            catch
            {
                testlabel.Text = "Error Occured, Please try reloading page. Sorry for inconvenience";
            }

            finally
            {

            }
        }



        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (itemListBoard.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

           

            if (Convert.ToString(searchKeyWordList.SelectedValue) == "Name")
            {
                SearchByName();
            }

            else if (Convert.ToString(searchKeyWordList.SelectedValue) == "Note")
            {
                SearchByNote();
            }

            else
            {
                ItemListView();
            }
            
            
        }

        // PRESS SEACH BUTTON
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            // SEARCH BY NAME

            if (Convert.ToString(searchKeyWordList.SelectedValue) == "Name")
            {
                SearchByName();
            }

            // SEARCH BY NOTE
            else if (Convert.ToString(searchKeyWordList.SelectedValue) == "Note")
            {
                SearchByNote();
            }

            // DDL IS NOT SELECTED
            else
            {
                ItemListView();
            }
        }

        // SEARCH KEYWORD
        string kItemName { get; set; }
        string kItemNote { get; set; }
        public void SearchByName()
        {

            kItemName = keywordbox.Text;

            CsFilteredItemList filist = new CsFilteredItemList(kItemName, kItemNote, itemTable);

            try
            {
                ConnectionClass.SearchItemByName(filist);

                itemListBoard.DataSource = filist.fiTable;

                itemListBoard.DataBind();

                //keywordbox.Text = string.Empty;
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Sorry, Connection is not stable. Please try again');</script>");
            }

            finally
            {

            }
        }


        public void SearchByNote()
        {

            kItemNote = keywordbox.Text;

            CsFilteredItemList filist = new CsFilteredItemList(kItemName, kItemNote, itemTable);

            try
            {
                ConnectionClass.SearchItemByNote(filist);

                itemListBoard.DataSource = filist.fiTable;

                itemListBoard.DataBind();

                //keywordbox.Text = string.Empty;
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Sorry, Connection is not stable. Please try again');</script>");
            }

            finally
            {

            }
        }

    }
 }
