using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.CustomDataAnnotation
{
    public class FutureDatetimeAttribute: ValidationAttribute
    {
        public FutureDatetimeAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
