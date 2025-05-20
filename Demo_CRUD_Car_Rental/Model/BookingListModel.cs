using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_CRUD_Car_Rental.Model
{
    public class BookingListModel
    {
		public string Book_Id { get; set; }
		public string book_status { get; set; }
		public string pick_date { get; set; }
		public string pick_time { get; set; }
		public string return_date { get; set; }
		public string return_time { get; set; }
		public string total_price { get; set; }
		public string cancel_fee { get; set; }
		public string duration { get; set; }
	}
}