<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="book_issuing.aspx.cs" Inherits="OOM_Project_1.book_issuing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class ="container-fluid">

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
                                    <img width="90" src="imgs/books/book.png" />
                                    <h3>Book issuing</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class ="col-md-6">
                                <label class="form-label">UID</label>
                                <asp:TextBox CssClass="form-control" placeholder ="UID" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">Book ID</label>
                                <div class ="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="Book ID" ID="TextBox2" runat="server"></asp:TextBox>
                                    <asp:Button CssClass="form-control btn btn-info" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class ="col-md-6">
                                <label class="form-label">User name</label>
                                <asp:TextBox CssClass="form-control" placeholder="User name" ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">Book name</label>
                                <asp:TextBox CssClass="form-control" placeholder="Book name" ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class ="col-md-6">
                                <label class="form-label">Start Date</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">End Date</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class="row">
                            <div class ="col-md-6">
                                <div class ="d-grid gap-2">
                                    <asp:Button CssClass="btn btn-success" ID="Button2" runat="server" Text="Issue" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <div class ="col-md-6">
                                <div class ="d-grid gap-2">
                                   <asp:Button CssClass="btn btn-warning" ID="Button3" runat="server" Text="Return" OnClick="Button3_Click" />
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
                                    <h3>Issued book List</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OOM_Project_library_managementConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="UID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="User name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due date" SortExpression="due_date" />
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
