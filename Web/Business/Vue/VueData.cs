using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Business.Vue
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class VueData : Attribute
    {
        public VueData(string name)
        {
            Name = name;
        }
        public string Name { get; }

    }
}