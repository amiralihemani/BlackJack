<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blackjack: Team 25</title>
    <style type="text/css">
        body {
            height: 100%;
            background-image: url("/Image/MainBackground.png");
            background-size: cover;
        }

        div#form-wrapper {
            position: absolute;
            text-align: center;
            top: 50%;
            right: 0;
            left: 0;
        }
    </style>
</head>
<body>
    <div id="form-wrapper">
        <form id="form1" runat="server">
            <asp:Button ID="Button1" runat="server" Text="Play Game" OnClick="Button1_Click" />
        </form>
    </div>
</body>
</html>
