<%@ Page Language="vb" AutoEventWireup="true" CodeFile="FolderBindingMode.aspx.vb" Inherits="FolderBindingMode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxImageGallery ID="ASPxImageGallery1" runat="server" ClientInstanceName="imageGallery"
                ThumbnailWidth="120" ThumbnailHeight="160" Layout="Flow" OnCustomCallback="ASPxImageGallery1_CustomCallback">
                <SettingsFolder ImageSourceFolder="~\Images\" ImageCacheFolder="~\Thumb\" />
                <SettingsFlowLayout ItemsPerPage="5" />
                <ItemTextTemplate>
                    <dx:ASPxButton ID="btnRemove" runat="server" AutoPostBack="false" RenderMode="Link" OnInit="btnRemove_Init">
                        <Image IconID="actions_remove_16x16" />
                    </dx:ASPxButton>
                    <%#System.IO.Path.GetFileNameWithoutExtension(Container.Item.ImageUrl)%>
                </ItemTextTemplate>
            </dx:ASPxImageGallery>

            <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" ClientInstanceName="uploader"
                ShowUploadButton="true" NullText="Click here to browse images..." Width="320"
                OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">

                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp" />

                <ClientSideEvents FileUploadComplete="function(s, e) { imageGallery.PerformCallback('REFRESH'); }" />
            </dx:ASPxUploadControl>

            <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Font-Size="8pt"
                Text='<%#"Allowed file types: " & String.Join(", ", ASPxUploadControl1.ValidationSettings.AllowedFileExtensions)%>'  />
            <br />
            <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Font-Size="8pt"
                Text='<%#"Maximum file size: " & ASPxUploadControl1.ValidationSettings.MaxFileSize / 1048576 & "Mb"%>' />
        </div>
    </form>
</body>
</html>