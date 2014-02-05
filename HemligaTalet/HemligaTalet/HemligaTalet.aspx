<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HemligaTalet.aspx.cs" Inherits="HemligaTalet.HemligaTalet" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="sv">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link rel="stylesheet" href="stylesheets/style.css"/>
</head>
<body>
    <div class="container">
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
    <div>
        <%-- Errors --%>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="False" HeaderText="Fel inträffade. Korrigera och försök igen." />
        </div>

        <asp:Label ID="Label1" runat="server" Text="Ange ett tal mellan 1 och 100:" AssociatedControlID="GuessTextBox"></asp:Label>
        <asp:TextBox ID="GuessTextBox" runat="server" Width="30px" autofocus="autofocus"></asp:TextBox>
        <asp:Button ID="GuessButton" runat="server" Text="Skicka gissning" OnClick="GuessButton_Click" />
        
        <%-- Validation --%>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får inte vara tomt." ControlToValidate="GuessTextBox" Display="Dynamic" SetFocusOnError="True" Text="*"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1 och 100." ControlToValidate="GuessTextBox" Display="Dynamic" SetFocusOnError="True" Text="*" Type="Integer" MaximumValue="100" MinimumValue="1"></asp:RangeValidator>         
        
        <asp:PlaceHolder ID="Results" runat="server" Visible="False">
        <div>
            <div class="pguesses">
                <asp:Label ID="PrevGuessesLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="status">
                <asp:Label ID="GuessesStatusLabel" runat="server" Text=""></asp:Label>
            </div>            
            <div>
                <asp:Button ID="NewNumberButton" runat="server" Text="Slumpa nytt hemligt tal" Visible="False" OnClick="NewNumberButton_Click" />
            </div>
        </div>
        </asp:PlaceHolder>
    
    </div>
    </form>
    </div>
</body>
</html>
