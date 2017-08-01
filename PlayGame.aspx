<%@ Page Title="Blackjack: Play Game"  Language="C#" AutoEventWireup="true" CodeFile="PlayGame.aspx.cs" Inherits="_PlayGame" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="PlayGameContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div>
        <!--<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/6_of_hearts.png" style="height:100px ; width:100px ;position:absolute; top:20px;left:500px" />
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/9_of_hearts.png" style="margin-left:-10px ; height:100px;width:100px;position:absolute; top:20px; left:525px" />-->
        <asp:Panel ID="Panel1" runat="server" Height="404px"></asp:Panel>
        <div runat="server" style="position: absolute; top: 200px; left: 221px; width: 592px; margin-top: 1px;">
            <asp:Label ID="placebet" runat="server" Text="Place Bet" Font-Bold="true" ForeColor="Red" Font-Size="30px"></asp:Label>
            &nbsp;
        <asp:Label ID="betamount" runat="server" Text="10" Font-Size="30px" ForeColor="Blue"></asp:Label>
            &nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/up.jpg" Style="height: 20px; width: 20px" OnClick="ImageButton1_Click" />
            &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/down.png" Style="height: 20px; width: 20px" OnClick="ImageButton2_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Deal" runat="server" Text="Deal" OnClick="Deal_Click" />
            &nbsp;&nbsp;
        <asp:Button ID="Stand" runat="server" Text="Stand" OnClick="Stand_Click" />
            &nbsp;
            <asp:Button ID="Hit" runat="server" Text="Hit" OnClick="Hit_Click" />
            &nbsp;
            <asp:Button ID="Play_Again" runat="server" Text="Play Again" OnClick="Play_Again_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    User Profile:
    <asp:Label ID="LabelCurrentUser" runat="server" Text=""></asp:Label>
    <hr />
    <asp:Table ID="Table1" runat="server" Height="75%" Width="100%">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="200px">
                <br />
            </asp:TableCell>
            <asp:TableCell runat="server" Width="400px">
                <asp:Table ID="Table2" runat="server" Height="100%" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right" Width="200px">
                        <br />
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                        <br />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center">
                <br />
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout" Enabled="True" Selectable="True"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/UserProfile.aspx" Text="My Profile" Value="My Profile"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AdminUsers.aspx" Text="User Administration" Value="User Administration"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AdminGame.aspx" Text="Game Administration" Value="Game Administration"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </asp:TableCell>
            <asp:TableCell runat="server" BorderWidth="1" Width="200px" HorizontalAlign="Center">
                <asp:Label ID="Label7" runat="server" Text="Money: $"></asp:Label><asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label8" runat="server" Text="Games Won: "></asp:Label><asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label9" runat="server" Text="Games Lost: "></asp:Label><asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label10" runat="server" Text="Games Tied: "></asp:Label><asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
                <br />
                <asp:Label ID="Label16" runat="server" Text="Blackjack: "></asp:Label><asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                <br />
            </asp:TableCell>
            <asp:TableCell runat="server" Width="20px">
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
