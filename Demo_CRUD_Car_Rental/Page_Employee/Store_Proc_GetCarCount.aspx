<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Store_Proc_GetCarCount.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.Store_Proc_GetCarCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-light py-3 py-md-5">
        <div class="container">
            <div class="col">
                <div class="row justify-content-center">
                    <div class="col-xl-6">
                        <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                            <h3 class="mb-5">Count Transaction By Car</h3>

                            <%-- chassis number --%>
                            <div class="row">
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">
                                        <formview class="was-validated">
                                            <asp:Label for="txt_chassis_no" runat="server" Text="text">Chassis No</asp:Label>
                                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txt_chassis_no" required="txt_chassis_no" />
                                        </formview>
                                    </div>
                                </div>
                            </div>

                            <%-- count result --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text">Total Count</asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_count_car" disabled></asp:TextBox>
                            </div>

                            <%-- count result --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text">Recent Date and Time</asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_datetime" disabled></asp:TextBox>
                            </div>

                            <%-- count car button --%>
                            <div class="container">
                                <div class="text-center">
                                    <asp:Button class="btn btn-success btn-lg" ID="count_car_transaction" runat="server"
                                        Text="Count Transaction"
                                        OnClick="count_car_transaction_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
