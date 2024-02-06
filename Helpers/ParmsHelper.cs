using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TharstenAPI.Helpers
{
    public static class ParmsHelper
    {
        public static string ParseParm(string pName, string pValue)
        {
            return false == string.IsNullOrEmpty(pValue) ? $"{pName}={pValue}" : string.Empty;
        }

        public static string ParseParm(string pName, int? pValue)
        {
            return pValue.HasValue ? $"{pName}={pValue.Value}" : string.Empty;
        }

        public static string ParseParm(string pName, bool? pValue)
        {
            return pValue.HasValue ? $"{pName}={pValue.Value}" : string.Empty;
        }

        public static string ParseParm(string pName, DateTime? pValue)
        {
            return pValue.HasValue ? $"{pName}={pValue.Value}" : string.Empty;
        }

        public static List<string> ParseParm(string pName, int[] pValues)
        {
            var results = new List<string>();
            if (pValues != null && pValues.Any())
            {
                foreach (var pValue in pValues)
                {
                    results.Add($"{pName}={pValue}");
                }
            }

            return results;
        }

        public static List<string> ParseParm(string pName, string[] pValues)
        {
            var results = new List<string>();
            if (pValues != null && pValues.Any())
            {
                foreach (var pValue in pValues)
                {
                    results.Add($"{pName}={pValue}");
                }
            }

            return results;
        }
    }
}
