using DataHarmonizationProcessor.Business.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using UMPG.USL.Common;
using UMPG.USL.Models.LicenseModel;

namespace DataHarmonizationProcessor.Business.Services
{
    public class LicenseProductService : ILicenseProductService
    {
        private readonly IDataHarmonizationLogManager _logManager;

        public LicenseProductService(IDataHarmonizationLogManager dataHarmonizationLogManager)
        {
            _logManager = dataHarmonizationLogManager;
        }

        public List<LicenseProduct> GetProductsNew(int licenseId)
        {
            var apiUrl = ConfigHelper.GetAppSettingValue("apiServiceUrl", true);
            apiUrl = string.Format(apiUrl + "/api/licenseProductCTRL/licenseproducts/GetProductsNew/{0}", licenseId);
           return SendGetRequest(apiUrl);
        }

        //private List<LicenseProduct> SendGetRequest(string apiUrl)
        //{
        //    WebRequest webRequest = WebRequest.Create(apiUrl);
        //    webRequest.Method = "GET";


        //    using (var client = new WebClient())
        //    {
        //        var resultString = client.DownloadString(apiUrl);
        //        JavaScriptSerializer js = new JavaScriptSerializer();

        //        var result = (List<LicenseProduct>)js.Deserialize(resultString, typeof(List<LicenseProduct>));
        //        var test = result;
        //        return test;
        //    }


        //    using (var response = (HttpWebResponse)webRequest.GetResponse())
        //  {
        //      try
        //      {
        //          using (var reader = new StreamReader(response.GetResponseStream()))
        //          {

        //              var objText = reader.ReadToEnd();
        //                JavaScriptSerializer js = new JavaScriptSerializer();
        //                return (List<LicenseProduct>)js.Deserialize(objText, typeof(List<LicenseProduct>));
        //          }
        //      }
        //      catch (Exception e)
        //      {
        //          _logManager.LogErrors(e);
        //          throw new Exception("Error retriving Recs data. Error: " + e.ToString());
        //      }
        //  }



        //}

        private List<LicenseProduct> SendGetRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var responseStream = request.GetResponse().GetResponseStream();
            string sendThis = "";
            List < LicenseProduct > resultLicenseProducts = new List<LicenseProduct>();
            if (responseStream != null)
            {
                string response;
                using (var stream = new StreamReader(responseStream))
                {
                    response = stream.ReadToEnd();
                    JsonConvert.PopulateObject(response, resultLicenseProducts);

                }
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //resultLicenseProducts =(List<LicenseProduct>)js.Deserialize(response, typeof(List<LicenseProduct>));
            }
            return resultLicenseProducts;
        }
    }
    
}