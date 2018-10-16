using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _001pos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemView();
            }
        }


        
        DataTable itemTable { get; set; }
        public void ItemView()
        {
            CsItemlist itemlist = new CsItemlist(itemTable);

            try
            {
                ConnectionClass.GetItemList(itemlist);

                itemLists.DataSource = itemlist.itemList;
                itemLists.DataBind();

              
                //itemList.DataSource = itemlist.itemList;
                //itemList.DataBind();
            }
            catch
            {
                testlabel.Text = "error";
            }

            finally
            {

            }
        }
    }
}