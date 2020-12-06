using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstDotnetApplication_ServiceLayer.CustomDataAnnotation
{
    public class PositiveAmountAttribute: ValidationAttribute
    {
        public PositiveAmountAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var dt = (Decimal)value;
            if (dt > 0)
            {
                return true;
            }
            return false;
        }
    }
}
