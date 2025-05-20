<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.AddCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-white py-3 py-md-5">
        <div class="row justify-content-md-center">
            <div class="col-6">
                <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                    <h3 class="mb-5">Add Car Information</h3>
                    <div class="row">

                        <%-- Registered Date --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="date_regis" runat="server" Text="text">Registered Date</asp:Label>
                                    <asp:TextBox runat="server" type="date" CssClass="form-control form-control-lg" ID="date_regis" required="date_regis" />
                                </formview>
                            </div>
                        </div>

                        <%-- Registered No --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="txt_regisno" runat="server" Text="text">Registered No</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_regisno" required="txt_regisno" />
                                </formview>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <%-- Car's Price --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="num_car_price" runat="server" Text="text">Car's Price</asp:Label>
                                    <asp:TextBox runat="server" type="number" min="0" max="20000000" step="10000" CssClass="form-control form-control-lg" ID="num_car_price" required="num_car_price" />
                                </formview>
                            </div>
                        </div>

                        <%-- Rent Price --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="num_car_rent" runat="server" Text="text">Rent Price</asp:Label>
                                    <asp:TextBox runat="server" type="number" min="0" max="10000" step="1000" CssClass="form-control form-control-lg" ID="num_car_rent" required="num_car_rent" />
                                </formview>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <%-- Car Register Book --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="txt_car_regis" runat="server" Text="text">Car Register Book</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_car_regis" required="txt_car_regis" />
                                </formview>
                            </div>
                        </div>

                        <%-- Car's Owners --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="txt_owner" runat="server" Text="text">Car's Owners</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_owner" required="txt_owner" />
                                </formview>
                            </div>
                        </div>
                    </div>

                    <div class="row">

                        <%-- Brand --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <asp:Label for="brand_list" runat="server" Text="text">Car's Brand</asp:Label>
                                <asp:DropDownList ID="brand_list" runat="server"
                                    CssClass="form-select form-control form-control-lg" DataTextField="Text" DataValueField="value">
                                    <asp:ListItem Text="--- Select Car Brand ---" />
                                    <asp:ListItem Text="Benz" Value="Benz" />
                                    <asp:ListItem Text="BMW" Value="BMW" />
                                    <asp:ListItem Text="Toyota" Value="Toyota" />
                                    <asp:ListItem Text="Honda" Value="Honda" />
                                </asp:DropDownList>
                            </div>
                        </div>

                        <%-- Model --%>
                        <div class="col-md-6 mb-4">
                            <div class="form-outline">
                                <formview class="was-validated">
                                    <asp:Label for="txt_model" runat="server" Text="text">Car's Model</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_model" required="txt_model" />
                                </formview>
                            </div>
                        </div>
                    </div>

                    <%-- Chassis No --%>
                    <div class="form-outline mb-4">
                        <formview class="was-validated">
                            <asp:Label for="txt_chassis_no" runat="server" Text="text">Chassis No</asp:Label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control form-control-lg" ID="txt_chassis_no" required="txt_chassis_no" />
                        </formview>
                    </div>

                    <%-- Upload Car Image --%>
                    <div class="form-outline mb-4">
                        <formview class="was-validated">
                            <asp:Label for="txt_car_image" runat="server" Text="text">Upload Car Image</asp:Label>
                            <asp:FileUpload ID="txt_car_image" runat="server" class="form-control form-control-lg" required="txt_car_image" />
                        </formview>
                    </div>

                    <br />

                    <%-- Car Fuel --%>
                    <div class="dropdown col-md-4 mb-4">
                        <asp:Label for="fuel_list" runat="server" Text="text">Car's Fuel</asp:Label>
                        <asp:DropDownList ID="fuel_list" runat="server"
                            CssClass="form-select" DataTextField="Text" DataValueField="value">
                            <asp:ListItem Text="--- Select Car Fuel ---" />
                            <asp:ListItem Text="Diesel" Value="Diesel" />
                            <asp:ListItem Text="Benzin" Value="Benzin" />
                            <asp:ListItem Text="EV" Value="EV" />
                        </asp:DropDownList>
                    </div>

                    <%-- Car Type --%>
                    <div class="dropdown col-md-4 mb-4">
                        <asp:Label for="type_list" runat="server" Text="text">Car's Type</asp:Label>
                        <asp:DropDownList ID="type_list" runat="server"
                            CssClass="form-select" DataTextField="Text" DataValueField="value">
                            <asp:ListItem Text="--- Select Car Type ---" />
                            <asp:ListItem Text="Sedan" Value="Sedan" />
                            <asp:ListItem Text="SUV" Value="SUV" />
                            <asp:ListItem Text="Sport" Value="Sport" />
                        </asp:DropDownList>
                    </div>

                    <%-- Car Color --%>
                    <div class="dropdown col-md-4 mb-4">
                        <asp:Label for="color_list" runat="server" Text="text">Car's Color</asp:Label>
                        <asp:DropDownList ID="color_list" runat="server"
                            CssClass="form-select" DataTextField="Text" DataValueField="value">
                            <asp:ListItem Text="--- Select Car Color ---" />
                            <asp:ListItem Text="Black" Value="Black" />
                            <asp:ListItem Text="White" Value="White" />
                            <asp:ListItem Text="Grey" Value="Grey" />
                        </asp:DropDownList>
                    </div>


                    <div class="dropdown col-md-6 mb-4"></div>

                    <%-- Car Status --%>
                    <div class="dropdown col-md-4 mb-4">
                        <asp:Label for="status_list" runat="server" Text="text">Car's Status</asp:Label>
                        <asp:DropDownList ID="status_list" runat="server"
                            CssClass="form-select" DataTextField="Text" DataValueField="value">
                            <asp:ListItem Text="--- Select Car Status ---" />
                            <asp:ListItem Text="Ready" Value="Ready" />
                            <asp:ListItem Text="Not Ready (For Edit Info)" Value="Not Ready" />
                            <asp:ListItem Text="Reserved" Value="Reserved" />
                            <asp:ListItem Text="Repaired" Value="Repaired" />
                        </asp:DropDownList>
                    </div>

                </div>

                <%-- Add Car Button --%>
                <div class="container">
                    <div class="text-center">
                        <asp:Button ID="add_car" runat="server"
                            CssClass="btn btn-success btn-lg"
                            Text="Add Car"
                            OnClick="add_car_Click" />
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
