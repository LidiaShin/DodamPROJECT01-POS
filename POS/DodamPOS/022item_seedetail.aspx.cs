using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DodamPOS
{
    public partial class _022item_seedetail : System.Web.UI.Page
    {
        
        // CsItem
        public string iID { get; set; }
        public string iCategory { get; set; }
        public string iName { get; set; }
        public string iPPrice { get; set; }
        public string iRPrice { get; set; }
        public string iNote { get; set; }
        public string iImage { get; set; }
        public string iQuantity { get; set; }
        public string iRday { get; set; }

        // item Category Dropdownlist datasource
        DataTable CategoryTable { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["itemNum"] != null && !IsPostBack)
            {
                inumlbl.Text = Session["itemNum"].ToString();

                // update 이전: 텍스트박스+ 드롭다운리스트 disabled, 업로드버튼 invisible
                btnUpload.Visible = false;
                DisableTextBoxes(Page);

                iID = inumlbl.Text;
               

                try
                {
                    CsItem theitem = new CsItem(iID, iCategory, iName, iPPrice, iRPrice, iNote, iImage, iQuantity, iRday);

                    ConnectionClass.GetItemDetail(theitem);

                    CategoryList.SelectedItem.Text = theitem.itemCategory;
                    iNameBox.Text = theitem.itemName;
                    qtyList.SelectedItem.Text = theitem.itemQuantity;
                    notebox.Text = theitem.itemNote;

                    pPriceBox.Text = theitem.itemPPrice;
                    rPriceBox.Text = theitem.itemRPrice;
                    testimg.ImageUrl = theitem.itemImage;
                    imgURL.Text = theitem.itemImage;

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

        // Press UpdateButton
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Enable to use textbox, dropdownlist, enable to see upload control 
            AbleTextBoxes(Page);

            //Enable to see upload button
            btnUpload.Visible = true;

            // Input qty list numbers
            for (int i = 1; i <= 100; i++)
            {
                qtyList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

           // Input category list items
            //CategoryList.SelectedItem.Text = "Please Select";
            CsItemCat Itemcats = new CsItemCat(CategoryTable);
            ConnectionClass.GetItemCat(Itemcats);

            CategoryList.DataSource = Itemcats.itemCategory;
            CategoryList.DataTextField = Itemcats.itemCategory.Columns["categoryName"].ToString();
            CategoryList.DataValueField = Itemcats.itemCategory.Columns["categoryName"].ToString();
            CategoryList.DataBind();

            btnUpdate.Visible = false;
            btnSave.Visible = true;
           
        }

        const int maxImageSize = 307200;
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
                )
            {

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

                    this.imgURL.Text = $"https://dodamblob.blob.core.windows.net/dodamimg/{blobName}";
                }

                //local 에 업로드 (appsetting 이 false)
                else
                {

                }
            }

            // 사이즈 OK, 파일타입이 이미지가 아니면
            else if (imageUpload.PostedFile.ContentLength < maxImageSize &&
                (imageUpload.PostedFile.ContentType != "image/x-png" ||
                imageUpload.PostedFile.ContentType != "image/pjpeg" ||
                imageUpload.PostedFile.ContentType != "image/jpeg" ||
                imageUpload.PostedFile.ContentType != "image/bmp" ||
                imageUpload.PostedFile.ContentType != "image/png" ||
                imageUpload.PostedFile.ContentType != "image/gif"))
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Please upload image ');</script>");
            }

            else if (imageUpload.PostedFile.ContentLength >= maxImageSize &&
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

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            iID = inumlbl.Text;
            iCategory = CategoryList.SelectedValue.ToString();
            iName = iNameBox.Text;
            iPPrice = pPriceBox.Text;
            iRPrice = rPriceBox.Text;

            iNote = notebox.Text;
            iImage = imgURL.Text;
            iQuantity = qtyList.SelectedValue.ToString();

            CsItem oldItemInfo = new CsItem(iID, iCategory, iName, iPPrice, iRPrice, iNote, iImage, iQuantity, iRday);

            try
            {
                ConnectionClass.UpdateItemDetail(oldItemInfo);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Updated!');</script>");
            }

            catch
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script>alert('Update failed');</script>");
            }

            finally
            {
                DisableTextBoxes(Page);
                btnUpload.Visible = false;
            }
    }



        protected void DisableTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Enabled = false;
                        t.CssClass = "CustomerOutput";

                    }
                }

                else if (ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {
                        d.Enabled = false;
                        d.CssClass = "CustomerOutput";
                    }
                }



                else if (ctrl is FileUpload)
                {
                    FileUpload u = ctrl as FileUpload;
                    if (u != null)
                    {
                        u.Visible = false;
                    }
                }

                //else if (ctrl is Button)
                //{
                //    Button b = ctrl as Button;
                //    if (b != null)
                //    {
                //        b.Visible = false;
                //    }
                //}

                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        DisableTextBoxes(ctrl);
                    }
                }
            }
        }



        protected void AbleTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;
                    if (t != null)
                    {
                        t.Enabled = true;
                        t.CssClass = "CustomerInput";
                    }
                }

                else if (ctrl is DropDownList)
                {
                    DropDownList d = ctrl as DropDownList;
                    if (d != null)
                    {
                        d.Enabled = true;
                        d.CssClass = "ProvinceInput";
                    }
                }

                else if (ctrl is FileUpload)
                {
                    FileUpload u = ctrl as FileUpload;
                    if (u != null)
                    {
                        u.Visible = true;
                    }
                }

                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        AbleTextBoxes(ctrl);
                    }
                }
            }
        }

       
    }
}