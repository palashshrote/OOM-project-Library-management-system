<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="author_management.aspx.cs" Inherits="OOM_Project_1.author_management" %>
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
            <div class ="col-md-5">
                <div class ="card">
                    <div class ="card-body">
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img width="90" src="imgs/New%20folder/auhtor_updated.png" />
                                    <h3>Author Details</h3>
                                </center>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col-md-3">
                                <label class="form-label">Author ID</label>
                                <div class ="input-group"> <%--to group them in 1 line--%>
                                    <asp:TextBox CssClass="form-control" placeholder="ID" ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:Button CssClass="form-control btn btn-info" ID="Button1" runat="server" Text="GO" OnClick="Button1_Click" />
                                </div>
                                
                            </div>
                            <div class ="col-md-9">
                                <label class="form-label">Author Name</label>
                                <asp:TextBox CssClass="form-control" placeholder="Author Name" ID="TextBox2" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>


                        <div class ="row">
                            
                            <div class ="col-md-4">
                                <div class ="d-grid gap-2">
                                   <asp:Button CssClass ="btn btn-success" ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <div class="d-grid gap-2">
                                    <asp:Button CssClass ="btn btn-primary" ID="Button3" runat="server" Text="Update" OnClick="Button3_Click" />
                                </div>
                            </div>
                            <div class ="col-md-4">
                                <div class="d-grid gap-2">
                                    <asp:Button CssClass ="btn btn-danger" ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
                                </div>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div class ="col-md-7">
                <div class ="card">
                    <div class ="card-body">
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img width="90" src="imgs/New%20folder/list%20A-P.png" />
                                    <h3>Author List</h3>
                                </center>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <hr />
                            </div>
                        </div>

                        <div class ="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OOM_Project_library_managementConnectionString %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView CssClass ="table table-bordered table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class ="row">
            <div class ="col">
                <br />
            </div>
        </div>

    </div>
</asp:Content>
