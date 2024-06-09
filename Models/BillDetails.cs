using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models;

namespace WebApplication14.Models
{
	public class BillDetails
	{
		public int Id { get; set; }
		public string custname { get; set; }
		public int contact { get; set; }
		public string address { get; set; }
		public int total { get; set; }
		public List<Items> Items { get; set; }

		public BillDetails()
		{

		}

	}
}