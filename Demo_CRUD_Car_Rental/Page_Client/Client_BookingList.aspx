<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="Client_BookingList.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Client.Client_BookingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="text-center">All Booking</h2>
        <section style="background-color: #eee;">
            <div class="container py-5">

                <asp:GridView ID="grid_booking_list" runat="server"
                    OnRowCommand="grid_booking_list_RowCommand"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Book_Id" HeaderText="Book ID" />
                        <asp:BoundField DataField="book_datetime" HeaderText="Booking Date & Time" />
                        <asp:BoundField DataField="total_price" HeaderText="Total Price" />
                        <asp:BoundField DataField="regis_no" HeaderText="Registered No." />
                        <asp:BoundField DataField="book_status" HeaderText="Book Status" />

                        <%-- request cancel booking --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="view_booking"
                                    CommandArgument='<%# Eval("Book_Id") %>' runat="server"
                                    CssClass="btn btn-primary">View 
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <%-- request cancel booking --%>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="request_cancel_booking"
                                    CommandArgument='<%# Eval("Book_Id") %>' runat="server"
                                    CssClass="btn btn-danger">Cancel 
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

            </div>
        </section>
    </div>

</asp:Content>
