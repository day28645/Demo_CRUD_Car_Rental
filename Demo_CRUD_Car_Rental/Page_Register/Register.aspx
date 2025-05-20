<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Register.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Registration 6 - Bootstrap Brain Component -->
    <div class="bg-white py-3 py-md-5">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-12 col-md-9 col-lg-7 col-xl-6 col-xxl-5">
                    <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                        <div class="row">
                            <div class="col-12">
                                <div class="mb-5">
                                    <h2 class="h3">Registration Employee</h2>
                                    <h3 class="fs-6 fw-normal text-secondary m-0">Enter Your Details To Register</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row gy-3 overflow-hidden">
                            <%-- id card --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="txt_idcard" runat="server" Text="text">ID Card</asp:Label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control is-invalid" ID="txt_idcard" required="txt_idcard" />
                                    </formview>
                                </div>
                            </div>

                            <%-- firstname --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="txt_firstname" runat="server" Text="text">First Name</asp:Label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control is-invalid" ID="txt_firstname" required="txt_firstname" />
                                    </formview>
                                </div>
                            </div>

                            <%-- lastname --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="txt_lastname" ID="lastname" runat="server" Text="text">Last Name</asp:Label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control is-invalid" ID="txt_lastname" required="txt_lastname" />
                                    </formview>
                                </div>
                            </div>

                            <%-- email --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="mail_email" ID="email" runat="server" Text="text">Email</asp:Label>
                                        <asp:TextBox runat="server" type="email" CssClass="form-control is-invalid" ID="mail_email" required="mail_email" />
                                    </formview>
                                </div>
                            </div>

                            <%-- password --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="pass_password" ID="password" runat="server" Text="text">Password</asp:Label>
                                        <asp:TextBox runat="server" type="password" CssClass="form-control is-invalid" ID="pass_password" required="pass_password" />
                                    </formview>
                                </div>
                            </div>

                            <%-- address --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="txt_address" ID="address" runat="server" Text="text">Address</asp:Label>
                                        <asp:TextBox runat="server" type="text" CssClass="form-control is-invalid" ID="txt_address" required="txt_address" />
                                    </formview>
                                </div>
                            </div>

                            <%-- phone --%>
                            <div class="col-12">
                                <div class="form-floating mb-3">
                                    <formview class="was-validated">
                                        <asp:Label for="tel_phone" ID="phone" runat="server" Text="text">Phone</asp:Label>
                                        <asp:TextBox runat="server" type="tel" CssClass="form-control is-invalid" ID="tel_phone" required="tel_phone" />
                                    </formview>
                                </div>
                            </div>

                            <%-- select position by change index --%>
                            <div class="col-md-6 pt-2">
                                <div class="input-group input-group-outline my-3">
                                    <asp:DropDownList ID="dp_position" CssClass="form-select" runat="server"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="dp_position_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <%-- register button --%>
                            <div class="col-12">
                                <div class="d-grid">
                                    <asp:Button ID="register_button" runat="server"
                                        class="btn btn-lg btn-primary"
                                        Text="Register"
                                        OnClick="register_button_Click" />
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
