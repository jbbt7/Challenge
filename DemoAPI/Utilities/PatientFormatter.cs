using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Utilities
{
	public class SimplePatientFormatter : IPatientFormatter
	{
		const string DoubleQuotes= "\"";
		/// <summary>
		/// Replace enclosing double quotes with enclosing straight brackets in patients data
		/// </summary>
		/// <param name="patients"></param>
		/// <returns>
		/// Formatted string
		/// </returns>
		public string FormatPatients(string patients)
		{
			string formattedPatients = string.Empty;
			patients = patients.Substring(1, patients.LastIndexOf('\"') - 1) // Exclude first and last double quotes
					.Replace("\",\"", "] [")        // Replace i.e. <field1>","<field2>  with <field1>] [<field2>  in the middle of the data
					.Replace("\"\r\n\"", "]\r\n[")  // Replace i.e. <field1>","<field2>  with <field1>] [<field2>  at the end of record to the next record
					.Replace("\"\r\n", "]\r\n")     // Insert "]" Take care of last row ]
					.Replace("\",", "] [")          // Replace double quotes before field Age
					.Replace(",\"", "] [")          // Replace comma after field Age
					.Replace("\"", "");
			formattedPatients = $"[{patients}]";
			return formattedPatients;
		}
	}
}