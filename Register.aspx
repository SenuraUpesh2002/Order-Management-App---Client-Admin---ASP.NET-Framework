<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OrderManagementApp.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">

                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-body p-4">

                        <main aria-labelledby="title">

                            <h2 class="text-center mb-4 fw-bold text-primary">
                                User Registration
                            </h2>

                            <div class="mb-3">
                                <asp:Label ID="lblName" runat="server" 
                                    Text="Full Name:"
                                    CssClass="form-label fw-semibold">
                                </asp:Label>

                                <asp:TextBox ID="txtName" runat="server"
                                    Width="250px"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server"
                                    Text="Email:"
                                    CssClass="form-label fw-semibold">
                                </asp:Label>

                                <asp:TextBox ID="txtEmail" runat="server"
                                    Width="250px"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </div>

                            <div class="mb-4">
                                <asp:Label ID="lblPassword" runat="server"
                                    Text="Password:"
                                    CssClass="form-label fw-semibold">
                                </asp:Label>

                                <asp:TextBox ID="txtPassword" runat="server"
                                    TextMode="Password"
                                    Width="250px"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </div>

                            <div class="d-grid mb-3">
                                <asp:Button ID="btnRegister" runat="server"
                                    Text="Register"
                                    OnClick="btnRegister_Click"
                                    Width="120px"
                                    CssClass="btn btn-primary btn-lg rounded-3">
                                </asp:Button>
                            </div>

                            <div class="text-center mt-3">
                            <span>Already have an account?</span>
                             <asp:HyperLink ID="hlLogin" runat="server" 
                                NavigateUrl="~/Login.aspx"
                                CssClass="text-decoration-none fw-semibold text-primary">
                                        Login here
                             </asp:HyperLink>
                            </div>


                            <div class="text-center">
                                <asp:Label ID="lblMessage" runat="server"
                                    Font-Bold="true"
                                    CssClass="fw-bold">
                                </asp:Label>
                            </div>

                        </main>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
