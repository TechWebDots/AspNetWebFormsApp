<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="DotNetConcept.LogIn" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <link href="Styles/bootstrap-3.3.7.css" rel="stylesheet" />
    <link href="Styles/Site.css" rel="stylesheet" />
</head>
<body>
    <form id="frmLogIn" class="frmMaster" runat="server">
        <table class="form-control welcomeProjectText" style="padding: 6px 6px;height: auto;">
            <tbody>
                <tr>
                    <td class="panelTD welcomeProjectTextTD">TechWebDots<br />LogIn Design<br/>(Bootstrap and CSS)</td>
                    <td class="panelTDControl" style="width: 30%;">
                        <asp:Label ID="lblVersionInfo" style="float: right;font-size:9px;" runat="server" Text=""></asp:Label>
                        <table id="tblLogIn" class="table tblLogIn">
                            <tbody>
                                <tr><td><asp:Label ID="lblUserName" CssClass="form-control panelControl controlBackground" runat="server" Text="User Id"></asp:Label></td></tr>
                                <tr><td><asp:TextBox placeholder="Enter User Id" CssClass="form-control panelControl" ClientIDMode="Static" ID="txtUserId" runat="server"></asp:TextBox></td></tr>
                                <tr><td><asp:Label ID="lblPassword" CssClass="form-control panelControl controlBackground" runat="server" Text="Password"></asp:Label></td></tr>
                                <tr><td><asp:TextBox placeholder="Enter Password" CssClass="form-control panelControl" ClientIDMode="Static" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td></tr>
                                <tr><td><asp:CheckBox ID="chkBoxRememberMe" runat="server" Text="Remember me" /></td></tr>
                                <tr><td><asp:Label ID="lblErrorMessage" style="color: red;" runat="server" Text=""></asp:Label></td></tr>
                                <tr><td><asp:Button ID="btnLogIn" CssClass="btn btn-default" runat="server" Text="LogIn" OnClick="btnLogIn_Click" OnClientClick="return AuthenticateUser();"/></td></tr>
                                <tr><td><a href="mailto:techwebdots@gmail.com?Subject=Request:Reset%20Password" target="_top">Forgot Password?</a></td></tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="panelTD controlBackground" style="text-align: center;">
                        Don't have an account? <a href="mailto:techwebdots@gmail.com?Subject=Request:New%20Account" style="color: white !important;" target="_top">Click here to Contact</a>
                    </td>
                    <td class="panelTDControl"></td>
                </tr>                
            </tbody>
        </table>
        <div style="text-align: center;">
            <p>Copyright © TechWebDots, All Rights Reserverd - <%: DateTime.Now.Year %></p>
        </div>
    </form>   
</body>
</html>