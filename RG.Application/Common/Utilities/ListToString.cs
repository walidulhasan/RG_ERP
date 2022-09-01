using System;
using System.Collections.Generic;
using System.Linq;

namespace RG.Application.Common.Utilities
{
    public class ListToString 
    {
    //    private static List<T> NewList<T> { get; set; } = new List<T>();
        public static List<T> StringToIntList<T>(string data, string Seperator = ",")
        {
            List<T> NewList = new List<T>();
            // var newData = data.Split(Seperator).Select(int.Parse).ToList();
            var newData = data.Split(Seperator).Select(n=> (T)Convert.ChangeType(n,typeof(T))).ToList();
            if (newData.Count > 0)
            {
                foreach (var i in newData)
                {
                    NewList.Add(i);

                }
            }
            return NewList;
        }

        public static string IntListToString(List<int> Data, string Seperator = ",")
        {
            var str = Data.Select(s => s.ToString()).Aggregate((f, l) => f + Seperator + l);
            return str;
        }
    }
}
