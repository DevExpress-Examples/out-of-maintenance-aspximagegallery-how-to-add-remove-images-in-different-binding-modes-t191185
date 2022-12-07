using System;
using System.IO;
using DevExpress.Web;

public partial class FolderBindingMode : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        this.DataBind();
    }

    protected void btnRemove_Init(object sender, EventArgs e) {
        ASPxButton btnRemove = (ASPxButton)sender;
        ImageGalleryThumbnailTemplateContainer container = (ImageGalleryThumbnailTemplateContainer)btnRemove.NamingContainer;
        btnRemove.ClientSideEvents.Click = string.Format(@"function(s, e) {{ imageGallery.PerformCallback('REMOVE|{0}'); }}", container.ItemIndex);
    }

    protected void ASPxImageGallery1_CustomCallback(object sender, DevExpress.Web.CallbackEventArgsBase e) {
        string[] parts = e.Parameter.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        string command = parts[0];

        if (command.Equals("REMOVE", StringComparison.InvariantCultureIgnoreCase)) {
            int index = Convert.ToInt32(parts[1]);
            string sourceFolderPath = Server.MapPath(ASPxImageGallery1.SettingsFolder.ImageSourceFolder);
            string fileName = Path.GetFileName(ASPxImageGallery1.Items[index].ImageUrl);

            int paramCharIndex = fileName.IndexOf("?");

            if (paramCharIndex != -1)
                fileName = fileName.Remove(paramCharIndex);

            File.Delete(Path.Combine(sourceFolderPath, fileName));
            ASPxImageGallery1.UpdateImageCacheFolder();
        }
        else if (command.Equals("REFRESH", StringComparison.InvariantCultureIgnoreCase)) {
            ASPxImageGallery1.UpdateImageCacheFolder();
        }
    }

    protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e) {
        string path = "~/Images/" + e.UploadedFile.FileName;
        e.UploadedFile.SaveAs(Server.MapPath(path));
    }
}