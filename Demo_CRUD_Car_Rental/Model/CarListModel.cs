using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_CRUD_Car_Rental.Model
{
    public class CarListModel
    {
        public string brand { get; set; }
        public string model { get; set; }
        public string rent_price { get; set; }
        public string regis_no { get; set; }
        public string car_status { get; set; }
        public string chassis_no { get; set; }
        public string image { get; set; }
    }
}