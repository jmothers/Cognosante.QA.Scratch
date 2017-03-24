using System;
using System.IO;
using System.Text;
using System.Net;
using Quintity.TestFramework.Core;

namespace ScratchTestProject
{
    [TestClass]
    public class GetNext : TestClassBase
    {
        #region Test methods

        [TestMethod]
        public TestVerdict PostRequest(
           [TestParameter("CRM Uri", "Enter the CRM Uri")]
            string crmRequestUri,
           string getNext)
        {
            var request = string.Empty;
            try
            {
                Setup();

                request = File.ReadAllText(getNext);

                var response = postRequest(crmRequestUri, request);

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
                            Request Uri:  {crmRequestUri}
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

        private string postRequest(string requestUri, string jsonQuery)
        {
            TestAssert.IsFalse(string.IsNullOrEmpty(requestUri), "The request URI cannot be a null or empty value.");
            TestAssert.IsFalse(string.IsNullOrEmpty(jsonQuery), "The JSON request cannot be a null or empty value.");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            
            // Create web request for json query.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Credentials  = new System.Net.NetworkCredential("adm_jm", "Quasars1!", "Az");
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "text/xml; charset=utf-8";
            request.Accept = @"application/xml, text/xml, */*";
            
            //request.ContentLength = jsonQuery.Length;
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            request.Headers.Add("SOAPAction", @"http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute");

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
