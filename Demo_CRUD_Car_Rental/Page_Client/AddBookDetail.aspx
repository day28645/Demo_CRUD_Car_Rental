<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="AddBookDetail.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Client.AddBookDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12" style="padding-top: 50px">
                <div class="row">

                    <div class="mx-auto">
                        <div class="mb-5">
                            <h3>Booking Details</h3>
                        </div>

                        <%-- Select Location --%>
                        <h5 class="mb-3 text-dark">Location</h5>
                        <div class="row">
                            <%-- Pick Up --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text"><strong>Pick-Up Location</strong></asp:Label>
                                <asp:DropDownList ID="dp_pick_location" CssClass="form-select" runat="server"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="dp_pick_location_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <%-- Return --%>
                            <div class="col-md-6 mb-4">
                                <asp:Label runat="server" Text="text"><strong>Return Location</strong></asp:Label>
                                <asp:DropDownList ID="dp_return_location" CssClass="form-select" runat="server"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="dp_return_location_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <hr class="hr hr-blurry" />

                        <%-- Select Pick & Return Date + Time --%>
                        <h5 class="mb-3 text-dark">Date and Time</h5>
                        <%-- Pick-Up --%>
                        <div class="row">
                            <div class="col-md-4 mb-4">
                                <div class="form-outline">
                                    <asp:Label runat="server" for="txt_pick_datetime"><strong>Pick-Up</strong></asp:Label>
                                    <asp:TextBox runat="server" type="datetime-local" CssClass="form-control form-control-lg" ID="txt_pick_datetime"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Return --%>
                        <div class="row">
                            <div class="col-md-4 mb-4">
                                <div class="form-outline">
                                    <asp:Label runat="server" for="txt_return_datetime"><strong>Return</strong></asp:Label>
                                    <asp:TextBox runat="server" type="datetime-local" CssClass="form-control form-control-lg" ID="txt_return_datetime"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <hr class="hr hr-blurry" />

                        <%-- search car button  --%>
                        <div class="d-grid gap-2 col-4 mx-auto">
                            <asp:Button runat="server" ID="search_button"
                                CssClass="btn btn-success btn-lg"
                                Text="Search"
                                OnClick="search_button_Click" />
                        </div>
                    </div>



                </div>
            </div>
        </div>
    </div>

</asp:Content>
