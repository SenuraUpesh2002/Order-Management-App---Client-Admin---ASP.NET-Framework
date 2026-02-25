<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="OrderManagementApp.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	 <div class="container mt-5">

        <div class="text-center mb-4">
            <h2 class="fw-bold text-primary">My Orders</h2>
            <p class="text-muted">View and manage your order history</p>
        </div>

        <div class="row justify-content-center mb-4">
            <div class="col-md-6">
                <asp:TextBox ID="txtSearch" runat="server"
                    CssClass="form-control form-control-lg shadow-sm"
                    placeholder="Search by Order Status">
                </asp:TextBox>
            </div>
        </div>

        <div class="card shadow-lg border-0 rounded-4 mb-5">
            <div class="card-body p-4">

                <div class="table-responsive">
                    <asp:GridView ID="gvOrders"
                        runat="server"
                        AutoGenerateColumns="False"
                        DataKeyNames="OrderID"
                        OnRowCommand="gvOrders_RowCommand"
                        CssClass="table table-hover align-middle">

                        <Columns>
                            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                            <asp:BoundField DataField="OrderStatus" HeaderText="Status" />
                            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" />
                            <asp:ButtonField Text="View Details"
                                CommandName="ViewDetails"
                                ButtonType="Button"
                                ControlStyle-CssClass="btn btn-sm btn-outline-primary" />
                        </Columns>

                        <HeaderStyle CssClass="table-dark" />
                    </asp:GridView>
                </div>

            </div>
        </div>

        <div class="card shadow-lg border-0 rounded-4">
            <div class="card-body p-4">

                <div class="table-responsive">
                    <asp:GridView ID="gvOrderItems"
                        runat="server"
                        CssClass="table table-striped table-bordered align-middle">
                    </asp:GridView>
                </div>

            </div>
        </div>

    </div>

</asp:Content>
