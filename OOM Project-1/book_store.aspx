<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="book_store.aspx.cs" Inherits="OOM_Project_1.book_store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container-fluid">
        <div class ="row">
            <div class="col-md-5">
                <div class ="card">
                    <div class ="card-body">
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img id="imgview" width="100" src="book_inventory/book1.png" />
                                    <br />
                                    <h3>Book Details</h3>
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
                                <asp:FileUpload onchange="realURL(this);" class="form-control" CssClass="form-control" ID="FileUpload1" runat="server" />    
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-4">
                                <label class="form-label">Book ID</label>
                                <div class ="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="ID" ID="TextBox1" runat="server"></asp:TextBox>
                                    <asp:Button CssClass ="form-control btn btn-primary" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click1" />
                                </div>
                            </div>
                            <div class ="col-md-8">
                                <label class="form-label">Book name</label>
                                <asp:TextBox CssClass="form-control" placeholder="Book name"  ID="TextBox2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        
                        <div class ="row">
                            <div class ="col-md-4">
                                <div class ="row">
                                    <label class="form-label">Language</label>
                                    <asp:DropDownList CssClass ="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text ="Select" Value ="Select" />
                                        <asp:ListItem Text ="English" Value ="English" />
                                        <asp:ListItem Text ="Hindi" Value ="Hindi" />
                                        <asp:ListItem Text ="French" Value ="French" />
                                        <asp:ListItem Text ="German" Value ="German" />
                                        <asp:ListItem Text ="Marathi" Value ="Marathi" />
                                        <asp:ListItem Text ="Tamil" Value ="Tamil" />
                                        <asp:ListItem Text ="Gujrati" Value ="Gujrati" />
                                    </asp:DropDownList>
                                </div>
                                <div class ="row">
                                    <label class="form-label">Publisher Name</label>
                                     <asp:DropDownList CssClass ="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text ="Select" Value ="Select" />
                                        <asp:ListItem Text ="Random1" Value ="Random1" />
                                        <asp:ListItem Text ="Random2" Value ="Random2" />
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <div class ="row">
                                    <label class="form-label">Author Name</label>
                                    <asp:DropDownList CssClass ="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text ="Select" Value ="Select" />
                                        <asp:ListItem Text ="Random1" Value ="Random1" />
                                        <asp:ListItem Text ="Random2" Value ="Random2" />
                                        
                                    </asp:DropDownList>
                                </div>
                                <div class ="row">
                                    <label class="form-label">Publish Date</label>
                                    <asp:TextBox CssClass ="form-control" placeholder ="Publish Date" ID="TextBox10" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <label class="form-label">Genre</label>
                                <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple">
                                    <asp:ListItem Text ="Fiction" Value ="Fiction" />
                                    <asp:ListItem Text ="Sci-fi" Value ="Sci-fi" />
                                    <asp:ListItem Text ="Motivation" Value ="Motivation" />
                                    <asp:ListItem Text ="Horror" Value ="Horror" />
                                    <asp:ListItem Text ="Romance" Value ="Romance" />
                                    <asp:ListItem Text ="Self-help" Value ="Self-help" />
                                    <asp:ListItem Text ="Fantasy" Value ="Fantasy" />
                                    <asp:ListItem Text ="Travel" Value ="Travel" />
                                    <asp:ListItem Text ="Short-story" Value ="Short-story" />
                                    <asp:ListItem Text ="Science" Value ="Science" />
                                    <asp:ListItem Text ="Journal" Value ="Journal" />
                                    <asp:ListItem Text ="History" Value ="History" />
                                    <asp:ListItem Text ="Fantasy" Value ="Fantasy" />
                                    <asp:ListItem Text ="Guide" Value ="Guide" />
                                    <asp:ListItem Text ="Encyclopedia" Value ="Encyclopedia" />
                                    <asp:ListItem Text ="Classic" Value ="Classic" />
                                    <asp:ListItem Text ="Business" Value ="Business" />
                                    <asp:ListItem Text ="Art" Value ="Art" />
                                    <asp:ListItem Text ="Thriller" Value ="Thriller" />



                                </asp:ListBox>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-4">
                                <label class="form-label">Edition</label>
                                <asp:TextBox CssClass="form-control" placeholder="Edition" ID="TextBox3" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-4">
                                <label class="form-label">Book cost/unit</label>
                                <asp:TextBox CssClass="form-control" placeholder="Book cost/unit" ID="TextBox4" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-4">
                                <label class="form-label">Pages</label>
                                <asp:TextBox CssClass="form-control" placeholder="Pages" ID="TextBox5" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-4">
                                <label class="form-label">Actual Stock</label>
                                <asp:TextBox CssClass="form-control" placeholder="Actual Stock" ID="TextBox6" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-4">
                                <label class="form-label">Current Stock</label>
                                <asp:TextBox CssClass="form-control" placeholder="Current Stock" ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class ="col-md-4">
                                <label class="form-label">Issued Books</label>
                                <asp:TextBox CssClass="form-control" placeholder="Issued Books" ID="TextBox8" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                       
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-4">
                                <div class="d-grid gap-2">
                                    <asp:Button CssClass="btn btn-success" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <div class="d-grid gap-2">
                                    <asp:Button CssClass="btn btn-info" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <div class="d-grid gap-2">
                                    <asp:Button CssClass="btn btn-danger" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class ="card">
                   <div class ="card-body">
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img width ="70" src="imgs/books/stackofbks.png" />
                                    <h3>Book List</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

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
                                                <div class ="container-fluid">
                                                    <div class ="row">
                                                        <div class ="col-lg-10">
                                                            <div class ="row">
                                                                <div class ="col-12">
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                                </div>
                                                            </div>
                                                            <div class ="row">
                                                                <div class="col">
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
    </div>
</asp:Content>
