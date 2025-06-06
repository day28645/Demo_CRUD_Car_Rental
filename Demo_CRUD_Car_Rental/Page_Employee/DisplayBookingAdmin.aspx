﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DisplayBookingAdmin.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.DisplayBookingAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12" style="padding-top: 50px">

                <div class="h2 d-flex align-items-center justify-content-center">
                    View Booking
                </div>

                <div class="row">

                    <div class="col-sm-4_border">
                        <div class="mb-5">
                            <h3>Booking Details</h3>
                        </div>

                        <%-- Select Location --%>
                        <h5 class="mb-3 text-dark">Location</h5>
                        <div class="row">
                            <%-- Pick Up --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text"><strong>Pick-Up Location</strong></asp:Label>
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_pick_location" disabled></asp:TextBox>
                            </div>
                            <%-- Return --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text"><strong>Return Location</strong></asp:Label>
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
                            <div class="col-md-8 mb-4">
                                <div class="form-outline">
                                    <asp:Label runat="server" for="txt_returndatetime"><strong>Return Date</strong></asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext form-control-lg" ID="txt_returndatetime" disabled></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <hr class="hr hr-blurry" />

                    </div>

                    <%-- booking detail --%>
                    <div class="col-lg-8">

                        <div class="project-info-box">
                            <div class="form-group row">
                                <asp:Label runat="server" for="txt_bookid" class="col-3 col-form-label"><strong>Booking ID : </strong></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_bookid" disabled></asp:TextBox>
                                </div>
                            </div>
                            <br />

                            <div class="form-group row">
                                <asp:Label runat="server" for="txt_book_datetime" class="col-4 col-form-label"><strong>Booking Date & Time : </strong></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_book_datetime" disabled></asp:TextBox>
                                </div>
                            </div>

                            <br />

                            <div class="form-group row">
                                <asp:Label runat="server" for="txt_book_status" class="col-3 col-form-label"><strong>Booking Status : </strong></asp:Label>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_book_status" disabled></asp:TextBox>
                                </div>
                            </div>
                            <br />
                        </div>

                        <%-- client detail --%>
                        <div class="project-info-box">
                            <h4>Client Name</h4>
                            <div class="form-group row">
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_firstname" disabled></asp:TextBox>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_lastname" disabled></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%-- car detail --%>
                        <div class="project-info-box">
                            <p>
                                <b>Car Status :</b>
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_car_status" disabled></asp:TextBox>
                            </p>

                            <p>
                                <b>Registered No. :</b>
                                <asp:TextBox runat="server" type="text" CssClass="form-control-plaintext h4" ID="txt_regis_no" disabled></asp:TextBox>
                            </p>
                        </div>

                    </div>


                </div>
            </div>
        </div>
    </div>

</asp:Content>
