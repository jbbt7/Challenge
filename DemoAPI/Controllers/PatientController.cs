using DemoAPI.Models;
using DemoAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DemoAPI.Controllers
{
	public class PatientController : ApiController
	{
		private IPatientFormatter _patientFormatter;

		public PatientController(IPatientFormatter patientFormatter)
		{
			_patientFormatter = patientFormatter;
		}
		/// <summary>
		/// Version 1 : Few lines of code as possible
		/// </summary>
		/// <param name="inpuString"></param>
		/// <returns>string output</returns>

		//	GET: api/People/Transform
	   [Route("api/1/Patient/Transform")]
	   [HttpGet]
		public IHttpActionResult GetTransform([FromBody] string patientsString)
		{
			string value = _patientFormatter.FormatPatients(patientsString);
			if (!string.IsNullOrEmpty(value))
			{
				return Ok(value);
			}
			else
			{
				return BadRequest("Bad Input values");
			}
		}
	}
}
