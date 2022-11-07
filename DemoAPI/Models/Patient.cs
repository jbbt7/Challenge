using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace DemoAPI.Models
{
	[TypeConverter(typeof(PatientTypeConverter))]
	public class Patient
	{
		public string PatientName { get; set; }	
		public string SSN { get; set; }
		public int Age { get; set; }
		public string PhoneNumber { get; set; }
		public string Status { get; set; }

		public override string ToString()
		{
			return $"[{PatientName}] [{SSN}] [{Age}] [{PhoneNumber}] [{Status}]";
		}
	}
}