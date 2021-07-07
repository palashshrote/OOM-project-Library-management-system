<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="view_books.aspx.cs" Inherits="OOM_Project_1.view_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container">
        <div class ="row">
            <div class ="col">
                <br />
            </div>
        </div>
        <div class ="row">
            <div class ="col">
                <center>
                    <img width ="90" src="imgs/books/book.png" />
                    <h4>Books List</h4>
                </center>
            </div>
        </div>
        <div class ="row">
            <div class ="col">
                <br />
            </div>
        </div>
        <div class ="row">
            <div class ="col">
                <div class ="card">
                   <div class ="card-body">
                        
                        <div class ="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OOM_Project_library_managementConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" ReadOnly="True" SortExpression="book_id" >
                                        <ItemStyle Font-Bold="True" Font-Size="X-Large" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class ="container">
                                                    <div class ="row">
                                                        <div class ="col-lg-10">
                                                            <div class ="row">
                                                                <div class ="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class ="row">
                                                                <div class ="col">
                                                                    <br />
                                                                </div>
                                                            </div>
                                                            <div class ="row">
                                                                <div class ="col-12">

                                                                    Author -
                                                                    <asp:Label Font-Bold="True" ID="Label2" runat="server" Text='<%# Eval("author_name") %>'></asp:Label>
                                                                    &nbsp;| Genre -
                                                                    <asp:Label Font-Bold="True" ID="Label3" runat="server" Text='<%# Eval("genre") %>'></asp:Label>
                                                                    &nbsp;| Language -
                                                                    <asp:Label Font-Bold="True" ID="Label4" runat="server" Text='<%# Eval("language") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class ="row">
                                                                <div class ="col-12">

                                                                    Publisher -
                                                                    <asp:Label Font-Bold="True" ID="Label5" runat="server" Text='<%# Eval("publisher_name") %>'></asp:Label>
                                                                    &nbsp;| Publish date -
                                                                    <asp:Label Font-Bold="True" ID="Label6" runat="server" Text='<%# Eval("publish_date") %>'></asp:Label>
                                                                    &nbsp;| Pages -
                                                                    <asp:Label Font-Bold="True" ID="Label7" runat="server" Text='<%# Eval("no_of_pages") %>'></asp:Label>
                                                                    &nbsp;| Edition -
                                                                    <asp:Label Font-Bold="True" ID="Label8" runat="server" Text='<%# Eval("edition") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class ="row">
                                                                <div class ="col-12">

                                                                    Cost -
                                                                    <asp:Label Font-Bold="True" ID="Label9" runat="server" Text='<%# Eval("book_cost") %>'></asp:Label>
                                                                    &nbsp;| Actual Stock -
                                                                    <asp:Label Font-Bold="True" ID="Label10" runat="server" Text='<%# Eval("actual_stock") %>'></asp:Label>
                                                                    &nbsp;| Available -
                                                                    <asp:Label Font-Bold="True" ID="Label11" runat="server" Text='<%# Eval("current_stock") %>'></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class ="col-lg-2">
                                                            <asp:Image CssClass="img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <
    </div>
</asp:Content>
