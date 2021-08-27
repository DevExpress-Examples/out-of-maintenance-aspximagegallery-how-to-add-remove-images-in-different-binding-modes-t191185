<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128554763/14.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T191185)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


<p>This example illustrates how to add / remove images in <a href="http://demos.devexpress.com/ASPxImageAndDataNavigationDemos/ImageGallery/FolderBinding.aspx">Folder Binding</a> and regular <a href="http://demos.devexpress.com/ASPxImageAndDataNavigationDemos/ImageGallery/DataBinding.aspx">Data Binding</a> modes. We use <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxUploadControltopic">ASPxUploadControl</a> to upload new images from the client's machine. As for removing an image, we override <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxImageGallery_ItemTextTemplatetopic">ASPxImageGallery.ItemTextTemplate</a> to add the "remove" button to the <a href="https://docs.devexpress.com/AspNet/15192/components/data-and-image-navigation/image-gallery/visual-elements#thumbnail-text-area">Thumbnail Text Area</a>. Take special note of the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxImageGallery_UpdateImageCacheFoldertopic">ASPxImageGallery.UpdateImageCacheFolder</a> method that is used to refresh the image gallery' cache when the data source is modified.</p>

<br/>


