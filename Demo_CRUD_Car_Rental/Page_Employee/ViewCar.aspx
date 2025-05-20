<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="ViewCar.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.ViewCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-white py-3 py-md-5">
        <div class="row justify-content-md-center">
            <div class="col-6">
                <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                    <h3 class="mb-5">Car Information</h3>

                    <div class="container">

                        <%-- Registered Date --%>
                        <div class="form-group row">
                            <asp:Label for="date_regis" runat="server" class="col-3 col-form-label" Text="text">Registered Date :</asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="date" CssClass="form-control-plaintext" ID="date_regis" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Registered No --%>
                        <div class="form-group row">
                            <asp:Label for="txt_regisno" runat="server" class="col-3 col-form-label" Text="text">Registered No : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext" ID="txt_regisno" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Car's Price --%>
                        <div class="form-group row">
                            <asp:Label for="num_car_price" runat="server" class="col-3 col-form-label" Text="text">Car's Price : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="number" min="0" max="20000000" step="10000" CssClass="form-control-plaintext" ID="num_car_price" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Rent's Price --%>
                        <div class="form-group row">
                            <asp:Label for="num_car_rent" runat="server" class="col-3 col-form-label" Text="text">Rent's Price : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="number" min="0" max="10000" step="1000" CssClass="form-control-plaintext" ID="num_car_rent" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Car Register Book --%>
                        <div class="form-group row">
                            <asp:Label for="txt_car_regis" runat="server" class="col-3 col-form-label" Text="text">Car Register Book : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext" ID="txt_car_regis" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Car's Owners --%>
                        <div class="form-group row">
                            <asp:Label for="txt_owner" runat="server" class="col-3 col-form-label" Text="text">Car's Owners : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext" ID="txt_owner" disabled/>
                            </div>
                        </div>
                        <br />

                        <%-- Brand --%>
                        <div class="form-group row">
                            <asp:Label for="brand_list" runat="server" class="col-3 col-form-label" Text="text">Car's Brand : </asp:Label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="brand_list" runat="server" disabled
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Brand ---" />
                                    <asp:ListItem Text="Benz" Value="Benz" />
                                    <asp:ListItem Text="BMW" Value="BMW" />
                                    <asp:ListItem Text="Toyota" Value="Toyota" />
                                    <asp:ListItem Text="Honda" Value="Honda" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                        <%-- Model --%>
                        <div class="form-group row">
                            <asp:Label for="txt_model" runat="server" class="col-3 col-form-label" Text="text">Car's Model : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext" ID="txt_model" disabled  />
                            </div>
                        </div>
                        <br />

                        <%-- Chassis No --%>
                        <div class="form-group row">
                            <asp:Label for="txt_chassis_no" runat="server" class="col-3 col-form-label" Text="text">Chassis No : </asp:Label>
                            <div class="col-sm-4">
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext" ID="txt_chassis_no" disabled />
                            </div>
                        </div>
                        <br />

                        <%-- Car Fuel --%>
                        <div class="form-group row">
                            <asp:Label for="fuel_list" runat="server" class="col-3 col-form-label" Text="text">Car's Fuel : </asp:Label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="fuel_list" runat="server" disabled
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Fuel ---" />
                                    <asp:ListItem Text="Diesel" Value="Diesel" />
                                    <asp:ListItem Text="Benzin" Value="Benzin" />
                                    <asp:ListItem Text="EV" Value="EV" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                        <%-- Car Type --%>
                        <div class="form-group row">
                            <asp:Label for="type_list" runat="server" class="col-3 col-form-label" Text="text">Car's Type : </asp:Label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="type_list" runat="server" disabled
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Type ---" />
                                    <asp:ListItem Text="Sedan" Value="Sedan" />
                                    <asp:ListItem Text="SUV" Value="SUV" />
                                    <asp:ListItem Text="Sport" Value="Sport" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                        <%-- Car Color --%>
                        <div class="form-group row">
                            <asp:Label for="color_list" runat="server" class="col-3 col-form-label" Text="text">Car's Color : </asp:Label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="color_list" runat="server" disabled
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Color ---" />
                                    <asp:ListItem Text="Black" Value="Black" />
                                    <asp:ListItem Text="White" Value="White" />
                                    <asp:ListItem Text="Grey" Value="Grey" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                        <%-- Car Status --%>
                        <div class="form-group row">
                            <asp:Label for="status_list" runat="server" class="col-3 col-form-label" Text="text">Car's Status : </asp:Label>
                            <div class="col-sm-4">
                                <asp:DropDownList ID="status_list" runat="server" disabled
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Status ---" />
                                    <asp:ListItem Text="Ready" Value="Ready" />
                                    <asp:ListItem Text="Not Ready (For Edit Info)" Value="Not Ready" />
                                    <asp:ListItem Text="Reserved" Value="Reserved" />
                                    <asp:ListItem Text="Repaired" Value="Repaired" />
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
