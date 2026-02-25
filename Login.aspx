<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OrderManagementApp.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   <!--Master page & content section-->
	
   <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">

                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-body p-4">

                        <h2 class="text-center mb-4 fw-bold text-primary">
                            User Login
                        </h2>

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
                            <asp:Button ID="btnLogin" runat="server"
                                Text="Login"
                                OnClick="btnLogin_Click"
                                Width="120px"
                                CssClass="btn btn-success btn-lg rounded-3">
                            </asp:Button>
                        </div>

                        <!-- Navigation to Register -->
                        <div class="text-center mt-3">
                            <span>Don't have an account?</span>
                            <asp:HyperLink ID="hlRegister" runat="server"
                                NavigateUrl="~/Register.aspx"
                                CssClass="text-decoration-none fw-semibold text-primary">
                                Register here
                            </asp:HyperLink>
                        </div>

                        <div class="text-center mt-3">
                            <asp:Label ID="lblMessage" runat="server"
                                Font-Bold="true"
                                CssClass="fw-bold">
                            </asp:Label>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
