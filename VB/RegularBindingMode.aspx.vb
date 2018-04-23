Imports System
Imports System.Data
Imports System.IO
Imports System.Web.UI
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxImageGallery
Imports DevExpress.Web.ASPxUploadControl

Partial Public Class RegularBindingMode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me.DataBind()
    End Sub

    Protected Sub btnRemove_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnRemove As ASPxButton = DirectCast(sender, ASPxButton)
        Dim container As ImageGalleryThumbnailTemplateContainer = CType(btnRemove.NamingContainer, ImageGalleryThumbnailTemplateContainer)

        ' var id = DataBinder.Eval(container.Item.DataItem, "Id")
        btnRemove.ClientSideEvents.Click = String.Format("function(s, e) {{ imageGallery.PerformCallback('REMOVE|{0}'); }}", container.Item.Name)
    End Sub

    Protected Sub ASPxImageGallery1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Dim parts() As String = e.Parameter.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)
        Dim command As String = parts(0)

        If command.Equals("REMOVE", StringComparison.InvariantCultureIgnoreCase) Then
            File.Delete(String.Format(Server.MapPath(ASPxImageGallery1.ImageUrlFormatString), GetImageFileNameById(parts(1))))
            AccessDataSource1.DeleteParameters("ID").DefaultValue = parts(1)
            AccessDataSource1.Delete()
            ASPxImageGallery1.UpdateImageCacheFolder()
        ElseIf command.Equals("REFRESH", StringComparison.InvariantCultureIgnoreCase) Then
            ASPxImageGallery1.UpdateImageCacheFolder()
        End If
    End Sub

    Protected Function GetImageFileNameById(ByVal id As String) As String
        AccessDataSource2.SelectParameters("ID").DefaultValue = id
        Return CType(AccessDataSource2.Select(DataSourceSelectArguments.Empty), DataView)(0)("ImageFileName").ToString()
    End Function

    Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
        Dim path As String = "~/ImagesDB/" & e.UploadedFile.FileName
        e.UploadedFile.SaveAs(Server.MapPath(path))

        AccessDataSource1.InsertParameters("Model").DefaultValue = "New Model"
        AccessDataSource1.InsertParameters("Pixels").DefaultValue = "0"
        AccessDataSource1.InsertParameters("ImageFileName").DefaultValue = e.UploadedFile.FileName

        AccessDataSource1.Insert()
    End Sub
End Class