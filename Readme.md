<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [FolderBindingMode.aspx](./CS/FolderBindingMode.aspx) (VB: [FolderBindingMode.aspx](./VB/FolderBindingMode.aspx))
* [FolderBindingMode.aspx.cs](./CS/FolderBindingMode.aspx.cs) (VB: [FolderBindingMode.aspx.vb](./VB/FolderBindingMode.aspx.vb))
* [RegularBindingMode.aspx](./CS/RegularBindingMode.aspx) (VB: [RegularBindingMode.aspx](./VB/RegularBindingMode.aspx))
* [RegularBindingMode.aspx.cs](./CS/RegularBindingMode.aspx.cs) (VB: [RegularBindingMode.aspx.vb](./VB/RegularBindingMode.aspx.vb))
<!-- default file list end -->
# ASPxImageGallery - How to add / remove images in different binding modes


<p>This example illustrates how to add / remove images in <a href="http://demos.devexpress.com/ASPxImageAndDataNavigationDemos/ImageGallery/FolderBinding.aspx">Folder Binding</a> and regular <a href="http://demos.devexpress.com/ASPxImageAndDataNavigationDemos/ImageGallery/DataBinding.aspx">Data Binding</a> modes. We use <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxUploadControltopic">ASPxUploadControl</a> to upload new images from the client's machine. As for removing an image, we override <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxImageGallery_ItemTextTemplatetopic">ASPxImageGallery.ItemTextTemplate</a> to add the "remove" button to the <a href="https://documentation.devexpress.com/#AspNet/CustomDocument15178">Thumbnail Text Area</a>. Take special note of the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxImageGallery_UpdateImageCacheFoldertopic">ASPxImageGallery.UpdateImageCacheFolder</a> method that is used to refresh the image gallery' cache when the data source is modified.</p>

<br/>


