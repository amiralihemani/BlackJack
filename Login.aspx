<%@ Page Title="Blackjack: Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
Login: <asp:Label ID="LabelCurrentUser" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="Label3" runat="server" Text="User Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxUN" runat="server"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label6" runat="server" Text="Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxP" runat="server" TextMode="Password" autocomplete="off"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center">
                <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click"/>
                <br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Register.aspx" Text="Register" Value="Register"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

