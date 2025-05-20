using Demo_CRUD_Car_Rental.Model;
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
    public partial class AddBookDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLocation();
            }
        }

        private void LoadLocation()
        {
            string queryLocation = $"SELECT Location_Id, location_name FROM location";
            var cmd = new CRUD_Command();
            var dtLocation = cmd.SelectComand(queryLocation);
            var locationList = new List<LocationListModel>();
            foreach (DataRow item in dtLocation.Rows)
            {
                locationList.Add(new LocationListModel()
                {
                    loc_id = item["Location_Id"].ToString(),
                    loc_name = item["location_name"].ToString()
                });
            }

            if (locationList.Count > 0)
            {
                // pick-up location
                dp_pick_location.DataTextField = "loc_name";
                dp_pick_location.DataValueField = "loc_id";
                dp_pick_location.DataSource = locationList;

                dp_pick_location.DataBind();
                dp_pick_location.Items.Insert(0, "Select Location");

                // return location
                dp_return_location.DataTextField = "loc_name";
                dp_return_location.DataValueField = "loc_id";
                dp_return_location.DataSource = locationList;

                dp_return_location.DataBind();
                dp_return_location.Items.Insert(0, "Select Location");
            }
        }

        protected void dp_pick_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pick_location = dp_pick_location.SelectedValue;
        }

        protected void dp_return_location_SelectedIndexChanged(object sender, EventArgs e)
        {
            var return_location = dp_return_location.SelectedValue;
        }

        protected void search_button_Click(object sender, EventArgs e)
        {
            try
            {
                // booking data
                var location_pick_id = dp_pick_location.SelectedValue;
                var location_return_id = dp_return_location.SelectedValue;

                var pick_datetime = txt_pick_datetime.Text;
                var return_datetime = txt_return_datetime.Text;

                if (pick_datetime == "" || return_datetime == "")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment Failed', " +
                                                           $"text: 'Pick and Return Datetime Required', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }

                DateTime cal_pick_date;
                DateTime cal_return_date;
                DateTime current_date = DateTime.Now.Date;

                if (!DateTime.TryParseExact(pick_datetime, "yyyy-MM-ddTHH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out cal_pick_date))
                {
                    return;
                }

                if (!DateTime.TryParseExact(return_datetime, "yyyy-MM-ddTHH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out cal_return_date))
                {
                    return;
                }

                if (cal_return_date < cal_pick_date)
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment Failed', " +
                                                           $"text: 'Return Datetime must be covered Pick Datime', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }

                TimeSpan duration = cal_return_date - cal_pick_date;
                int total_duration = (int)duration.Days + 1;


                if (total_duration > 3)
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment Failed', " +
                                                           $"text: 'Cannot book for more than 3 days', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (cal_pick_date < current_date || cal_return_date < current_date)
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment Failed', " +
                                                           $"text: 'Cannot book a past date', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else if (location_pick_id == "Select Location" || location_return_id == "Select Location")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment Failed', " +
                                                           $"text: 'Location Required', " +
                                                           $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Client/AddBookDetail.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else
                {

                    string queryhader = @"insert into booking (pick_datetime,
                                                    return_datetime,
                                                    duration,
                                                    Pick_Id,
                                                    Return_Id) ";

                    string valuesinsert = $"values('{pick_datetime}', " +
                                                $"'{return_datetime}', " +
                                                $" {total_duration} , {location_pick_id} , {location_return_id})";

                    string queryfull = queryhader + valuesinsert;

                    var cmd = new CRUD_Command();
                    int result = cmd.Insert_Update_Command(queryfull);

                    // store booking Session
                    string queryBooking = $"SELECT * FROM booking where pick_datetime = '{pick_datetime}' and " +
                                                                    $"return_datetime = '{return_datetime}' and " +
                                                                    $"Pick_Id = {location_pick_id} and " +
                                                                    $"Return_Id = {location_return_id}";
                    var dtBookSession = cmd.SelectComand(queryBooking);

                    Session["booking"] = dtBookSession;

                    if (result > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Detailed Appointment', " +
                                                               $"text: 'Success', " +
                                                               $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
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