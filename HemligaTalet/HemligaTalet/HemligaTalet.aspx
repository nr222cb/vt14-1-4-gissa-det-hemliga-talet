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
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" HeaderText="Fel inträffade. Korrigera och försök igen." />
        </div>

        <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100:" AssociatedControlID="GuessTextBox"></asp:Label>
        <asp:TextBox ID="GuessTextBox" runat="server" Width="30px"></asp:TextBox>
        <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" OnClick="GuessButton_Click" />
        <%-- Validation --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får inte vara tomt." ControlToValidate="GuessTextBox" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1 och 100." ControlToValidate="GuessTextBox" Display="Dynamic" SetFocusOnError="True" Text="*" Type="Integer" MaximumValue="100" MinimumValue="1"></asp:RangeValidator>         
    </div>
    </form>
</body>
</html>
