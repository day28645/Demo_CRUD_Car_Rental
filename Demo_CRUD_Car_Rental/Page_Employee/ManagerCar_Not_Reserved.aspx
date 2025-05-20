<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="ManagerCar_Not_Reserved.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.ManagerCar_Not_Reserved" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12" style="padding-top: 50px">
                <div class="row">

                    <div class="mx-auto">
                        <div class="mb-5">
                            <h3>Check Not Reserved Car</h3>
                        </div>

                        <div class="row">

                            <%-- Start Datetime --%>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <formview class="was-validated">
                                        <asp:Label for="start_datetime" runat="server" Text="text">Start DateTime</asp:Label>
                                        <asp:TextBox runat="server" type="datetime-local" CssClass="form-control form-control-lg" ID="start_datetime" required="start_datetime" />
                                    </formview>
                                </div>
                            </div>

                            <%-- End Datetime --%>
                            <div class="col-md-6 mb-4">
                                <div class="form-outline">
                                    <formview class="was-validated">
                                        <asp:Label for="end_datetime" runat="server" Text="text">End DateTime</asp:Label>
                                        <asp:TextBox runat="server" type="datetime-local" CssClass="form-control form-control-lg" ID="end_datetime" required="end_datetime" />
                                    </formview>
                                </div>
                            </div>

                        </div>

                        <br />
                        <%-- search car button  --%>
                        <div class="d-grid gap-2 col-2 mx-auto">
                            <asp:Button runat="server" ID="search_button"
                                CssClass="btn btn-success btn-lg"
                                Text="Search"
                                OnClick="search_button_Click" />
                        </div>

                        <br />
                        <%-- Result --%>
                        <div class="container">
                            <asp:GridView runat="server"
                                ID="grid_car_result"
                                CssClass="table"
                                AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="bookPeriod" HeaderText="Booking Period" />
                                    <asp:BoundField DataField="Book_Id" HeaderText="Booking Id" />
                                    <asp:BoundField DataField="book_status" HeaderText="Booking Status" />
                                    <asp:BoundField DataField="Chassis_No" HeaderText="Chassis No" />
                                    <asp:BoundField DataField="car_status" HeaderText="Car Status" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
