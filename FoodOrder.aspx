<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodOrder.aspx.cs" Inherits="OrderManagementApp.FoodOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-5">

        <!-- Page Header -->
        <div class="text-center mb-5">
            <h2 class="fw-bold text-success">Place Food Order</h2>
            <p class="text-muted">Select your meal and complete your order</p>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-6">

                <div class="card shadow-lg border-0 rounded-4">
                    <div class="card-body p-4">

                        <!-- Main Category -->
                        <div class="mb-3">
                            <asp:Label Text="Main Category:" runat="server" 
                                CssClass="form-label fw-semibold" />
                            <asp:DropDownList ID="ddlMainCategory" runat="server"
                                CssClass="form-select"
                                AutoPostBack="true"
                                OnSelectedIndexChanged="ddlMainCategory_SelectedIndexChanged" />
                        </div>

                        <!-- Sub Category -->
                        <div class="mb-3">
                            <asp:Label Text="Sub Category:" runat="server"
                                CssClass="form-label fw-semibold" />
                            <asp:DropDownList ID="ddlSubCategory" runat="server"
                                CssClass="form-select"
                                AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" />
                        </div>

                         <!-- Price -->
                        <div class="mb-3">
                            <asp:Label Text="Price:" runat="server"
                                CssClass="form-label fw-semibold" />
                             <asp:TextBox ID="txtPrice" runat="server"
                                CssClass="form-control bg-light"
                                ReadOnly="true" />
                        </div>

                        <!-- Quantity -->
                        <div class="mb-3">
                            <asp:Label Text="Quantity:" runat="server"
                                CssClass="form-label fw-semibold" />
                            <asp:TextBox ID="txtQuantity" runat="server"
                                CssClass="form-control"
                                AutoPostBack="true"
                                OnTextChanged="txtQuantity_TextChanged" />
                        </div>

                       

                        <!-- Total -->
                        <div class="mb-4">
                            <asp:Label Text="Total Amount:" runat="server"
                                CssClass="form-label fw-bold text-primary" />
                            <asp:TextBox ID="txtTotal" runat="server"
                                CssClass="form-control bg-light fw-bold"
                                ReadOnly="true" />
                        </div>

                        <asp:Button ID="btnConfirmOrder" 
                            runat="server" 
                            Text="Confirm Order" 
                            CssClass="btn btn-success mt-3"
                            OnClick="btnConfirmOrder_Click" />

                        </div>
                </div>

            </div>
        </div>

    </div>
	

</asp:Content>
