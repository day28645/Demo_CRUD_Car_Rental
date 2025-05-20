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
    public partial class AddLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindLocationData();
        }

        private void BindLocationData()
        {
            string query = $"SELECT * from location";
            try
            {
                var cmd = new CRUD_Command();
                DataTable locationData = cmd.SelectComand(query);

                if (locationData.Rows.Count > 0)
                {
                    grid_location_list.DataSource = locationData;
                    grid_location_list.DataBind();
                }
                else
                {
                    grid_location_list.EmptyDataText = "No Location";
                    grid_location_list.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void add_location_Click(object sender, EventArgs e)
        {
            var loc_name = txt_locname.Text;
            var addresss = txt_address.Text;
            //var datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));

            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            var cmd = new CRUD_Command();

            try
            {
                string queryLocation = $"SELECT * FROM location WHERE location_name = '{loc_name}'";
                var dtLocation = cmd.SelectComand(queryLocation);

                if (dtLocation.Rows.Count > 0)
                {
                    string dataLocation = dtLocation.Rows[0]["location_name"].ToString();

                    if (dataLocation == txt_locname.Text)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Add Location Failed', " +
                                                               $"text: 'Duplicated Location Name', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/AddLocation.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Add Location Failed', " +
                                                               $"text: 'Duplicated Location Name', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/AddLocation.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
                else
                {
                    string queryhader = @"insert into location (`location_name`,
                                                    `location_address`,
                                                    `add_loc_datetime`,
                                                    `Id_Card`)";

                    string valuesinsert = $"values('{loc_name}' , '{addresss}' ,  Now(), '{userid}' )";

                    string queryfull = queryhader + valuesinsert;

                    var result = cmd.Insert_Update_Command(queryfull);
                    if (result > 0)
                    {
                        string sweetAlertScript = "Swal.fire({ title: 'Add Location', " +
                                                              "text: 'Success', " +
                                                              "icon: 'success', confirmButtonText: 'OK' }).then((result) => " +
                                                                        "{ if (result.isConfirmed) " +
                                                                                "{ window.location.href = '/Page_Employee/AddLocation.aspx'; } });";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                    else
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Add Location Failed', " +
                                                               $"text: 'All Field is Required', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/AddLocation.aspx'; }} }});";
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