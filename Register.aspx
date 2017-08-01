<%@ Page Title="Blackjack: Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelCurrentUser" runat="server" Text=""></asp:Label>
    <hr />
    <asp:Table ID="Table1" runat="server" Height="75%" Width="100%">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="1px">
                <br/>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="400px">
                <asp:Table ID="Table2" runat="server" Height="100%" Width="100%">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right" Width="200px">
                            <asp:Label ID="Label1" runat="server" Text="User Name:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxUN" runat="server" Width="180px" OnTextChanged="TextBoxUN_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right" Width="200px">
                            <asp:Label ID="Label2" runat="server" Text="Email Address:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxEmail" runat="server" Width="180px"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server" HorizontalAlign="Right">
                            <asp:Label ID="Label4" runat="server" Text="Confirm Password:"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell runat="server" HorizontalAlign="Left">
                            <asp:TextBox ID="TextBoxRpass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="200px" HorizontalAlign="Center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Reset " />
                <br />
                <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>
            </asp:TableCell>
            <asp:TableCell runat="server">
                <asp:Menu ID="Menu1" runat="server">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Logout" Value="Logout"></asp:MenuItem>
                        <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Login" Value="Login"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

