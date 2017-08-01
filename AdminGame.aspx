<%@ Page Title="Blackjack: Game Administration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminGame.aspx.cs" Inherits="Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
Game Administration: <asp:Label ID="LabelCurrentUser" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="Label1" runat="server" Text="Game Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Label ID="Label5" runat="server" Text="Blackjack Team 25"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label2" runat="server" Text="Maximum Bet:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Minimum Bet:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label7" runat="server" Text="Incremental Bet:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center">
                <asp:Button ID="Button1" runat="server" Text="Post Changes" OnClick="Button1_Click" />
                <br />
                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/UserProfile.aspx" Text="My Profile" Value="My Profile"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AdminUsers.aspx" Text="User Administration" Value="User Administration"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/PlayGame.aspx" Text="Play Game" Value="Play Game"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

