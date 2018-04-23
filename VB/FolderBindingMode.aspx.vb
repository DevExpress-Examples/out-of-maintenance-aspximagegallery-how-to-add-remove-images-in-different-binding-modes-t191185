Imports System
Imports System.IO
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxImageGallery
Imports DevExpress.Web.ASPxUploadControl

Partial Public Class FolderBindingMode
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Me.DataBind()
    End Sub

    Protected Sub btnRemove_Init(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnRemove As ASPxButton = DirectCast(sender, ASPxButton)
        Dim container As ImageGalleryThumbnailTemplateContainer = CType(btnRemove.NamingContainer, ImageGalleryThumbnailTemplateContainer)
        btnRemove.ClientSideEvents.Click = String.Format("function(s, e) {{ imageGallery.PerformCallback('REMOVE|{0}'); }}", container.ItemIndex)
    End Sub

    Protected Sub ASPxImageGallery1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Dim parts() As String = e.Parameter.Split(New Char() { "|"c }, StringSplitOptions.RemoveEmptyEntries)
        Dim command As String = parts(0)

        If command.Equals("REMOVE", StringComparison.InvariantCultureIgnoreCase) Then
            Dim index As Integer = Convert.ToInt32(parts(1))
            Dim sourceFolderPath As String = Server.MapPath(ASPxImageGallery1.SettingsFolder.ImageSourceFolder)
            Dim fileName As String = Path.GetFileName(ASPxImageGallery1.Items(index).ImageUrl)

            Dim paramCharIndex As Integer = fileName.IndexOf("?")

            If paramCharIndex <> -1 Then
                fileName = fileName.Remove(paramCharIndex)
            End If

            File.Delete(Path.Combine(sourceFolderPath, fileName))
            ASPxImageGallery1.UpdateImageCacheFolder()
        ElseIf command.Equals("REFRESH", StringComparison.InvariantCultureIgnoreCase) Then
            ASPxImageGallery1.UpdateImageCacheFolder()
        End If
    End Sub

    Protected Sub ASPxUploadControl1_FileUploadComplete(ByVal sender As Object, ByVal e As FileUploadCompleteEventArgs)
        Dim path As String = "~/Images/" & e.UploadedFile.FileName
        e.UploadedFile.SaveAs(Server.MapPath(path))
    End Sub
End Class