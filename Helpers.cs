using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Npoi.Mapper;

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

        public static Dictionary<string, object> ToDictionary(this RowInfo<dynamic> rowInfo)
        {
            var dict = new Dictionary<string, object>();
            foreach (var prop in rowInfo.Value.GetType().GetProperties())
            {
                var value = prop.GetValue(rowInfo.Value);
                dict.Add(prop.Name, (object) prop.GetValue(rowInfo.Value));
            }

            return dict;
        }
    }
}