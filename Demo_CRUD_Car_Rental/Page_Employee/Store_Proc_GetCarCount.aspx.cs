using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class Store_Proc_GetCarCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void count_car_transaction_Click(object sender, EventArgs e)
        {
            try
            {
                var chassisNo = txt_chassis_no.Text;
                var cmd = new CRUD_Command();

                var inParameters = new Dictionary<string, object>
                {
                    { "pCarId", chassisNo }
                };

                var outParameters = new Dictionary<string, MySqlParameter>
                {
                    { "pCustomerCount", new MySqlParameter("pCustomerCount", MySqlDbType.Int32) },
                    { "pDateTime", new MySqlParameter("pDateTime", MySqlDbType.VarChar, 25) }
                };

                var resultTable = cmd.SelectStoreProcedure("GetCarCount", inParameters, outParameters);

                int customerCount = Convert.ToInt32(outParameters["pCustomerCount"].Value);
                txt_count_car.Text = customerCount.ToString();

                string recentDatetime = outParameters["pDateTime"].Value.ToString();
                txt_datetime.Text = recentDatetime;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}