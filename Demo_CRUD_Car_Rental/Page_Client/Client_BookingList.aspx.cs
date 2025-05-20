using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Client
{
    public partial class Client_BookingList : System.Web.UI.Page
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
            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            string queryBooking = $"SELECT cb.Book_Id, cb.book_datetime , " +
                                   $"b.total_price, b.book_status, " +
                                   $"c.regis_no " +
                           $"FROM create_booking as cb " +
                           $"JOIN booking as b ON b.Book_Id = cb.Book_Id " +
                           $"JOIN car as c ON c.Chassis_No = cb.Chassis_No " +
                           $"WHERE cb.Id_Card = {userid}";

            try
            {
                var cmd = new CRUD_Command();
                DataTable dtBooking = cmd.SelectComand(queryBooking);

                if (dtBooking.Rows.Count > 0)
                {
                    grid_booking_list.DataSource = dtBooking;
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
                throw ex;
            }
        }

        protected void grid_booking_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "request_cancel_booking")
            {
                var bookId = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(bookId))
                {
                    Request_DeleteByBookId(bookId);
                }
            }
            else if (e.CommandName == "view_booking")
            {
                var bookId = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(bookId))
                {
                    Response.Redirect($"~/Page_Client/ViewBookingDetail.aspx?booking_no={bookId}");
                }
            }
        }

        protected void Request_DeleteByBookId(string bookId)
        {
            var cmd = new CRUD_Command();

            string queryBook = $"SELECT * from booking WHERE Book_Id = '{bookId}'";
            var dtBook = cmd.SelectComand(queryBook);

            try
            {
                if (dtBook.Rows.Count > 0)
                {
                    string pick_datetime = dtBook.Rows[0]["pick_datetime"].ToString();

                    string dataBookStatus = dtBook.Rows[0]["book_status"].ToString();

                    DateTime cal_pick_datetime;
                    if (!DateTime.TryParse(pick_datetime, out cal_pick_datetime))
                    {
                        return;
                    }

                    DateTime current_datetime = DateTime.Now;

                    TimeSpan timeDifference = cal_pick_datetime - current_datetime;

                    if (dataBookStatus == "return")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Completed Booking', " +
                                                               $"icon: 'error', " +
                                                               $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else if (timeDifference.TotalDays <= 1)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                                       $"text: 'Cancel the booking 1 day before the pick-up date.', " +
                                                                       $"icon: 'error', " +
                                                                       $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                                $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        return;
                    }
                    else if (dataBookStatus == "pick")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Still Pick -Up Process', " +
                                                               $"icon: 'error', " +
                                                               $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else if (dataBookStatus == "request cancel")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Still Cancellation Process', " +
                                                               $"icon: 'error', " +
                                                               $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else if (dataBookStatus == "cancel completed")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Cancellation Completed', " +
                                                               $"icon: 'error', " +
                                                               $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else
                    {
                        // update book status
                        string book_status = "request cancel";
                        string updateBooking = $@"UPDATE booking SET 
                                            book_status = '{book_status}' 
                                      WHERE Book_Id = '{bookId}'";

                        var dtUpdateBooking = cmd.Insert_Update_Command(updateBooking);

                        if (dtUpdateBooking > 0)
                        {
                            string sweetAlertScript = $"Swal.fire({{ title: 'Request Delete Booking', " +
                                                                   $"text: 'Success', " +
                                                                   $"icon: 'success', " +
                                                                   $"confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/Client_BookingList.aspx'; }} }});";
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}