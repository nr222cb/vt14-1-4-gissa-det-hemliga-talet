<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HemligaTalet.aspx.cs" Inherits="HemligaTalet.HemligaTalet" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="sv">
<head runat="server">
    <title>Gissa det hemliga talet</title>
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="GuessButton" runat="server" Text="Gissa" OnClick="GuessButton_Click" />
    </div>
    </form>
</body>
</html>
