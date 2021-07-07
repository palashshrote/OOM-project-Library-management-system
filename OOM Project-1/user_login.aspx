<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="user_login.aspx.cs" Inherits="OOM_Project_1.user_login" %>
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
            <div class ="col-md-6 mx-auto"> <%--mx auto for centering--%>
                <div class ="card">
                    <div class ="card-body">
                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <img width="150" src="imgs/New%20folder/user.png" />
                                </center>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <center>
                                    <h2>User Login</h2>
                                </center>
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                               <hr />
                            </div>
                        </div>

                        <div class ="row">
                            <div class ="col">
                                <label class="form-label">UID</label>
                                <asp:TextBox CssClass="form-control" placeholder ="UID" ID="TextBox8" runat="server"></asp:TextBox>
                                <br />
                                <label class="form-label">Password</label>
                                <asp:TextBox CssClass="form-control" placeholder="Password" ID="TextBox9" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                            </div>
                        </div>

                        <div class="d-grid gap-2">
                            <asp:Button CssClass ="btn btn-success" ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
                            <asp:Button CssClass ="btn btn-info" ID="Button2" runat="server" Text="Sign-up" OnClick="Button2_Click" />
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
