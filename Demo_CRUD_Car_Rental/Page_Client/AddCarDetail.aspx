<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="AddCarDetail.aspx.cs" Inherits="Demo_CRUD_Car_Rental.Page_Client.AddCarDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <h2 class="text-center">Avaliable Cars</h2>
        <section style="background-color: #eee;">
            <div class="container py-5">

                <asp:GridView OnRowCommand="grid_car_list_RowCommand"
                    ID="grid_car_list" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table table-striped">
                    <Columns>

                        <asp:BoundField DataField="brand" HeaderText="Brand" />
                        <asp:BoundField DataField="model" HeaderText="Model" />
                        <asp:BoundField DataField="regis_no" HeaderText="Registered No" />

                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="image" runat="server" ImageUrl='<%# Eval("image") %>' Height="80px" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="rent_price" HeaderText="Rent Price" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton CommandName="book_car_command" 
                                    ID="confirm_pay"
                                    CommandArgument='<%# Eval("chassis_no") %>' 
                                    runat="server" 
                                    CssClass="btn btn-primary">Pay</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>


            </div>
        </section>
    </div>

</asp:Content>
