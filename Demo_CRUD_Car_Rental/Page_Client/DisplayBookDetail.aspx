<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="DisplayBookDetail.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Client.DisplayBookDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container py-5">
        <div class="row">
            <div class="col-md-6">
                <div class="pro-img-details">
                    <asp:Image runat="server" ID="image_db" ImageUrl='<%# Eval("image") %>' Height="400px" Width="400px" />
                </div>
            </div>

            <div class="col-md-6 col-lg-6 col-xl-4">
                <div class="container">

                    <h5 class="mb-3 text-dark">Location</h5>
                    <div class="row">
                        <%-- Pick Up --%>
                        <div class="col-md-6 mb-4">
                            <asp:Label runat="server"><strong>Pick-Up Location</strong></asp:Label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_pick_location" disabled></asp:TextBox>
                        </div>
                        <%-- Return --%>
                        <div class="col-md-6 mb-4">
                            <asp:Label runat="server"><strong>Return Location</strong></asp:Label>
                            <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_return_location" disabled></asp:TextBox>
                        </div>
                    </div>

                    <hr class="hr hr-blurry" />

                    <%-- Select Pick & Return Date + Time --%>
                    <h5 class="mb-3 text-dark">Date and Time</h5>
                    <%-- Pick-Up --%>
                    <div class="row">
                        <div class="col-md-8 mb-4">
                            <div class="form-outline">
                                <asp:Label runat="server" for="txt_pickdatetime"><strong>Pick-Up</strong></asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_pickdatetime" disabled></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
                    <%-- Return --%>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-outline">
                                <asp:Label runat="server" for="txt_returndatetime"><strong>Return</strong></asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_returndatetime" disabled></asp:TextBox>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <formview class="row g-3">
            <div class="col-md-6">
                <hr class="hr hr-blurry" />
            </div>
            <div class="col-md-6">
                <hr class="hr hr-blurry" />
            </div>
        </formview>


        <formview class="row g-3">
            <div class="col-md-6 col-lg-6 col-xl-6">
                <!-- Car Status -->
                <div class="form-group row">
                    <asp:Label ID="txt_car_status"
                        Text="Car Status:"
                        AssociatedControlID="car_status_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="car_status_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />
            </div>

            <div class="col-md-6 col-lg-6 col-xl-6">
                <!-- Car Brand -->
                <div class="form-group row">
                    <asp:Label ID="txt_brand"
                        Text="Brand:"
                        AssociatedControlID="brand_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="brand_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />
            </div>


            <div class="col-md-6 col-lg-6 col-xl-6">
                <!-- Car Model -->
                <div class="form-group row">
                    <asp:Label ID="txt_model"
                        Text="Model:"
                        AssociatedControlID="model_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="model_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />

                <!-- Registered No -->
                <div class="form-group row">
                    <asp:Label ID="txt_regis_no"
                        Text="Registered No:"
                        AssociatedControlID="regis_no_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="regis_no_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />
            </div>

            <div class="col-md-6 col-lg-6 col-xl-6">
                <%-- Rent Price --%>
                <div class="form-group row">
                    <asp:Label ID="num_rent_price"
                        Text="Rent Price:"
                        AssociatedControlID="rent_price_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="rent_price_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />

                <!-- Total Price -->
                <div class="form-group row">
                    <asp:Label ID="num_total_price"
                        Text="Total Price:"
                        AssociatedControlID="total_price_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="total_price_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />

            </div>

            <div class="col-md-6 col-lg-6 col-xl-6">
                <!-- Duration -->
                <div class="form-group row">
                    <asp:Label ID="num_duration"
                        Text="Duration:"
                        AssociatedControlID="duration_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="duration_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />

                <!-- Book Status -->
                <div class="form-group row">
                    <asp:Label ID="book_status"
                        Text="Booking Status:"
                        AssociatedControlID="book_status_db"
                        class="col-3 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="book_status_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />
            </div>


            <div class="col-md-6 col-lg-6 col-xl-6">

                <!-- Book Date & Time -->
                <div class="form-group row">
                    <asp:Label ID="book_datetime"
                        Text="Booking Date & Time:"
                        AssociatedControlID="datetime_db"
                        class="col-4 col-form-label"
                        runat="server">
                    </asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="datetime_db" CssClass="h5 form-control-plaintext form-control-lg" runat="server" disabled />
                    </div>
                </div>
                <br />
            </div>
        </formview>
    </div>



</asp:Content>
