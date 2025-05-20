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
    public partial class EditCar : System.Web.UI.Page
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
            var cmd = new CRUD_Command();
            string queryCar = $"SELECT * FROM car WHERE Chassis_No = '{chassis_no}'";
            var dataCar = cmd.SelectComand(queryCar);
            if (dataCar.Rows.Count > 0)
            {
                DataRow row = dataCar.Rows[0];

                date_regis.Text = Convert.ToDateTime(row["register_datetime"]).ToString("yyyy-MM-dd");
                txt_regisno.Text = row["regis_no"].ToString();
                num_car_price.Text = row["price"].ToString();
                num_car_rent.Text = row["rent_price"].ToString();
                txt_car_regis.Text = row["car_book_no"].ToString();
                txt_owner.Text = row["car_owner"].ToString();
                brand_list.Text = row["brand"].ToString();
                txt_model.Text = row["model"].ToString();
                txt_chassis_no.Text = row["chassis_no"].ToString();
                fuel_list.SelectedValue = row["fuel"].ToString();
                type_list.SelectedValue = row["car_type"].ToString();
                color_list.SelectedValue = row["color"].ToString();
                status_list.SelectedValue = row["car_status"].ToString();
            }
        }

        protected void edit_car_Click(object sender, EventArgs e)
        {
            //1. insert car_history -> 2. update car is success

            string chassis_no = Request.QueryString["chassis_no"];
            var cmd = new CRUD_Command();

            var histotry_datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US"));

            var user = (DataTable)Session["user"];
            string userid = user.Rows[0]["Id_Card"].ToString();

            // 1.
            // select car 
            string queryCar = $"SELECT regis_no, car_owner, car_status, rent_price from car WHERE Chassis_No = '{chassis_no}'";

            var dtCar = cmd.SelectComand(queryCar);

            string dataRegisNo = dtCar.Rows[0]["regis_no"].ToString();
            string dataOwner = dtCar.Rows[0]["car_owner"].ToString();
            string dataStatus = dtCar.Rows[0]["car_status"].ToString();
            string dataRentPrice = dtCar.Rows[0]["rent_price"].ToString();

            // <-- Ready -->
            if (dataStatus == "Ready")
            {
                string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                            $"text: 'Required Not Ready Status', " +
                                                            $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
            }
            // <-- Reserved -->
            else if (dataStatus == "Reserved")
            {
                string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                            $"text: 'Required Not Ready Status', " +
                                                            $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
            }
            // <-- Repaired -->
            else if (dataStatus == "Repaired")
            {
                string check_car_status = status_list.SelectedValue;
                if (check_car_status == "Reserved")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                            $"text: 'Cannot Change Status', " +
                                                            $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else
                {
                    string check_regis_no = txt_regisno.Text;
                    string queryCheckRegisNo = $@"SELECT COUNT(*) FROM car 
                                  WHERE regis_no = '{check_regis_no}' 
                                  AND Chassis_No != '{chassis_no}'";
                    var dtCheckRegisNo = cmd.SelectComand(queryCheckRegisNo);

                    if (dtCheckRegisNo.Rows.Count > 0 && Convert.ToInt32(dtCheckRegisNo.Rows[0][0]) > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                                    $"text: 'Regis No is Already in Use', " +
                                                                    $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                            $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        return;
                    }

                    if (dataRegisNo == txt_regisno.Text)
                    {
                        dataRegisNo = null;
                    }
                    if (dataOwner == txt_owner.Text)
                    {
                        dataOwner = null;
                    }
                    if (dataStatus == status_list.SelectedValue)
                    {
                        dataStatus = null;
                    }
                    if (dataRentPrice == num_car_rent.Text)
                    {
                        dataRentPrice = "0";
                    }


                    // insert car_history 
                    string queryhader = @"INSERT INTO car_history (regis_no,
                                                           car_owner,
                                                           car_status,
                                                           rent_price,
                                                           history_datetime,
                                                           Id_Card,
                                                           Chassis_No)";

                    string valuesinsert = $"VALUES('{dataRegisNo}'" +
                                                $", '{dataOwner}' " +
                                                $", '{dataStatus}' " +
                                                $", {dataRentPrice} " +
                                                $", '{histotry_datetime}'" +
                                                $", {userid} " +
                                                $", '{chassis_no}')";

                    string queryFull = queryhader + valuesinsert;

                    var resultInsert = cmd.Insert_Update_Command(queryFull);

                    // 2.
                    // new data
                    var regis_no = txt_regisno.Text;
                    var car_owner = txt_owner.Text;
                    var car_status = status_list.SelectedValue;
                    var rent_price = num_car_rent.Text;

                    // Update car 
                    string updateCar = $@"UPDATE car 
                                        SET regis_no = '{regis_no}', 
                                        car_owner = '{car_owner}', 
                                        car_status = '{car_status}', 
                                        rent_price = {rent_price} 
                                  WHERE Chassis_No = '{chassis_no}'";

                    var resultUpdate = cmd.Insert_Update_Command(updateCar);

                    if (resultUpdate > 0 && resultInsert > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car', " +
                                                              $"text: 'Success', " +
                                                              $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
            }
            // <-- Not Ready -->
            else if (dataStatus == "Not Ready")
            {
                string check_car_status = status_list.SelectedValue;
                if (check_car_status == "Reserved")
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                            $"text: 'Cannot Change Status', " +
                                                            $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
                else
                {
                    string check_regis_no = txt_regisno.Text;
                    string queryCheckRegisNo = $@"SELECT COUNT(*) FROM car 
                                  WHERE regis_no = '{check_regis_no}' 
                                  AND Chassis_No != '{chassis_no}'";
                    var dtCheckRegisNo = cmd.SelectComand(queryCheckRegisNo);

                    if (dtCheckRegisNo.Rows.Count > 0 && Convert.ToInt32(dtCheckRegisNo.Rows[0][0]) > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                                    $"text: 'Regis No is Already in Use', " +
                                                                    $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                            $"{{ if (result.isConfirmed) " +
                                                                                    $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                        return;
                    }

                    if (dataRegisNo == txt_regisno.Text)
                    {
                        dataRegisNo = null;
                    }
                    if (dataOwner == txt_owner.Text)
                    {
                        dataOwner = null;
                    }
                    if (dataStatus == status_list.SelectedValue)
                    {
                        dataStatus = null;
                    }
                    if (dataRentPrice == num_car_rent.Text)
                    {
                        dataRentPrice = "0";
                    }


                    // insert car_history 
                    string queryhader = @"INSERT INTO car_history (regis_no,
                                                           car_owner,
                                                           car_status,
                                                           rent_price,
                                                           history_datetime,
                                                           Id_Card,
                                                           Chassis_No)";

                    string valuesinsert = $"VALUES('{dataRegisNo}'" +
                                                $", '{dataOwner}' " +
                                                $", '{dataStatus}' " +
                                                $", {dataRentPrice} " +
                                                $", '{histotry_datetime}'" +
                                                $", {userid} " +
                                                $", '{chassis_no}')";

                    string queryFull = queryhader + valuesinsert;

                    var resultInsert = cmd.Insert_Update_Command(queryFull);

                    // 2.
                    // new data
                    var regis_no = txt_regisno.Text;
                    var car_owner = txt_owner.Text;
                    var car_status = status_list.SelectedValue;
                    var rent_price = num_car_rent.Text;

                    // Update car 
                    string updateCar = $@"UPDATE car 
                                        SET regis_no = '{regis_no}', 
                                        car_owner = '{car_owner}', 
                                        car_status = '{car_status}', 
                                        rent_price = {rent_price} 
                                  WHERE Chassis_No = '{chassis_no}'";

                    var resultUpdate = cmd.Insert_Update_Command(updateCar);

                    if (resultUpdate > 0 && resultInsert > 0)
                    {
                        string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car', " +
                                                              $"text: 'Success', " +
                                                              $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                        ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------
            else
            {
                string check_regis_no = txt_regisno.Text;
                string queryCheckRegisNo = $@"SELECT COUNT(*) FROM car 
                                  WHERE regis_no = '{check_regis_no}' 
                                  AND Chassis_No != '{chassis_no}'";
                var dtCheckRegisNo = cmd.SelectComand(queryCheckRegisNo);

                if (dtCheckRegisNo.Rows.Count > 0 && Convert.ToInt32(dtCheckRegisNo.Rows[0][0]) > 0)
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car Failed', " +
                                                                $"text: 'Regis No is Already in Use', " +
                                                                $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                        $"{{ if (result.isConfirmed) " +
                                                                                $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                    return;
                }

                if (dataRegisNo == txt_regisno.Text)
                {
                    dataRegisNo = null;
                }
                if (dataOwner == txt_owner.Text)
                {
                    dataOwner = null;
                }
                if (dataStatus == status_list.SelectedValue)
                {
                    dataStatus = null;
                }
                if (dataRentPrice == num_car_rent.Text)
                {
                    dataRentPrice = "0";
                }


                // insert car_history 
                string queryhader = @"INSERT INTO car_history (regis_no,
                                                           car_owner,
                                                           car_status,
                                                           rent_price,
                                                           history_datetime,
                                                           Id_Card,
                                                           Chassis_No)";

                string valuesinsert = $"VALUES('{dataRegisNo}'" +
                                            $", '{dataOwner}' " +
                                            $", '{dataStatus}' " +
                                            $", {dataRentPrice} " +
                                            $", '{histotry_datetime}'" +
                                            $", {userid} " +
                                            $", '{chassis_no}')";

                string queryFull = queryhader + valuesinsert;

                var resultInsert = cmd.Insert_Update_Command(queryFull);

                // 2.
                // new data
                var regis_no = txt_regisno.Text;
                var car_owner = txt_owner.Text;
                var car_status = status_list.SelectedValue;
                var rent_price = num_car_rent.Text;

                // Update car 
                string updateCar = $@"UPDATE car 
                                        SET regis_no = '{regis_no}', 
                                        car_owner = '{car_owner}', 
                                        car_status = '{car_status}', 
                                        rent_price = {rent_price} 
                                  WHERE Chassis_No = '{chassis_no}'";

                var resultUpdate = cmd.Insert_Update_Command(updateCar);

                if (resultUpdate > 0 && resultInsert > 0)
                {
                    string sweetAlertScript = $"Swal.fire({{ title: 'Edit Car', " +
                                                          $"text: 'Success', " +
                                                          $"icon: 'success', confirmButtonText: 'OK' }}).then((result) => " +
                                                                    $"{{ if (result.isConfirmed) " +
                                                                            $"{{ window.location.href = '/Page_Employee/CarList.aspx'; }} }});";
                    ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
                }
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------
        }

    }
}