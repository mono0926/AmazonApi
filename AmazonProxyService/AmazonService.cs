using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mono.Api.AmazonApi;
using Mono.Framework.Common.Extensios;

namespace Mono.Api.AmazonProxyService
{
    // メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にクラス名 "Service1" を変更できます。
    public class AmazonService : IAmazonService
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string ItemSearch(CountryType countryType, SearchIndexType indexType, int itemPage = 1)
        {
            var cachePath = @"C:\amazon\cache";
            if (!Directory.Exists(cachePath))
            {
                Directory.CreateDirectory(cachePath);
            }

            var filepath = Path.Combine(cachePath, string.Format("{0}-{1}-{2}.cache", countryType, indexType, itemPage));
            
            lock(filepath)
            {
                try
                {
                    if (File.Exists(filepath))
                    {
                        var file = new FileInfo(filepath);
                        if (file.LastWriteTime.CompareTo(DateTime.Now.AddMinutes(-30)) > 0)
                        {
                            return File.ReadAllText(filepath);
                        }
                        //File.Delete(filepath);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }


            var client = new AmazonClient(countryType);

            var accessFilePath = Path.Combine(cachePath, @"last_access.txt");
            if (!File.Exists(accessFilePath))
            {
                File.WriteAllText(accessFilePath, DateTime.Now.ToString());
            }
            var lastAccessInfo = new FileInfo(accessFilePath);
            if (lastAccessInfo.LastWriteTime.CompareTo(DateTime.Now.AddSeconds(-1)) > 0)
            {
                Thread.Sleep(1000);
            }
            File.SetLastWriteTime(accessFilePath, DateTime.Now);
            var response = client.ItemSearch(indexType, itemPage:itemPage);

            lock (filepath)
            {
                try
                {
                    File.WriteAllText(filepath, response);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }

            return response;
        }


        public IEnumerable<SearchIndexType> AvailableTypes(CountryType countryType)
        {
            var results = new List<SearchIndexType>();
            foreach (SearchIndexType e in Enum.GetValues(typeof(SearchIndexType)))
            {
                if (e.ToBrowseNode(countryType) != null)
                {
                    results.Add(e);
                }
            }
            return results;
        }


        public IEnumerable<CountryType> AvailableCountries()
        {
            return new CountryType[]
            {
                CountryType.Japan,
                CountryType.US,
                CountryType.UK,
                CountryType.France,
                CountryType.Germany,
                CountryType.Canada,
            };
        }
    }
}
