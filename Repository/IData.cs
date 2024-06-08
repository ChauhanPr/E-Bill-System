using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication14.Models;

namespace WebApplication14.Repository
{
	internal interface IData
	{
		void SaveBillDetail(BillDetails details);
	}
}
