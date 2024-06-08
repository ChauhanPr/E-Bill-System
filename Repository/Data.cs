using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models;
using WebApplication14.Repository;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication14.Repository
{
	public class Data : IData
	{
		public string ConnectionString { get; set; }
		public Data()
		{
			ConnectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
		}
		public void SaveBillDetail(BillDetails details)
		{
			SqlConnection con = new SqlConnection(ConnectionString);
			try
			{
				con.Open();
				SqlCommand cmd = new SqlCommand("", con);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				con.Close();
			}
		}
	}
}