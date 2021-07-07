<%@ Page Title="" Language="C#" MasterPageFile="~/master_page(web form).Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="OOM_Project_1.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--section1 top image--%>
    <section>
        <img class="img-fluid" src="imgs/New%20folder/LIB2.png" />
    </section>

    <%--section2 contents--%>
    <section>
        <div class ="row">
            <div class ="col">
                <br />
            </div>
        </div>
        <div class ="container">
            <div class ="row">
                <div class ="col">
                    <center>
                        <div class ="row">
                            <div class ="col set-bold">
                                <h2>Simple 3 step process</h2>
                                <br />
                               
                            </div>
                        </div>
                    </center>
                </div>
            </div>

            <div class ="row">

                <div class ="col md-4">
                    <div class ="card">
                        <div class ="card-body">
                            <center>
                                <img width ="150" src="imgs/New%20folder/sign%20up.png" />
                            <h4>Sign Up</h4>
                            <p class ="text-justify">

                            </p>
                            </center>
                        </div>
                    </div>
                </div>

                <div class ="col md-4">
                    <div class ="card">
                        <div class ="card-body">
                            <center>

                            <img width="150" src="imgs/New%20folder/book-160876_640.png" />
                            <h4>Search Book</h4>
                            <p class ="text-justify"></p>
                            </center>
                        </div>
                    </div>
                </div>

                <div class ="col md-4">
                    <div class ="card">
                        <div class ="card-body">
                            <center>
                                <img width="150" src="imgs/New%20folder/visit%20us.png" />
                            <h4>Visit Library</h4>
                            <p class ="text-justify"></p>
                            </center>
                        </div>
                    </div>
                </div>
             </div>
        </div>
    </section>

    <%--section3 image--%>
    <section>
        <div class ="row">
            <div class ="col">
                <br />
            </div>
        </div>
        <img class ="img-fluid" src="imgs/New%20folder/L2.png" />
    </section>


    
</asp:Content>
