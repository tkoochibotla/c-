using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBetting.Services.Attributes
{
    public class ValueAttribute : Attribute
    {
        public string Value { get; protected set; }
    }
}
