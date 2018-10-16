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
                //Add New Item 버튼 색상변화
                BtnAddNewItem.Attributes.Add("onmouseover", "this.style.backgroundColor='#c1eec8'");
                BtnAddNewItem.Attributes.Add("onmouseout", "this.style.backgroundColor='#f3e6f4'");

                // 검색필터
                List<string> searchKeywords = new List<string>();
                searchKeywords.Add("Name");
                searchKeywords.Add("Note");

                searchKeyWordList.DataSource = searchKeywords;
                searchKeyWordList.DataBind();



                // Display 아이템리스트 게시판 
                ItemListView();
            }
        }

        // Add 버튼 클릭시 아이템 등록창 open
        protected void BtnAddNewItem_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.Page.GetType(), "",
"window.open('021item_addnew.aspx','window','toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=0,height=350,width=700,left=130,top=220');", true);
        }

        // 리스트의 item 이름 클릭시 detail 창 open

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





        // 전체 아이템 리스트 보는 메소드
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
                testlabel.Text = "error";
            }

            finally
            {

            }
        }



        protected void OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (itemListBoard.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //ItemListView();
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

        // 검색버튼 (SEARCH)눌렀을때 
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(searchKeyWordList.SelectedValue) == "Name")
            {
                SearchByName();
            }

            //노트내용으로 검색시
            else if (Convert.ToString(searchKeyWordList.SelectedValue) == "Note")
            {
                SearchByNote();
            }

            // 그외 ( 필터가 선택되지 않았거나 검색창 비어있을때 )
            else
            {
                ItemListView();
            }
        }

        // 검색메소드
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
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
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
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('error');</script>");
            }

            finally
            {

            }
        }

    }
 }
