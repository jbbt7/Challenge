using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace DemoAPI.Models
{
	public class PatientModelBinder : IModelBinder
	{
		bool IModelBinder.BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
		{
			if (bindingContext.ModelType != typeof(Patient))
			{
				return	false;
			}

			ValueProviderResult val = bindingContext.ValueProvider.GetValue(
				bindingContext.ModelName);
			if (val == null)
			{
				return false;
			}

			string key = val.RawValue as string;
			if (key == null)
			{
				bindingContext.ModelState.AddModelError(
					bindingContext.ModelName, "Wrong value type");
				return false;
			}

			return false;

		}
	}
}