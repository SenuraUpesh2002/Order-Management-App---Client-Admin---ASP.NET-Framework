<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerDashboard.aspx.cs" Inherits="OrderManagementApp.ManagerDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-5">

        <!-- Page Header -->
        <div class="text-center mb-5">
            <h2 class="fw-bold text-danger">Manager Dashboard</h2>
            <p class="text-muted">Manage Categories and Food Items</p>
            <hr />
        </div>

        <div class="row g-4">

            <!-- Add Main Category Card -->
            <div class="col-md-6">
                <div class="card shadow-lg border-0 rounded-4 h-100">
                    <div class="card-body p-4">

                        <h4 class="fw-semibold mb-4 text-primary">
                            Add Main Category
                        </h4>

                        <div class="mb-3">
                            <asp:TextBox ID="txtMainCategory"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Enter Main Category Name">
                            </asp:TextBox>
                        </div>

                        <div class="d-grid">
                            <asp:Button ID="btnAddMain"
                                runat="server"
                                Text="Add Category"
                                CssClass="btn btn-primary btn-lg rounded-3"
                                OnClick="btnAddMain_Click" />
                        </div>

                    </div>
                </div>
            </div>

            <!-- Add Sub Category Card -->
            <div class="col-md-6">
                <div class="card shadow-lg border-0 rounded-4 h-100">
                    <div class="card-body p-4">

                        <h4 class="fw-semibold mb-4 text-success">
                            Add Sub Category
                        </h4>

                        <div class="mb-3">
                            <asp:DropDownList ID="ddlMainCategory"
                                runat="server"
                                CssClass="form-select">
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3">
                            <asp:TextBox ID="txtSubCategory"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Sub Category Name">
                            </asp:TextBox>
                        </div>

                        <div class="mb-3">
                            <asp:TextBox ID="txtPrice"
                                runat="server"
                                CssClass="form-control"
                                Placeholder="Price">
                            </asp:TextBox>
                        </div>

                        <div class="d-grid">
                            <asp:Button ID="btnAddSub"
                                runat="server"
                                Text="Add Sub Category"
                                CssClass="btn btn-success btn-lg rounded-3"
                                OnClick="btnAddSub_Click" />
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <!-- Message Section -->
        <div class="text-center mt-4">
            <asp:Label ID="lblMessage"
                runat="server"
                CssClass="fw-bold fs-5">
            </asp:Label>
        </div>

    </div>

    <h3>Inventory Upload</h3>

<div class="row mt-5">
    <div class="col-md-8 offset-md-2">

        <div class="card shadow-lg border-0 rounded-4">
            <div class="card-body p-4">

                <h4 class="fw-semibold text-warning mb-3 text-center">
                    Inventory Upload
                </h4>

                <p class="text-muted text-center mb-4">
                    Upload inventory using Excel (.xlsx) file
                </p>

                <div class="mb-3">
                    <asp:FileUpload ID="fileUploadExcel"
                        runat="server"
                        CssClass="form-control" />
                </div>

                <div class="d-grid">
                    <asp:Button ID="btnUpload"
                        runat="server"
                        Text="Upload Excel File"
                        CssClass="btn btn-warning btn-lg rounded-3"
                        OnClick="btnUpload_Click" />
                </div>

                <%--<div class="text-center mt-3">--%>
                    <asp:Label ID="Label1"
                        runat="server"
                        CssClass="fw-bold">
                    </asp:Label>
                </div>

            </div>
        </div>

    </div>
</div>

</asp:Content>
