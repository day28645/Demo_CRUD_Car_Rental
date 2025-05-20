using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class CancelBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bookId = Request.QueryString["booking_no"];
                LoadBooking(bookId);
            }
        }

        private void LoadBooking(string bookId)
        {

            string queryPick = $"SELECT b.pick_datetime, b.return_datetime, " +
                                  $"b.Book_Id, b.book_status, b.cancel_fee, " +
                                  $"l.location_name, ll.location_name, " +
                                  $"cb.book_datetime, u.firstname, u.lastname, c.car_status, c.regis_no " +
                           $"FROM booking as b " +
                           $"JOIN location as l ON b.Pick_Id = l.Location_Id " +
                           $"JOIN location as ll ON b.Pick_Id = ll.Location_Id " +
                           $"JOIN create_booking as cb ON cb.Book_Id = b.Book_Id " +
                           $"JOIN car as c on c.Chassis_No = cb.Chassis_No " +
                           $"JOIN users as u ON cb.Id_Card = u.Id_Card " +
                                $"WHERE b.Book_Id = {bookId}; ";

            var cmd = new CRUD_Command();

            var dtPick = cmd.SelectComand(queryPick);

            if (dtPick.Rows.Count > 0)
            {
                DataRow row = dtPick.Rows[0];

                // booking
                txt_pickdatetime.Text = row["pick_datetime"].ToString();
                txt_returndatetime.Text = row["return_datetime"].ToString();
                txt_bookid.Text = row["Book_Id"].ToString();
                txt_book_status.Text = row["book_status"].ToString();
                txt_cancel_fee.Text = row["cancel_fee"].ToString();

                // location
                txt_pick_location.Text = row["location_name"].ToString();
                txt_return_location.Text = row["location_name"].ToString();

                // create booking
                txt_book_datetime.Text = row["book_datetime"].ToString();

                // user
                txt_firstname.Text = row["firstname"].ToString();
                txt_lastname.Text = row["lastname"].ToString();

                // car
                txt_car_status.Text = row["car_status"].ToString();
                txt_regis_no.Text = row["regis_no"].ToString();
            }

        }

        protected void cancel_book_Click(object sender, EventArgs e)
        {
            string bookId = Request.QueryString["booking_no"];

            // 1. retrieve user Session -> 2. select car data
            // 3. insert cancel_booking -> 4. update car, booking -> 5. delete create_booking by bookid is success

            // 1.
            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            var cmd = new CRUD_Command();

            // 2.
            // select car data
            string queryCar = $"SELECT * " +
                                    $"FROM create_booking as cb " +
                                    $"JOIN booking as b ON b.Book_Id = cb.Book_Id " +
                              $"WHERE cb.Book_Id = {bookId}";
            var dtCarId = cmd.SelectComand(queryCar);

            try
            {
                if (dtCarId.Rows.Count > 0)
                {
                    string carid = dtCarId.Rows[0]["Chassis_No"].ToString();
                    string dataBookStatus = dtCarId.Rows[0]["book_status"].ToString();

                    if (dataBookStatus == "request cancel")
                    {
                        // 3.
                        var cancel_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));

                        // insert bookid, carid into cancel_booking 
                        string queryhader = @"insert into cancel_booking (`Id_Card`,
                                                                     `Book_Id`,
                                                                     `Chassis_No`,
                                                                     `cancel_datetime`)";
                        string valuesinsert = $"values({userid} , {bookId} , '{carid}' , '{cancel_datetime}')";

                        string queryfull = queryhader + valuesinsert;

                        var result = cmd.Insert_Update_Command(queryfull);

                        // 4.
                        // update book status
                        string book_status = "cancel completed";

                        string updateBook = $@"UPDATE booking SET 
                                                book_status = '{book_status}' 
                                   WHERE Book_Id = '{bookId}'";

                        var resultUpdate = cmd.Insert_Update_Command(updateBook);

                        // update car status
                        string car_status = "Ready";
                        string updateCarStatus = $@"UPDATE car SET
                                                    car_status = '{car_status}'
                                              WHERE Chassis_No = '{carid}'";

                        var resultUpdateCarStatus = cmd.Insert_Update_Command(updateCarStatus);

                        // 5.
                        // delete create_booking by bookid
                        string queryBooking = $"DELETE FROM create_booking WHERE Book_Id = {bookId}";

                        object dataBooking = cmd.ExecuteScalarCommand(queryBooking);

                        if (result > 0 && resultUpdate > 0)
                        {
                            string sweetAlertScript = $"Swal.fire({{ title: 'Delete Booking', " +
                                                                   $"text: 'Success', " +
                                                                   $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/ManageBookingAdmin.aspx'; }} }});";
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        }
                    }
                    else if (dataBookStatus == "paid")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Request Cancellation Required', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/ManageBookingAdmin.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else if (dataBookStatus == "pick")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Pick Processing', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/ManageBookingAdmin.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else if (dataBookStatus == "return")
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Cancel Booking', " +
                                                               $"text: 'Return Processing', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/ManageBookingAdmin.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
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