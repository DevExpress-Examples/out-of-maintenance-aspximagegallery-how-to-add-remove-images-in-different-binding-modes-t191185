<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ImageGalleryCRUD</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink id="HyperLink1" runat="server" Target="_self" NavigateUrl="FolderBindingMode.aspx" Text="Folder Binding Mode" />
            <br />
            <asp:HyperLink id="HyperLink2" runat="server" Target="_self" NavigateUrl="RegularBindingMode.aspx" Text="Regular Binding Mode" />
        </div>
    </form>
</body>
</html>