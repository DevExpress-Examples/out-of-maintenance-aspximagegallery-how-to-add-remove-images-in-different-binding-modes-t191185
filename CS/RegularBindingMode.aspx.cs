using System;
using System.Data;
using System.IO;
using System.Web.UI;
using DevExpress.Web;

public partial class RegularBindingMode : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        this.DataBind();
    }

    protected void btnRemove_Init(object sender, EventArgs e) {
        ASPxButton btnRemove = (ASPxButton)sender;
        ImageGalleryThumbnailTemplateContainer container = (ImageGalleryThumbnailTemplateContainer)btnRemove.NamingContainer;

        // var id = DataBinder.Eval(container.Item.DataItem, "Id")
        btnRemove.ClientSideEvents.Click = string.Format(@"function(s, e) {{ imageGallery.PerformCallback('REMOVE|{0}'); }}", container.Item.Name);
    }

    protected void ASPxImageGallery1_CustomCallback(object sender, DevExpress.Web.CallbackEventArgsBase e) {
        string[] parts = e.Parameter.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        string command = parts[0];

        if (command.Equals("REMOVE", StringComparison.InvariantCultureIgnoreCase)) {
            File.Delete(string.Format(Server.MapPath(ASPxImageGallery1.ImageUrlFormatString), GetImageFileNameById(parts[1])));
            AccessDataSource1.DeleteParameters["ID"].DefaultValue = parts[1];
            AccessDataSource1.Delete();
            ASPxImageGallery1.UpdateImageCacheFolder();
        }
        else if (command.Equals("REFRESH", StringComparison.InvariantCultureIgnoreCase)) {
            ASPxImageGallery1.UpdateImageCacheFolder();
        }
    }

    protected string GetImageFileNameById(string id) {
        AccessDataSource2.SelectParameters["ID"].DefaultValue = id;
        return ((DataView)AccessDataSource2.Select(DataSourceSelectArguments.Empty))[0]["ImageFileName"].ToString();
    }

    protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e) {
        string path = "~/ImagesDB/" + e.UploadedFile.FileName;
        e.UploadedFile.SaveAs(Server.MapPath(path));

        AccessDataSource1.InsertParameters["Model"].DefaultValue = "New Model";
        AccessDataSource1.InsertParameters["Pixels"].DefaultValue = "0";
        AccessDataSource1.InsertParameters["ImageFileName"].DefaultValue = e.UploadedFile.FileName;

        AccessDataSource1.Insert();
    }
}