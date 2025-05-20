<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="Store_Proc_GetCountPickLocation.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.Store_Proc_GetCountPickLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-light py-3 py-md-5">
        <div class="container">
            <div class="col">
                <div class="row justify-content-center">
                    <div class="col-xl-6">
                        <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                            <h3 class="mb-5">Count Pick-Up Location</h3>

                            <%-- location name --%>
                            <div class="row">
                                <div class="col-md-6 mb-4">
                                    <div class="form-outline">
                                        <formview class="was-validated">
                                            <asp:Label for="txt_locname" runat="server" Text="text">Location Name</asp:Label>
                                            <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txt_locname" required="txt_locname" />
                                        </formview>
                                    </div>
                                </div>
                            </div>

                            <%-- count result --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text">Count Pick Location</asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_pick_location" disabled></asp:TextBox>
                            </div>

                            <%-- count pick location button --%>
                            <div class="container">
                                <div class="text-center">
                                    <asp:Button class="btn btn-success btn-lg" ID="pick_location" runat="server"
                                        Text="Count Pick-Up"
                                        OnClick="pick_location_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
