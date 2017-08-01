<%@ Page Title="Blackjack: User Administration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminUsers.aspx.cs" Inherits="Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    User Administration: <asp:Label ID="LabelCurrentUser" runat="server" Text=""></asp:Label>
<hr />
    <asp:Table ID="Table1" runat="server" Height="75%" Width="100%">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="200px">
                <asp:ListBox ID="ListBox1" runat="server" Width="200px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="UserId" Height="100%" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BlackJackDatabase %>" SelectCommand="SELECT [UserName], [UserId] FROM [Users]"></asp:SqlDataSource>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="400px">
                <asp:Table ID="Table2" runat="server" Height="100%" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right" Width="200px">
                            <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Email Address:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="Admin Rights:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:CheckBox ID="CheckBox1" runat="server"/>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center">
                <asp:Button ID="Button1" runat="server" Text="Post Changes" OnClick="Button1_Click" />
                <br />
                <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/UserProfile.aspx" Text="My Profile" Value="My Profile"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AdminGame.aspx" Text="Game Administration" Value="Game Administration"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/PlayGame.aspx" Text="Play Game" Value="Play Game"></asp:MenuItem>
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
                <asp:Label ID="Label6" runat="server" Text="Blackjack: "></asp:Label><asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                <br />
            </asp:TableCell>
            <asp:TableCell runat="server" Width="20px">
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

