<%@ Page Title="Blackjack: User Profile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

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
                            <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label2" runat="server" Text="Current Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxP" runat="server" TextMode="Password" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="New Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxPN1" runat="server" TextMode="Password" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label6" runat="server" Text="Confirm Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxPN2" runat="server" TextMode="Password" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Email Address:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label11" runat="server" Text="Add Money:"></asp:Label>
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
                <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout" Enabled="True" Selectable="True"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/AdminUsers.aspx" Text="User Administration" Value="User Administration"></asp:MenuItem>
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
                <asp:Label ID="Label16" runat="server" Text="Blackjack: "></asp:Label><asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                <br />
            </asp:TableCell>
            <asp:TableCell runat="server" Width="20px">
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

