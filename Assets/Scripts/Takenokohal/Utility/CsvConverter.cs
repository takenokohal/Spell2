using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Takenokohal.Utility
{
    public static class CsvConverter
    {
        public static string CsvToJson(string csv)
        {
            var v = JsonConvert.SerializeObject(CsvToDictionary(csv));
            return v;
        }

        private static string[] SplitRowToData(string row)
        {
            return row.Split(new[] { ',' }, StringSplitOptions.None);
        }

        private static IReadOnlyList<IReadOnlyDictionary<string, object>> CsvToDictionary(string csv)
        {
            const string splitKey = @"""";
            var rows = csv.Split(new[] { splitKey + "\n" }, StringSplitOptions.None);
            var dataList = rows
                .Select(SplitRowToData).ToList();

            var cleanedData = CleanUp(dataList).ToList();

            var header = cleanedData[0];

            header.RemoveAll(string.IsNullOrEmpty);

            var dicList = new List<Dictionary<string, object>>();
            foreach (var currentRow in cleanedData.Skip(1))
            {
                var dic = new Dictionary<string, object>();
                for (int i = 0; i < header.Count; i++)
                {
                    var dataString = currentRow[i];
                    var key = header[i];
                    if (int.TryParse(dataString, out var result))
                    {
                        dic.Add(key, result);
                        continue;
                    }

                    dic.Add(header[i], dataString);
                }

                dicList.Add(dic);
            }

            return dicList;
        }

        private static List<List<string>> CleanUp(IReadOnlyList<IReadOnlyList<string>> origin)
        {
            var clone = new List<List<string>>();
            foreach (var data in origin.Where(value => !string.IsNullOrEmpty(value[0])))
            {
                var list = data.Select(s => s.Trim(new[]
                {
                    '"'
                })).ToList();

                clone.Add(list);
            }

            return clone;
        }
    }
}