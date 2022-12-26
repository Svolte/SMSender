using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace SMSender
{
    public static class Helpers
    {
        public static ExpandoObject ToExpandoObject(this Dictionary<string, object> dict)
        {
            dynamic eo = dict.Aggregate(new ExpandoObject() as IDictionary<string, Object>,
                (a, p) =>
                {
                    a.Add(p);
                    return a;
                });
            return eo;
        }
    }
}