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
    public partial class AddCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_car_Click(object sender, EventArgs e)
        {
            var regis_date = date_regis.Text;
            var chassis = txt_chassis_no.Text;
            var brands = brand_list.Text;
            var models = txt_model.Text;
            var type = type_list.SelectedValue;
            var color = color_list.SelectedValue;
            var fuel = fuel_list.SelectedValue;
            var rent = num_car_rent.Text;
            var regis_book = txt_car_regis.Text;
            var price = num_car_price.Text;
            var status = status_list.SelectedValue;
            var datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));
            var regis_no = txt_regisno.Text;
            var owners = txt_owner.Text;

            // retrieve user Session
            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            var cmd = new CRUD_Command();

            try
            {
                string queryCar = $"SELECT * FROM car WHERE Chassis_No = '{chassis}' or regis_no = '{regis_no}' ";
                var dtCar = cmd.SelectComand(queryCar);

                if (dtCar.Rows.Count > 0)
                {
                    string dataChassis_No = dtCar.Rows[0]["Chassis_No"].ToString();
                    if (dataChassis_No == txt_chassis_no.Text)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Add Car Failed', " +
                                                               $"text: 'Duplicated Chassis Number', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/AddCar.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }

                    string dataRegis_no = dtCar.Rows[0]["regis_no"].ToString();
                    if (dataRegis_no == txt_regisno.Text)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Add Car Failed', " +
                                                               $"text: 'Duplicated Registered Number', " +
                                                               $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/AddCar.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
                else
                {
                    if (txt_car_image.HasFile)
                    {
                        txt_car_image.SaveAs(MapPath("~/Images/") + System.IO.Path.GetFileName(txt_car_image.FileName));
                        string path_image = "~/Images/" + System.IO.Path.GetFileName(txt_car_image.FileName);

                        string queryhader = @"insert into car (chassis_no,
                                                brand,
                                                model,
                                                car_type,
                                                color,
                                                fuel,
                                                image,
                                                rent_price,
                                                car_book_no,
                                                price,
                                                car_status,
                                                register_datetime,
                                                regis_no,
                                                car_owner,
                                                id_card,
                                                regis_date)";

                        string valuesinsert = $"values('{chassis}' , '{brands}' , " +
                                                     $"'{models}' ,'{type}', " +
                                                     $"'{color}' , '{fuel}' , " +
                                                     $"'{path_image}' , '{rent}' , " +
                                                     $"'{regis_book}' ,'{price}' , " +
                                                     $"'{status}' , '{datetime}' , " +
                                                     $"'{regis_no}' , '{owners}' , " +
                                                     $"'{userid}' , '{regis_date}')";

                        string queryfull = queryhader + valuesinsert;

                        var result = cmd.Insert_Update_Command(queryfull);
                        if (result > 0)
                        {
                            string sweetAlertScript = "Swal.fire({ title: 'Add Car', " +
                                                                  "text: 'Success', " +
                                                                  "icon: 'success', confirmButtonText: 'OK' }).then((result) => " +
                                                                            "{ if (result.isConfirmed) " +
                                                                                    "{ window.location.href = '/Page_Employee/AddCar.aspx'; } });";
                            ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        }
                        else
                        {
                            string sweetAlertScript = $"Swal.fire({{ title: 'Add Car Failed', " +
                                                                   $"text: 'All Field is Required', " +
                                                                   $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                            $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Employee/AddCar.aspx'; }} }});";
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