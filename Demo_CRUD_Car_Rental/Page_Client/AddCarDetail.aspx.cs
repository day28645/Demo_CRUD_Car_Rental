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
    public partial class AddCarDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarData();
            }
        }

        private void BindCarData()
        
        {
            // retrieve booking Session
            var tb_booking = (DataTable)Session["booking"];
            string pick_datetime = tb_booking.Rows[0]["pick_datetime"].ToString();
            string return_datetime = tb_booking.Rows[0]["return_datetime"].ToString();

            //string _pick_datetime = DateTime.ParseExact(pick_datetime, "yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")).ToString();
            //string _return_datetime = DateTime.ParseExact(return_datetime, "yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")).ToString();

            var startDatetime = DateTime.Parse(pick_datetime).AddYears(-543).ToString("yyyy-MM-dd HH:mm:ss");

            var endDateTime = DateTime.Parse(return_datetime).AddYears(-543).ToString("yyyy-MM-dd HH:mm:ss");

            string query = $"SELECT c.Chassis_No, c.Regis_no, c.Brand, c.Model, c.Rent_Price, c.car_status, c.image " +
                           $"FROM car c " +
                           $"WHERE c.car_status IN ('Ready', 'Reserved') " +
                           $"AND NOT EXISTS ( " +
                                    $"SELECT 1 " +
                                    $"FROM booking b " +
                                    $"JOIN create_booking cb ON b.Book_Id = cb.Book_Id " +
                                    $"WHERE cb.Chassis_No = c.Chassis_No AND ( " +
                                        $"(b.pick_datetime BETWEEN '{startDatetime}' AND '{endDateTime}') " +
                                        $"OR " +
                                        $"(b.return_datetime BETWEEN '{startDatetime}' AND '{endDateTime}') " +
                                        $"OR" +
                                        $"('{startDatetime}' BETWEEN b.pick_datetime AND b.return_datetime) " +
                                        $"OR " +
                                        $"('{endDateTime}' BETWEEN b.pick_datetime AND b.return_datetime)" +
                                   $")" +                                                                                                                              
                          $");";

            var cmd = new CRUD_Command();
            var dtCars = cmd.SelectComand(query);

            if (dtCars.Rows.Count > 0)
            {
                grid_car_list.DataSource = dtCars;
                grid_car_list.DataBind();
            }
            else
            {
                var tb_book = (DataTable)Session["booking"];
                string bookid = tb_book.Rows[0]["Book_Id"].ToString();

                string book_status = "unpaid overdue";

                string updateBooking = $@"UPDATE booking SET
                                                 book_status = '{book_status}',
                                          WHERE Book_Id = {bookid}";
                var resultUpdate = cmd.Insert_Update_Command(updateBooking);

                string sweetAlertScript = $"Swal.fire({{ title: 'No Cars Available', " +
                                                      $"text: 'No cars are available for booking at this time.', " +
                                                      $"icon: 'warning', confirmButtonText: 'OK' }}).then((result) => " +
                                                                $"{{ if (result.isConfirmed) " +
                                                                        $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
            }
        }


        protected void grid_car_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // 1. retrieve booking, user Session -> 2. convert duration in booking from str to int(to calculate) ->
            // 3. calculate total price, cancel fee -> 4. update booking & update car ->
            // 5. insert create_booking is success

            if (e.CommandName == "book_car_command")
            {
                try
                {
                    var cmd = new CRUD_Command();
                    var chassisNo = e.CommandArgument.ToString();
                    if (!string.IsNullOrEmpty(chassisNo))
                    {
                        // 1. Retrieve Sessions
                        var tb_booking = (DataTable)Session["booking"];
                        string bookid = tb_booking.Rows[0]["Book_Id"].ToString();

                        var tb_user = (DataTable)Session["user"];
                        string userid = tb_user.Rows[0]["Id_Card"].ToString();

                        // 2. Convert Duration
                        string queryDuration = $"SELECT duration FROM booking WHERE Book_Id = {bookid}";
                        var dtDuration = cmd.SelectComand(queryDuration);
                        int duration = (int)dtDuration.Rows[0]["duration"];

                        // 3. Calculate Rent Price and Cancel Fee
                        string queryRentprice = $"SELECT rent_price FROM car WHERE Chassis_No = '{chassisNo}' ";
                        var dtRentPrice = cmd.SelectComand(queryRentprice);
                        float rent_price = (float)dtRentPrice.Rows[0]["rent_price"];
                        float total_price = duration * rent_price;
                        float cancel_fee = total_price / 2;
                        string book_status = "paid";

                        // 4. Update booking
                        string updateBooking = $@"UPDATE booking SET
                                                cancel_fee = {cancel_fee},
                                                book_status = '{book_status}',
                                                total_price = {total_price} 
                                          WHERE Book_Id = {bookid}";
                        var resultUpdate = cmd.Insert_Update_Command(updateBooking);

                        // Update car status
                        //string car_status = "Reserved";
                        //string updateCarStatus = $@"UPDATE car SET
                        //                        car_status = '{car_status}'
                        //                  WHERE Chassis_No = '{chassisNo}'";
                        //var resultUpdateCarStatus = cmd.Insert_Update_Command(updateCarStatus);

                        // 5. Insert create_booking
                        var datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
                        string queryhader = @"insert into create_booking (Id_Card,
                                                        Book_Id,
                                                        Chassis_No,
                                                        book_datetime) ";
                        string valuesinsert = $"values({userid} , {bookid} , '{chassisNo}' , '{datetime}' )";
                        string queryfull = queryhader + valuesinsert;
                        int result = cmd.Insert_Update_Command(queryfull);

                        // Check result and redirect
                        if (result > 0 && resultUpdate > 0)
                        //if (result > 0 && resultUpdate > 0 && resultUpdateCarStatus > 0)
                        {
                            string sweetAlertScript = $"Swal.fire({{ title: 'Payment Successed', " +
                                                                  $"text: 'Success', " +
                                                                  $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                            $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Client/DisplayBookDetail.aspx?chassis_no={chassisNo}'; }} }});";
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                            //Response.Redirect($"~/Page_Client/DisplayBookDetail.aspx?chassis_no={chassisNo}");
                        }
                        else
                        {
                            string sweetAlertScript = $"Swal.fire({{ title: 'Booking Failed', " +
                                                                   $"text: 'Something Wrong', " +
                                                                   $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                            $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Client/AddCarDetail.aspx'; }} }});";
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
}