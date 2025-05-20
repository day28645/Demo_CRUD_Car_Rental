<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.AddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="bg-light py-3 py-md-5">
        <div class="container">
            <div class="col">
                <div class="row justify-content-center">
                    <div class="col-xl-6">
                        <div class="bg-light p-4 p-md-5 rounded shadow-sm">
                            <h3 class="mb-5">Location Registration</h3>

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

                            <%-- address --%>
                            <div class="form-outline mb-4">
                                <formview class="was-validated">
                                    <asp:Label for="txt_address" runat="server" Text="text">Address</asp:Label>
                                    <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txt_address" required="txt_address" />
                                </formview>
                            </div>

                            <%-- add location button --%>
                            <div class="container">
                                <div class="text-center">
                                    <asp:Button class="btn btn-success btn-lg" ID="add_location" runat="server"
                                        Text="Add Location"
                                        OnClick="add_location_Click" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <asp:GridView runat="server"
                ID="grid_location_list"
                CssClass="table"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Location_Id" HeaderText="Location ID" />
                    <asp:BoundField DataField="location_name" HeaderText="Location Name" />
                    <asp:BoundField DataField="location_address" HeaderText="Location Address" />
                    <asp:BoundField DataField="add_loc_datetime" HeaderText="Date and Time" />
                </Columns>
            </asp:GridView>
        </div>

    </div>

</asp:Content>
