using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class ViewCar : System.Web.UI.Page
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
    }
}