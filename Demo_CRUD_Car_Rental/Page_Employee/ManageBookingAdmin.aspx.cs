using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class ManageBookingAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBookingData();
            }
        }

        private void BindBookingData()
        {
            string query = $"SELECT cb.Book_Id, cb.book_datetime, " +
                                  $"b.total_price, b.book_status, b.cancel_fee, " +
                                  $"c.regis_no, c.car_status " +
                           $"FROM create_booking as cb " +
                           $"JOIN booking as b ON b.Book_Id = cb.Book_Id " +
                           $"JOIN car as c ON c.Chassis_No = cb.Chassis_No";

            try
            {
                var cmd = new CRUD_Command();
                DataTable bookData = cmd.SelectComand(query);

                if (bookData.Rows.Count > 0)
                {
                    grid_booking_list.DataSource = bookData;
                    grid_booking_list.DataBind();
                }
                else
                {
                    grid_booking_list.EmptyDataText = "No Booking";
                    grid_booking_list.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void grid_booking_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_booking_list.EditIndex = e.NewEditIndex;
            BindBookingData();
        }

        protected void grid_booking_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cancel_command")
            {
                var book_id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(book_id))
                {
                    Response.Redirect($"~/Page_Employee/CancelBooking.aspx?booking_no={book_id}");
                }
            }
            else if (e.CommandName == "view_command")
            {
                var book_id = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(book_id))
                {
                    Response.Redirect($"~/Page_Employee/DisplayBookingAdmin.aspx?booking_no={book_id}");
                }
            }
        }
    }
}