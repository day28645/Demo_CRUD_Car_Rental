<%@ Page Title="" Language="C#" MasterPageFile="~/Employee.Master" AutoEventWireup="true" CodeBehind="CarList.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Employee.CarList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2>Car List</h2>
        <asp:GridView OnRowCommand="grid_car_list_RowCommand"
            OnRowEditing="grid_car_list_RowEditing"
            ID="grid_car_list" runat="server"
            AutoGenerateColumns="False"
            CssClass="table table-striped">
            <Columns>

                <asp:BoundField DataField="chassis_no" HeaderText="Chassis No" />
                <asp:BoundField DataField="brand" HeaderText="Brand" />
                <asp:BoundField DataField="model" HeaderText="Model" />
                <asp:BoundField DataField="car_type" HeaderText="Type" />
                <asp:BoundField DataField="color" HeaderText="Color" />

                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image runat="server" ImageUrl='<%# Eval("image") %>' Height="80px" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="fuel" HeaderText="Fuel" />
                <asp:BoundField DataField="rent_price" HeaderText="Rent Price" />
                <asp:BoundField DataField="car_status" HeaderText="Status" />
                <asp:BoundField DataField="register_datetime" HeaderText="Register Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />

                <%-- view button --%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="view_command" CommandArgument='<%# Eval("chassis_no") %>' runat="server" CssClass="btn btn-primary">View</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <%-- edit button --%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton CommandName="edit_command" CommandArgument='<%# Eval("chassis_no") %>' runat="server" CssClass="btn btn-success">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>
    </div>

</asp:Content>
