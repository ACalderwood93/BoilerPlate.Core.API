using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.Helpers
{
    public static class Helpers
    {
        public static T GetAttribute<T, U>() where T : class
        {
            var atrib = typeof(U).GetCustomAttributes(typeof(T), true).FirstOrDefault() as T;
            if (atrib != null)
            {
                return atrib;
            }
            return null;
        }
    }
}
