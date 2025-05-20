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
    public partial class CarList : System.Web.UI.Page
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
            string query = $"SELECT chassis_no, brand, model, car_type, color, fuel, rent_price, car_status, register_datetime, image FROM car";

            try
            {
                var cmd = new CRUD_Command();
                DataTable carData = cmd.SelectComand(query);

                if (carData.Rows.Count > 0)
                {
                    grid_car_list.DataSource = carData;
                    grid_car_list.DataBind();
                }
                else
                {
                    grid_car_list.EmptyDataText = "Car Not Found";
                    grid_car_list.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void grid_car_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit_command")
            {
                var chassisNo = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(chassisNo))
                {
                    Response.Redirect($"~/Page_Employee/EditCar.aspx?chassis_no={chassisNo}");
                }
            }
            else if (e.CommandName == "view_command")
            {
                var chassisNo = e.CommandArgument.ToString();
                if (!string.IsNullOrEmpty(chassisNo))
                {
                    Response.Redirect($"~/Page_Employee/ViewCar.aspx?chassis_no={chassisNo}");
                }
            }
        }

        protected void grid_car_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grid_car_list.EditIndex = e.NewEditIndex;
            BindCarData();
        }

    }
}