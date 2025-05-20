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
    public partial class UpdatePick : System.Web.UI.Page
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
                                  $"b.Book_Id, b.book_status, l.location_name, ll.location_name, " +
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
    

        protected void pick_car_Click(object sender, EventArgs e)
        {
            string bookId = Request.QueryString["booking_no"];

            var cmd = new CRUD_Command();

            try
            {
                string queryCreateBooking = $"SELECT * " +
                                            $"FROM create_booking cb " +
                                            $"JOIN car c on cb.Chassis_No = c.Chassis_No " +
                                            $"WHERE cb.Book_Id = {bookId}";
                var dtCarId = cmd.SelectComand(queryCreateBooking);
                string dataCarId = dtCarId.Rows[0]["Chassis_No"].ToString();
                string carStatus = dtCarId.Rows[0]["car_status"].ToString();


                string queryBookStatus = $"SELECT * FROM booking WHERE Book_Id = {bookId} ";
                var dtBookStatus = cmd.SelectComand(queryBookStatus);

                string dataBookStatus = dtBookStatus.Rows[0]["book_status"].ToString();
                if (dataBookStatus == "request cancel")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                           $"text: 'Processing Cancellation This Booking', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (dataBookStatus == "cancel completed")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                           $"text: 'Completed Cancellation', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (dataBookStatus == "return")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                           $"text: 'Completed Booking', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (dataBookStatus == "pick")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                           $"text: 'Pick-Up Car Processing', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (carStatus == "Reserved")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                           $"text: 'Pick-Up Car Processing', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else
                {
                    // book status
                    string book_status = "pick";

                    string cancel_fee = "0";

                    string updateBooking = $@"UPDATE booking SET 
                                                    cancel_fee = {cancel_fee},
                                                    book_status = '{book_status}' 
                                            WHERE Book_Id = '{bookId}'";
                    var resultUpdate_booking = cmd.Insert_Update_Command(updateBooking);

                    // car status
                    string car_status = "Reserved";

                    string updateCar = $@"UPDATE car SET car_status = '{car_status}' WHERE Chassis_No = '{dataCarId}'";
                    var resultUpdate_car = cmd.Insert_Update_Command(updateCar);

                    // pick datetime
                    var pick_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
                    string updateCreateBooking = $@"UPDATE create_booking SET checkin_datetime = '{pick_datetime}' WHERE Book_Id = '{bookId}'";
                    var resultUpdate_createbooking = cmd.Insert_Update_Command(updateCreateBooking);

                    if (resultUpdate_booking > 0 && resultUpdate_createbooking > 0 && resultUpdate_car > 0)
                    //if (resultUpdate_booking > 0 && resultUpdate_createbooking > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Check-In Booking', " +
                                                               $"text: 'Success', icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Cannot Check-In Booking', " +
                                                               $"text: 'Something Wrong', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Employee/ManageBookingList.aspx'; }} }});";
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