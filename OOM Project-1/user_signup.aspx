<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="user_signup.aspx.cs" Inherits="OOM_Project_1.user_signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class ="container-fluid">
        <div class ="row">
            <div class ="col-md-6 mx-auto">
                <div class ="card">
                    <div class ="card-body">
                        <div class ="row">
                            <div class ="col">

                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img width ="90" src="imgs/New%20folder/user.png" />
                                </center>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <h3>User Registration</h3>
                                </center>
                            </div>
                        </div>
                        <div class ="row">
                            <div class ="col">
                                <hr />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-6">
                                <label class="form-label">Full Name</label>
                                <asp:TextBox placeholder="Full Name" CssClass ="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">DOB</label>
                                <asp:TextBox placeholder="DOB" CssClass ="form-control" ID="TextBox2" runat="server" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-6">
                                <label class="form-label">Contact No.</label>
                                <asp:TextBox placeholder="Contact No." CssClass="form-control" ID="TextBox3" runat="server" TextMode="Phone"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">Email</label>
                                <asp:TextBox placeholder="Email" CssClass="form-control" ID="TextBox4" runat="server" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>

                         <div class ="row">
                            <div class ="col-md-4">
                                <label class="form-label">City</label>
                                <asp:TextBox placeholder="City" CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                            </div>
                             <div class ="col-md-4">
                                 <label class="form-label">Pincode</label>
                                 <asp:TextBox placeholder="Pincode" CssClass="form-control" ID="TextBox6" runat="server" TextMode="Number"></asp:TextBox>
                            </div>
                             <div class ="col-md-4">
                                 <label class="form-label">State</label>
                                 <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                     <asp:ListItem Text ="Select" Value="Select"/>
                                     <asp:ListItem Text ="Andra Pradesh" Value="Andra Pradesh"/>
                                     <asp:ListItem Text ="Assam" Value="Assam"/>
                                     <asp:ListItem Text ="Arunachal Pradesh" Value="Assam"/>
                                     <asp:ListItem Text ="Bihar" Value="Bihar"/>
                                     <asp:ListItem Text ="Chattisgarh" Value="Chattisgarh"/>
                                     <asp:ListItem Text ="Goa" Value="Goa"/>
                                     <asp:ListItem Text ="Gujarat" Value="Gujarat"/>
                                     <asp:ListItem Text ="Haryana" Value="Haryana"/>
                                     <asp:ListItem Text ="Maharashtra" Value="Maharashtra"/>
                                     <asp:ListItem Text ="Sikkim" Value="Sikkim"/>
                                     <asp:ListItem Text ="Uttar Pradesh" Value="Uttar Pradesh"/>
                                     <asp:ListItem Text ="West Bengal" Value="West Bengal"/>

                                 </asp:DropDownList>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <label class="form-label">Address</label>
                                <asp:TextBox placeholder="Address" CssClass="form-control" ID="TextBox7" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <br />
                                <hr />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col-md-6">
                                <label class="form-label">UID</label>
                                <asp:TextBox placeholder="UID" CssClass="form-control" ID="TextBox8" runat="server"></asp:TextBox>
                            </div>
                            <div class ="col-md-6">
                                <label class="form-label">Password</label>
                                <asp:TextBox placeholder="Password" CssClass="form-control" ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>

                         <div class ="row">
                            <div class ="col">
                               <br />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <div class="d-grid gap-2">
                                    <asp:Button class ="btn btn-success" ID="Button1" runat="server" Text="Sign-up" OnClick="Button1_Click" />
                                    <asp:Button CssClass="btn btn-info" ID="Button2" runat="server" Text="Back to Login" OnClick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
