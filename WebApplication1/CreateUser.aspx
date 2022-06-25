<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="WebApplication1.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Username:</td>
                    <td>
                        <asp:TextBox ID="UserNameTextBox" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="PasswordTextBox" TextMode="Password" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Create User" />
                    </td>
                </tr>
                  <tr>
                    <td></td>
                    <td>
                        <asp:CheckBoxList ID="RolesList" runat="server"></asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label runat="server" ID="lblOutput"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Find User" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAddRole" runat="server" OnClick="btnAddRole_Click" Text="Add New Role" />
                    </td>
                    <td>

                        <asp:Button ID="btnAssignUser" runat="server" OnClick="btnAssignUser_Click" Text="Assign User To Role" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
