using System;
using System.IO;
using System.Text;
using System.Net;
using Quintity.TestFramework.Core;

namespace ScratchTestProject
{
    [TestClass]
    public class SmartyStreets : TestClassBase
    {
        #region Test methods

        [TestMethod]
        public TestVerdict RequestAddress(
            [TestParameter("My string parameter", "This is the description")]
            string requestUri,
            string query)
        {
            try
            {
                Setup();

                var response = getRequest(requestUri, query);

                TestMessage += response;
                TestVerdict = TestVerdict.Pass;
            }
            catch (Exception e)
            {
                TestMessage += e.ToString();
                TestVerdict = TestVerdict.Error;
            }
            finally
            {
                Teardown();
            }

            return TestVerdict;
        }

        [TestMethod]
        public TestVerdict PostRequest(
           [TestParameter("SmartyStreetsUri", "Enter the SmartyStreets Uri")]
            string requestUri,
           [TestParameter("JSON request", "Enter the JSON request.")]
           string request)
        {
            try
            {
                Setup();

                var response = postRequest(requestUri, request);

                TestMessage += response;
                TestVerdict = TestVerdict.Pass;
            }
            catch (System.Net.WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var webResponse = (HttpWebResponse)e.Response;

                    if (webResponse != null)
                    {
                        var streamReader = new StreamReader(webResponse.GetResponseStream());
                        TestMessage += $@"
                            Request Uri:  {requestUri}
                            Query:  {request}
                            Response:  {streamReader.ReadToEnd()}";
                    }
                }

                TestVerdict = TestVerdict.Fail;
            }
            catch (Exception e)
            {
                TestMessage += e.ToString();
                TestVerdict = TestVerdict.Error;
            }
            finally
            {
                Teardown();
            }

            return TestVerdict;
        }

        [TestMethod]
        public TestVerdict PostAddressRequest(
          [TestParameter("SmartyStreetsUri", "Enter the SmartyStreets Uri")]
            string requestUri,
          [TestParameter("JSON request file", "Enter the JSON request file path.")]
           string requestFile)
        {
            string request = string.Empty;
            try
            {
                Setup();

                request = File.ReadAllText(requestFile);

                var response = postAddressRequest(requestUri, request);

                TestMessage += response;
                TestVerdict = TestVerdict.Pass;
            }
            catch (System.Net.WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    var webResponse = (HttpWebResponse)e.Response;

                    if (webResponse != null)
                    {
                        var streamReader = new StreamReader(webResponse.GetResponseStream());
                        TestMessage += $@"
                            Request Uri:  {requestUri}
                            Query:  {request}
                            Response:  {streamReader.ReadToEnd()}";
                    }
                }

                TestVerdict = TestVerdict.Fail;
            }
            catch (Exception e)
            {
                TestMessage += e.ToString();
                TestVerdict = TestVerdict.Error;
            }
            finally
            {
                Teardown();
            }

            return TestVerdict;
        }


        #endregion

        #region Helper methods

        private string getRequest(string requestUri, string jsonQuery)
        {
            TestAssert.IsFalse(string.IsNullOrEmpty(requestUri), "The request URI cannot be a null or empty value.");
            TestAssert.IsFalse(string.IsNullOrEmpty(jsonQuery), "The JSON request cannot be a null or empty value.");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var apiKey = TestProperties.GetPropertyValueAsString("SmartyStreetsAPIKey");
            var query = $"{requestUri}/zipcode?apikey={apiKey}&zipcode=98070";

            // Create web request for json query.
            WebRequest request = (HttpWebRequest)WebRequest.Create(query);
            request.Method = WebRequestMethods.Http.Get;

            // Make request/get response
            WebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }

        private string postRequest(string requestUri, string jsonQuery)
        {
            TestAssert.IsFalse(string.IsNullOrEmpty(requestUri), "The request URI cannot be a null or empty value.");
            TestAssert.IsFalse(string.IsNullOrEmpty(jsonQuery), "The JSON request cannot be a null or empty value.");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            
            // Create web request for json query.
            WebRequest request = (HttpWebRequest)WebRequest.Create(requestUri + "/zipcode");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";
            request.ContentLength = jsonQuery.Length;
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

            var apiKey = TestProperties.GetPropertyValueAsString("SmartyStreetsAPIKey");
            request.Headers.Add("apikey", apiKey);

            // Write query string to request.
            StreamWriter postStream = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            postStream.Write(jsonQuery);
            postStream.Close();

            // Make request/get response
            WebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }

        private string postAddressRequest(string requestUri, string jsonQuery)
        {
            TestAssert.IsFalse(string.IsNullOrEmpty(requestUri), "The request URI cannot be a null or empty value.");
            TestAssert.IsFalse(string.IsNullOrEmpty(jsonQuery), "The JSON request cannot be a null or empty value.");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // Create web request for json query.
            WebRequest request = (HttpWebRequest)WebRequest.Create(requestUri + "/street-address");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";
            request.ContentLength = jsonQuery.Length;
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);

            var apiKey = TestProperties.GetPropertyValueAsString("SmartyStreetsAPIKey");
            request.Headers.Add("apikey", apiKey);

            // Write query string to request.
            StreamWriter postStream = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            postStream.Write(jsonQuery);
            postStream.Close();

            // Make request/get response
            WebResponse response = (HttpWebResponse)request.GetResponse();

            // Get the stream associated with the response.
            Stream responseStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);

            return readStream.ReadToEnd();
        }

        protected override void Setup()
        {
            base.Setup();
        }

        protected override void Teardown()
        {
            base.Teardown();
        }

        #endregion
    }
}
