<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageBookingAdmin.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.ManageBookingAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="text-center">All Booking</h2>
        <section style="background-color: #eee;">
            <div class="container py-5">

                <asp:GridView OnRowCommand="grid_booking_list_RowCommand"
                    OnRowEditing="grid_booking_list_RowEditing"
                    ID="grid_booking_list" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped">
                    <Columns>

                        <asp:BoundField DataField="Book_Id" HeaderText="Book ID" />
                        <asp:BoundField DataField="book_datetime" HeaderText="Booking Date & Time" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                        <asp:BoundField DataField="regis_no" HeaderText="Registered No." />
                        <asp:BoundField DataField="book_status" HeaderText="Book Status" />
                        <asp:BoundField DataField="car_status" HeaderText="Car Status" />

                        <%-- View Booking --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="view_command"
                                    CommandArgument='<%# Eval("Book_Id") %>' runat="server"
                                    CssClass="btn btn-primary">View Booking
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- Cancel Booking --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="cancel_command"
                                    CommandArgument='<%# Eval("Book_Id") %>' runat="server"
                                    CssClass="btn btn-danger">Cancel Booking
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </section>
    </div>

</asp:Content>
