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
				SqlCommand cmd = new SqlCommand("saveBillDetails", con);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@CustomerName",details.custname);
				cmd.Parameters.AddWithValue("@MobileNumber",details.contact);
				cmd.Parameters.AddWithValue("@Address",details.address);
				cmd.Parameters.AddWithValue("@TotalAmount",details.total);

				SqlParameter outputPara = new SqlParameter();
				outputPara.DbType = DbType.Int32;
				outputPara.Direction = ParameterDirection.Output;
				outputPara.ParameterName = "@Id";
				cmd.Parameters.Add(outputPara);
				cmd.ExecuteNonQuery();
				int id = int.Parse(outputPara.Value.ToString());
				if(details.Items.Count>0)
				{
					SaveBillItems(details.Items, con, id);
				}

				
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
		void SaveBillItems(List<Items> items, SqlConnection con, int id)
		{
			try
			{
				string qry = "insert into BillItems(prodname,price,quantity) values";
				foreach(var item in items)
				{
					qry += String.Format("('{0}',{1},{2},{3}),",item.prodname,item.price,item.quantity,id);

				}
				qry = qry.Remove(qry.Length - 1);
				SqlCommand cmd = new SqlCommand(qry, con);
				cmd.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
		}
		void IData.SaveBillItems(List<Items> items, SqlConnection con, int id)
		{
			throw new NotImplementedException();
		}
	}
}