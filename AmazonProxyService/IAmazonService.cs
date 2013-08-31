﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Mono.Api.AmazonApi;

namespace Mono.Api.AmazonProxyService
{
    // メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にインターフェイス名 "IService1" を変更できます。
    [ServiceContract]
    public interface IAmazonService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ここにサービス操作を追加します。

        [OperationContract]
        string ItemSearch(CountryType countryType, SearchIndexType indexType, int itemPage = 1);
        
        [OperationContract]
        IEnumerable<SearchIndexType> AvailableTypes(CountryType countryType);

        [OperationContract]
        IEnumerable<CountryType> AvailableCountries();
    }

    // サービス操作に複合型を追加するには、以下のサンプルに示すようにデータ コントラクトを使用します。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
