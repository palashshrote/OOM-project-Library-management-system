<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="publisher_management.aspx.cs" Inherits="OOM_Project_1.publisher_management" %>
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
                                    <img width="90" src="imgs/New%20folder/author.png" />
                                    <h3>Publisher Details</h3>
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
                                <label class="form-label">Publisher ID</label>
                                <div class ="input-group"> <%--to group them in 1 line--%>
                                    <asp:TextBox CssClass="form-control" placeholder="ID" ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:Button CssClass="form-control btn btn-info" ID="Button1" runat="server" Text="GO" OnClick="Button1_Click" />
                                </div>
                                
                            </div>
                            <div class ="col-md-9">
                                <label class="form-label">Publisher Name</label>
                                <asp:TextBox CssClass="form-control" placeholder="Publisher Name" ID="TextBox2" runat="server"></asp:TextBox>
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
                                    <h3>Publisher List</h3>
                                </center>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <hr />
                            </div>
                        </div>

                        <div class ="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OOM_Project_library_managementConnectionString %>" SelectCommand="SELECT * FROM [publisher_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView CssClass ="table table-bordered table-striped" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="publisher_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="publisher_id" HeaderText="publisher_id" ReadOnly="True" SortExpression="publisher_id" />
                                        <asp:BoundField DataField="publisher_name" HeaderText="publisher_name" SortExpression="publisher_name" />
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
