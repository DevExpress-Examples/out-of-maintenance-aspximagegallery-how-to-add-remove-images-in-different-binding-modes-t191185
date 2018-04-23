
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegularBindingMode.aspx.cs" Inherits="RegularBindingMode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxImageGallery ID="ASPxImageGallery1" runat="server" ClientInstanceName="imageGallery"
                DataSourceID="AccessDataSource1" NameField="ID" ImageUrlField="ImageFileName" ImageUrlFormatString="~\ImagesDB\{0}"
                ThumbnailWidth="220" ThumbnailHeight="160" Layout="Flow" OnCustomCallback="ASPxImageGallery1_CustomCallback">
                <SettingsFlowLayout ItemsPerPage="5" />
                <ItemTextTemplate>
                    <dx:ASPxButton ID="btnRemove" runat="server" AutoPostBack="false" RenderMode="Link" OnInit="btnRemove_Init">
                        <Image IconID="actions_remove_16x16" />
                    </dx:ASPxButton>
                    <%# Container.EvalDataItem("Model") + ", " + Container.EvalDataItem("Pixels") %>
                </ItemTextTemplate>
            </dx:ASPxImageGallery>
            
            <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/Data.mdb"
                SelectCommand="SELECT [ID], [Model], [Pixels], [ImageFileName] FROM [Cameras]"
                InsertCommand="INSERT INTO [Cameras] ([Model], [Pixels], [ImageFileName]) VALUES (?, ?, ?)"
                DeleteCommand="DELETE FROM [Cameras] WHERE [ID] = ?">
                <InsertParameters>
                    <asp:Parameter Name="Model" Type="String" />
                    <asp:Parameter Name="Pixels" Type="Decimal" />
                    <asp:Parameter Name="ImageFileName" Type="String" />
                </InsertParameters>
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
            </asp:AccessDataSource>

            <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/Data.mdb"
                SelectCommand="SELECT [ImageFileName] FROM [Cameras] WHERE [ID] = ?">
                <SelectParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </SelectParameters>
            </asp:AccessDataSource>

            <dx:ASPxUploadControl ID="ASPxUploadControl1" runat="server" ClientInstanceName="uploader"
                ShowUploadButton="true" NullText="Click here to browse images..." Width="320"
                OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                        
                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".jpg,.jpeg,.png,.bmp" />
  
                <ClientSideEvents FileUploadComplete="function(s, e) { imageGallery.PerformCallback('REFRESH'); }" />
            </dx:ASPxUploadControl>
            
            <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Font-Size="8pt"
                Text='<%# "Allowed file types: " + string.Join(", ", ASPxUploadControl1.ValidationSettings.AllowedFileExtensions) %>'  />
            <br />
            <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Font-Size="8pt"
                Text='<%# "Maximum file size: " + ASPxUploadControl1.ValidationSettings.MaxFileSize / 1048576 + "Mb" %>' />
        </div>
    </form>
</body>
</html>