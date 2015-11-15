<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFirstWebPage.aspx.cs" Inherits="FirstWebApplication.MyFirstWebPage" %>

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
            <td> <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></td>
            <td> <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox></td>
            <td> <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" /></td>
            
        </tr>
        <tr>
            <td> <asp:Label ID="Label2" runat="server" Text="Age"></asp:Label></td>
            <td> <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td> <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label></td>
            <td> <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td> <asp:Label ID="Label4" runat="server" Text="Contact No"></asp:Label></td>
            <td> <asp:TextBox ID="contactTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <%-- <tr>
            <td> <asp:Label ID="Label5" runat="server" Text="Employee ID"></asp:Label></td>
            <td> <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td> <asp:Label ID="Label6" runat="server" Text="Department"></asp:Label></td>
            <td> <asp:TextBox ID="deptTextBox" runat="server"></asp:TextBox></td>
        </tr>
        <%-- <tr>
            <td> <asp:Label ID="Label7" runat="server" Text="StudentID"></asp:Label></td>
            <td> <asp:TextBox ID="stdIdTextBox" runat="server"></asp:TextBox></td>
        </tr>--%>
        <tr>
            <td> <asp:Label ID="Label8" runat="server" Text="Marks"></asp:Label></td>
            <td> <asp:TextBox ID="TextBox" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
           <td></td> 
            <td><asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
           
        </tr>
        <tr>
         
            <td></td>
            <td> <asp:Label ID="Msglabel" runat="server"></asp:Label></td>
        </tr>
    </table>
        <asp:GridView ID="studentGridView" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" Height="104px" OnPageIndexChanging="studentGridView_PageIndexChanging" OnRowCancelingEdit="studentGridView_RowCancelingEdit" OnRowDeleting="studentGridView_RowDeleting" OnRowEditing="studentGridView_RowEditing" OnRowUpdating="studentGridView_RowUpdating" PageSize="5" Width="566px" AllowPaging="True">
            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <asp:TextBox ID="idTextBox" runat="server" Text='<%# Bind("Id") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="idLabel" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <EditItemTemplate>
                        <asp:TextBox ID="ageTextBox" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Age") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="addressTextBox" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact No">
                    <EditItemTemplate>
                        <asp:TextBox ID="contactTextBox" runat="server" Text='<%# Bind("ContactNo") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ContactNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department">
                    <EditItemTemplate>
                        <asp:TextBox ID="deptTextBox" runat="server" Text='<%# Bind("Department") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Marks">
                    <EditItemTemplate>
                        <asp:TextBox ID="marksTextBox" runat="server" Text='<%# Bind("Marks") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Marks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Modify" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="updateLinkButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="cancelLinkButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="editLinkButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="deleteLinkButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="Gray" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </div>
    </form>
</body>
</html>
