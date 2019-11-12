using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Helpers.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionName : Attribute
    {
        public string Name { get; set; }
        public CollectionName(string name)
        {
            Name = name;
        }

       
    }
}
