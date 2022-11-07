using System;
using System.ComponentModel;
using System.Globalization;

namespace DemoAPI.Models
{
	public class PatientTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
			{
				return true;
			}
			return base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return new Patient()
				{
					Age = 25,
					PatientName = "Joe",
					SSN = "135-85-7851",
					PhoneNumber = "258-523-4527",
					Status = "Free",
				};
				//Patient patient = (Patient)value;
			}
			return base.ConvertFrom(context, culture, value);
		}
		//public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		//{
		//	return base.ConvertTo(context, culture, value, destinationType);
		//}
	}
}