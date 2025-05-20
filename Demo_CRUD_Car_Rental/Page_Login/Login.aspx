<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Login.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Login 2 - Bootstrap Brain Component -->
    <div class="bg-white py-3 py-md-5">
        <div class="container">
            <div class="row justify-content-md-center">
                <div class="col-12 col-md-11 col-lg-8 col-xl-7 col-xxl-6">
                    <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                        <div class="row">
                            <div class="col-12">
                                <div class="mb-5">
                                    <h3>Login</h3>
                                </div>
                            </div>
                        </div>

                        <div class="row gy-3 gy-md-4 overflow-hidden">

                            <%-- id card --%>
                            <div class="col-12">
                                <formview class="was-validated">
                                    <asp:Label ID="idcard" runat="server" Text="text">ID Card</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control is-invalid" ID="txt_idcard" required="txt_idcard" />
                                </formview>
                            </div>

                            <%-- password --%>
                            <div class="col-12">
                                <formview class="was-validated">
                                    <asp:Label ID="password" runat="server" Text="text">Password</asp:Label>
                                    <asp:TextBox runat="server" type="password" CssClass="form-control is-invalid" ID="pass_password" required="password" />
                                </formview>
                            </div>

                            <div class="col-12"></div>

                            <%-- login button --%>
                            <div class="col-12">
                                <div class="d-grid">
                                    <asp:Button ID="login_button" runat="server"
                                        Text="Login"
                                        OnClick="login_button_Click"
                                        CssClass="btn btn-lg btn-primary"
                                        type="submit" />
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="p-2 g-col-6">
                        <h4>Dont't have an account? For Client Please

                            <asp:LinkButton 
                                ID="new_account_client" 
                                runat="server"
                                PostBackUrl="~/Page_Register/Register_Client.aspx">Register</asp:LinkButton>

                        </h4> 
                    </div>

                    <div class="p-2 g-col-6">
                        <h4>Dont't have an account? For Employee Please

                            <asp:LinkButton 
                                ID="new_account_employee" 
                                runat="server"
                                PostBackUrl="~/Page_Register/Register.aspx">Register</asp:LinkButton>

                        </h4> 
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
