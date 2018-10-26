using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _021item_addnew : System.Web.UI.Page
    {

        DataTable CategoryTable { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //CsProvince ProvinceList = new CsProvincelist(ProvinceTable);
                CsItemCat ItemCat = new CsItemCat(CategoryTable);

                try
                {
                    ConnectionClass.GetItemCat(ItemCat);
                    CategoryList.DataSource = ItemCat.itemCategory;
                    CategoryList.DataTextField = ItemCat.itemCategory.Columns["categoryName"].ToString();
                    CategoryList.DataValueField = ItemCat.itemCategory.Columns["categoryCode"].ToString();
                    CategoryList.DataBind();
                   
                }
                finally
                {

                }

                for (int i = 0; i <= 100; i++)
                {
                    qtyList.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }


            }
        }

        const int maxImageSize = 307200;


        // BLOB 에 이미지 업로드 
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var blobName = imageUpload.FileName;

            // 300k보다 작고 이미지라면
            if (imageUpload.PostedFile.ContentLength < maxImageSize &&
                (imageUpload.PostedFile.ContentType == "image/x-png" ||
                imageUpload.PostedFile.ContentType == "image/pjpeg" ||
                imageUpload.PostedFile.ContentType == "image/jpeg" ||
                imageUpload.PostedFile.ContentType == "image/bmp" ||
                imageUpload.PostedFile.ContentType == "image/png" ||
                imageUpload.PostedFile.ContentType == "image/gif")
                ) {

                // azure 에 업로드 한다면 (=appsetting 이 true 라면)
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["useazureblob"].ToString()))
                {
                    // azure 에 업로드하기 위한 정보 (액세스키 + 컨테이너 네임)
                    string accesskey = ConfigurationManager.AppSettings["azurekey"].ToString();
                    string containerName = "dodamimg".ToLower();


                    // 컨테이너가 없으면 생성
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(accesskey);

                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container = blobClient.GetContainerReference(containerName);

                    container.CreateIfNotExists();

                    container.SetPermissions(
                        new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });


                    // 업로드 (드디어..)

                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

                    blockBlob.Properties.ContentType = imageUpload.PostedFile.ContentType;
                    blockBlob.UploadFromStream(imageUpload.FileContent);

                    this.testimg.ImageUrl = $"https://dodamblob.blob.core.windows.net/dodamimg/{blobName}";
                    //this.

                    this.imgurl.Text= $"https://dodamblob.blob.core.windows.net/dodamimg/{blobName}";
                }

                //local 에 업로드 (appsetting 이 false)
                else
                {

                }
            }

            // 사이즈 OK, 파일타입이 이미지가 아니면
            else if(imageUpload.PostedFile.ContentLength < maxImageSize &&
                (imageUpload.PostedFile.ContentType != "image/x-png" ||
                imageUpload.PostedFile.ContentType != "image/pjpeg" ||
                imageUpload.PostedFile.ContentType != "image/jpeg" ||
                imageUpload.PostedFile.ContentType != "image/bmp" ||
                imageUpload.PostedFile.ContentType != "image/png" ||
                imageUpload.PostedFile.ContentType != "image/gif"))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please upload image ');</script>");
            }

            else if(imageUpload.PostedFile.ContentLength >= maxImageSize &&
                (imageUpload.PostedFile.ContentType == "image/x-png" ||
                imageUpload.PostedFile.ContentType == "image/pjpeg" ||
                imageUpload.PostedFile.ContentType == "image/jpeg" ||
                imageUpload.PostedFile.ContentType == "image/bmp" ||
                imageUpload.PostedFile.ContentType == "image/png" ||
                imageUpload.PostedFile.ContentType == "image/gif"))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please upload image less than 300k ');</script>");
            }

            else
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please upload appropriate file ');</script>");

            }
        }

        string itemnum { get; set; }
        string itemcat { get; set; }
        string itemname { get; set; }
        string itemqty { get; set; }

        string itempprice { get; set; }
        string itemrprice { get; set; }

        string itemimg { get; set; }
       
        string itemnote { get; set; }
        string itemdate { get; set; }


        //DB에 업로드 (이미지 URL)
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //itemcat = CategoryList.SelectedValue.ToString();
            itemcat = CategoryList.SelectedItem.Text;
            itemname = iNameBox.Text;

            itemqty = qtyList.SelectedValue.ToString();

            itempprice = pPriceBox.Text;
            itemrprice = rPriceBox.Text;

            itemnote = notebox.Text;

            itemimg = imgurl.Text;
          

            CsItem nitem = new CsItem(itemnum, itemcat, itemname, itempprice, itemrprice, itemnote, itemimg, itemqty,itemdate);

            try
            {
                ConnectionClass.RegisterItem(nitem);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('New Item Registered!');</script>");
                ClearTextBoxes(Page);
                CategoryList.ClearSelection();
                testimg.ImageUrl = "";
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Error!');</script>");
            }
        }




        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    if (t != null)
                    {t.Text = String.Empty;}
                }

                else if (ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {d.ClearSelection();}
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {ClearTextBoxes(ctrl);}
                }
            }
        }





    }
}