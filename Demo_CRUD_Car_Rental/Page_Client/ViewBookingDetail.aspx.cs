using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Client
{
    public partial class ViewBookingDetail : System.Web.UI.Page
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
    }
}