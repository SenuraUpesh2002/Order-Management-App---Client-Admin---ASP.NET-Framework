<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerDashboard.aspx.cs" Inherits="OrderManagementApp.CustomerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<div class="container mt-5">

        <!-- Dashboard Header -->
        <div class="text-center mb-5">
            <h2 class="fw-bold text-primary">Customer Dashboard</h2>
            <asp:Label ID="lblWelcome" runat="server" 
                CssClass="fs-4 fw-semibold text-secondary">
            </asp:Label>
        </div>

        <!-- Dashboard Options -->
        <asp:Panel ID="pnlOptions" runat="server">

            <div class="row justify-content-center g-4">

                <!-- View Products Card -->
                <div class="col-md-5">
                    <div class="card shadow-lg border-0 rounded-4 text-center p-4 h-100">

                        <div class="mb-3">
                            <i class="bi bi-bag-fill fs-1 text-success"></i>
                        </div>

                        <h5 class="fw-bold mb-3">Browse Products</h5>

                        <p class="text-muted">
                            Explore available food items and place your orders easily.
                        </p>

                        <asp:Button ID="btnViewProducts" runat="server"
                            Text="View Products"
                            Width="200px"
                            PostBackUrl="~/FoodOrder.aspx"
                            CssClass="btn btn-success btn-lg rounded-3 mt-3" />
                    </div>
                </div>

                <!-- My Orders Card -->
                <div class="col-md-5">
                    <div class="card shadow-lg border-0 rounded-4 text-center p-4 h-100">

                        <div class="mb-3">
                            <i class="bi bi-receipt-cutoff fs-1 text-primary"></i>
                        </div>

                        <h5 class="fw-bold mb-3">My Orders</h5>

                        <p class="text-muted">
                            View your order history and track current orders.
                        </p>

                        <asp:Button ID="btnMyOrders" runat="server"
                            Text="My Orders"
                            Width="200px"
                            PostBackUrl="~/MyOrders.aspx"
                            CssClass="btn btn-primary btn-lg rounded-3 mt-3" />
                    </div>
                </div>

            </div>

        </asp:Panel>

        <!-- Logout Section -->
        <div class="text-center mt-5">
            <asp:Button ID="btnLogout" runat="server"
                Text="Logout"
                Width="120px"
                OnClick="btnLogout_Click"
                CssClass="btn btn-outline-danger rounded-3 px-4" />
        </div>

    </div>

</asp:Content>
