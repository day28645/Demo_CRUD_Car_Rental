using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_CRUD_Car_Rental.Page_Employee
{
    public partial class ManagerCar_Not_Reserved : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_button_Click(object sender, EventArgs e)
        {
            var startDateTime = start_datetime.Text;
            var endDateTime = end_datetime.Text;

            DateTime cal_pick_date;
            DateTime cal_return_date;
            DateTime current_date = DateTime.Now.Date;

            if (!DateTime.TryParseExact(startDateTime, "yyyy-MM-ddTHH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out cal_pick_date))
            {
                return;
            }

            if (!DateTime.TryParseExact(endDateTime, "yyyy-MM-ddTHH:mm", new CultureInfo("en-US"), DateTimeStyles.None, out cal_return_date))
            {
                return;
            }

            if (cal_return_date < cal_pick_date)
            {
                string sweetAlertScript = $"Swal.fire({{ title: 'Check Not Reserved Car Failed', " +
                                                       $"text: 'End Datetime must be covered Start Datime', " +
                                                       $"icon: 'error', confirmButtonText: 'OK' }}).then((result) => " +
                                                                $"{{ if (result.isConfirmed) " +
                                                                        $"{{ window.location.href = '/Page_Employee/ManagerCar_Not_Reserved.aspx'; }} }});";
                ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", sweetAlertScript, true);
            }

            var cmd = new CRUD_Command();
            try
            {
                string queryCar = $"select concat(b.pick_datetime, ' - ', b.return_datetime) as bookPeriod, b.Book_Id ,b.book_status, c.Chassis_No, c.car_status " +
                                  $"from car c " +
                                  $"left join create_booking cb on c.Chassis_No = cb.Chassis_No " +
                                  $"left join booking b on cb.Book_Id = b.Book_Id " +
                                  $"where c.car_status in ('Ready', 'Not Ready', 'Repiared', 'Reserved') " +
                                  $"and ( " +
                                        $"b.Book_Id is null " +
                                        $"or b.Book_Id not in (" +
                                                $"select Book_Id " +
                                                $"from booking " +
                                                $"where (pick_datetime between '{startDateTime}' and '{endDateTime}' " +
                                                $"or return_datetime between '{startDateTime}' and '{endDateTime}') " +
                                                $"and book_status not in ('pick', 'return', 'cancel completed')" +
                                        $")" +
                                  $"); ";


                var dtCar = cmd.SelectComand(queryCar);

                if (dtCar.Rows.Count > 0)
                {
                    grid_car_result.DataSource = dtCar;
                    grid_car_result.DataBind();
                }
                else
                {
                    grid_car_result.DataSource = "Car Not Found";
                    grid_car_result.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}