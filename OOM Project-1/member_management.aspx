<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="member_management.aspx.cs" Inherits="OOM_Project_1.member_management" %>
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
                                    <img width="90" src="imgs/New%20folder/user.png" />
                                    <h3>User Details</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class="col-md-3">
                                <label class="form-label">UID</label>
                                <div class ="input-group">
                                    <asp:TextBox CssClass="form-control" placeholder="UID" ID="TextBox1" runat="server"></asp:TextBox>
                                    <asp:Button CssClass="form-control btn btn-info" ID="Button1" runat="server" Text="Go" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">User Name</label>
                                <asp:TextBox CssClass="form-control" placeholder="User Name" ID="TextBox2" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label class="form-label">Account status</label>
                                <div class ="input-group">

                                    <asp:TextBox CssClass="form-control" placeholder="status" ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:LinkButton CssClass="form-control btn btn-success" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="form-control btn btn-warning" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                    <asp:LinkButton CssClass="form-control btn btn-danger" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class="col-md-3">
                                <label class="form-label">DOB</label>
                                <asp:TextBox CssClass="form-control" placeholder="DOB" ID="TextBox4" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Contact No</label>
                                <asp:TextBox CssClass="form-control" placeholder="Contact No" ID="TextBox5" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label class="form-label">Email</label>
                                <asp:TextBox CssClass="form-control" placeholder="Email" ID="TextBox6" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class="col-md-3">
                                <label class="form-label">City</label>
                                <asp:TextBox CssClass="form-control" placeholder="City" ID="TextBox7" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Pincode</label>
                                <asp:TextBox CssClass="form-control" placeholder="Pincode" ID="TextBox8" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="col-md-5">
                                <label class="form-label">State</label>
                                <asp:TextBox CssClass="form-control" placeholder="State" ID="TextBox9" runat="server" ReadOnly="True"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <label class="form-label">Address</label>
                                <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class="d-grid gap-2">
                            <asp:Button CssClass="btn btn-danger" ID="Button2" runat="server" Text="Delete User Permantely" OnClick="Button2_Click" />
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
                                    <h3>User List</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class ="col">
                                <br />
                            </div>
                        </div>

                        <div class ="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OOM_Project_library_managementConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class ="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="UID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No." SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
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
