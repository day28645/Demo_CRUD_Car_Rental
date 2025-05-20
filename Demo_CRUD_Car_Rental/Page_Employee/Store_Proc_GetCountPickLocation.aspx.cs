using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class Store_Proc_GetCountPickLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void pick_location_Click(object sender, EventArgs e)
        {
            var loc_name = txt_locname.Text;
            var cmd = new CRUD_Command();

            try
            {
                var inParameters = new Dictionary<string, object>
                {
                    { "pLocation", loc_name }
                };

                var outParameters = new Dictionary<string, MySqlParameter>
                {
                    { "countPick", new MySqlParameter("countPick", MySqlDbType.Int32) }
                };

                var dtResult = cmd.SelectStoreProcedure("GetPickCountLocation", inParameters, outParameters);

                if (outParameters["countPick"].Value != DBNull.Value)
                {
                    int pickCount = Convert.ToInt32(outParameters["countPick"].Value);
                    txt_pick_location.Text = pickCount.ToString();
                }
                else
                {
                    txt_pick_location.Text = "0"; 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}