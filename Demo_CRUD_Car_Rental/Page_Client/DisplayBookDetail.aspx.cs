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
    public partial class DisplayBookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string chassis_no = Request.QueryString["chassis_no"];
                LoadCarData(chassis_no);
            }
        }

        private void LoadCarData(string chassis_no)
        {
            // retrieve user Session
            var booking = (DataTable)Session["booking"];
            int bookid = (int)booking.Rows[0]["Book_Id"];

            var cmd = new CRUD_Command();

            string queryDisplay = $"SELECT c.image, c.brand, c.model, c.rent_price, c.regis_no, c.car_status, " +
                                         $"b.total_price, b.duration, b.book_status, b.pick_datetime, b.return_datetime, " +
                                         $"cb.book_datetime, " +
                                         $"l.location_name, ll.location_name " +
                                  $"FROM car as c " +
                                  $"JOIN create_booking as cb ON c.Chassis_No = cb.Chassis_No " +
                                  $"JOIN booking as b ON cb.Book_Id = b.Book_Id " +
                                  $"JOIN location as l ON l.Location_Id = b.Pick_Id " +
                                  $"JOIN location as ll ON ll.Location_Id = b.Return_Id " +
                                  $"WHERE cb.Book_Id = {bookid} and cb.Chassis_No = '{chassis_no}' ";

            var dtDisplay = cmd.SelectComand(queryDisplay);

            if (dtDisplay.Rows.Count > 0)
            {
                DataRow display = dtDisplay.Rows[0];

                car_status_db.Text = display["car_status"].ToString();
                image_db.ImageUrl = display["image"].ToString();
                brand_db.Text = display["brand"].ToString();
                model_db.Text = display["model"].ToString();
                regis_no_db.Text = display["regis_no"].ToString();
                rent_price_db.Text = display["rent_price"].ToString();
                total_price_db.Text = display["total_price"].ToString();
                duration_db.Text = display["duration"].ToString();
                book_status_db.Text = display["book_status"].ToString();
                datetime_db.Text = display["book_datetime"].ToString();
                txt_pick_location.Text = display["location_name"].ToString();
                txt_return_location.Text = display["location_name"].ToString();
                txt_pickdatetime.Text = display["pick_datetime"].ToString();
                txt_returndatetime.Text = display["return_datetime"].ToString();

            }
        }

    }
}