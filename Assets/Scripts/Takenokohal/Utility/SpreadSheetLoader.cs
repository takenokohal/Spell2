using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Takenokohal.Utility
{
    public static class SpreadSheetLoader
    {
        public static async UniTask<List<T>> LoadData<T>(string url)
        {
            var req = UnityWebRequest.Get(url);
            var result = await req.SendWebRequest();
            var csv = result.downloadHandler.text;
            var json = CsvConverter.CsvToJson(csv);

            var target = new List<T>();
            JsonConvert.PopulateObject(json, target, new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            });
            Debug.Log(target.Count);
            return target;
            return JsonConvert.DeserializeObject<List<T>>(json, new JsonSerializerSettings()
            {
                ObjectCreationHandling = ObjectCreationHandling.Replace
            });
        }
    }
}