using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Reflection;
//using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using Quintity.TestFramework.Core;

namespace Quintity.QA.Scratch.Test
{
    [TestClass]
    public class CSVParsers : TestClassBase
    {
        #region Test methods

        /*
        [TestMethod]
        public TestVerdict VisualBasicParser(
            [TestParameter("CSV File Path", "This is the description")]
            string filePath)
        {
            try
            {
                Setup();

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters("\t");
                    while (!parser.EndOfData)
                    {
                        //parser.ReadLine();

                        //Thread.Sleep(500);

                        //Process row
                        string[] fields = parser.ReadFields();
                        foreach (string field in fields)
                        {

                            int i = 1;
                        }
                    }
                }

                TestMessage = "Success";
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
*/
        class PeopleAddress
        {
            public string Id
            { get; set; }

            public string FirstName
            { get; set; }

            public string LastName
            { get; set; }

            public string Gender
            { get; set; }
            public string SSN
            { get; set; }
            public string Phone
            { get; set; }
            public string Email
            { get; set; }
            public string Street
            { get; set; }
            public string SecondStreet
            { get; set; }
            public string City
            { get; set; }
            public string State
            { get; set; }
            public string Zip
            { get; set; }
            public string Note
            { get; set; }

            public override string ToString()
            {
                return $"{Id}. {FirstName} {LastName} {Gender} {SSN} {Phone} {Email} {Street} {SecondStreet} {City} {State} {Zip} {Note}";
            }
        }

        [TestMethod]
        public TestVerdict CSVHelperParser(
            [TestParameter("CSV File Path", "This is the description")]
            string filePath)
        {

            // http://joshclose.github.io/CsvHelper/

            try
            {
                Setup();

                System.IO.TextReader readFile = new StreamReader(filePath);

                var config = new CsvHelper.Configuration.CsvConfiguration()
                {
                    Delimiter = "\t",
                };

                var csv = new CsvReader(readFile, config);
                var bob = csv.GetRecords<PeopleAddress>();

                foreach(object person in bob)
                {
                    TestTrace.Trace(person.ToString());
                    Thread.Sleep(50);
                }

                //while (csv.Read())
                //{
                //    var record = csv.GetRecord<PeopleAddress>();

                //    //    var id = csv.GetField<string>("Id");
                //    //    var firstName = csv.GetField<string>("FirstName");
                //    //    var lastName = csv.GetField<string>("LastName");

                //    //    TestTrace.Trace($"{id}. {firstName} {lastName}");

                //    //    Thread.Sleep(50);
                //}

                TestMessage = "Success";
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
        public TestVerdict ProcessBUUUpdateFile(
           [TestParameter("BUUUPdate file", "BUUUpdate file to be process")]
            string buuUpdateFile,
           [TestParameter("PeopleAddress file", "PeopleAddress source file to be process")]
            string peopleAddressFile
           )
        {

            // http://joshclose.github.io/CsvHelper/

            try
            {
                Setup();

                var peopleAddresses = getPeopleAddresses(peopleAddressFile);

                var buuUpdates = getBUUUpdates(buuUpdateFile);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 5000; i++)
                {
                    sb.AppendLine(fixupBUUUpdate(buuUpdates[i], peopleAddresses[i]).ToString());
                }

                File.WriteAllText(TestProperties.TestOutput + "\\fred.txt", sb.ToString());

                // This string should be here after rebase.

                TestMessage = "Success";
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
        public TestVerdict DuplicateMethodForRebaseTest(
        [TestParameter("BUUUPdate file", "BUUUpdate file to be process")]
            string buuUpdateFile,
        [TestParameter("PeopleAddress file", "PeopleAddress source file to be process")]
            string peopleAddressFile
        )
        {

            // http://joshclose.github.io/CsvHelper/

            try
            {
                Setup();

                var peopleAddresses = getPeopleAddresses(peopleAddressFile);

                var buuUpdates = getBUUUpdates(buuUpdateFile);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < 5000; i++)
                {
                    sb.AppendLine(fixupBUUUpdate(buuUpdates[i], peopleAddresses[i]).ToString());
                }

                File.WriteAllText(TestProperties.TestOutput + "\\fred.txt", sb.ToString());

                TestMessage = "Success";
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

        private BUUUpdate fixupBUUUpdate(BUUUpdate buuUpdate, PeopleAddress peopleAddress)
        {
            buuUpdate.FFM_PRSN_1ST_NAME = peopleAddress.FirstName.ToUpper();
            buuUpdate.FFM_PRSN_LAST_NAME = peopleAddress.LastName.ToUpper();
            buuUpdate.FFM_PRSN_GNDR_CD = peopleAddress.Gender == "F" ? "FEMALE" : "MALE";
            buuUpdate.FFM_BENE_SSN_KEY = peopleAddress.SSN;
            buuUpdate.FFM_PRSN_MLG_ADR_LINE_1_TXT = !string.IsNullOrEmpty(buuUpdate.FFM_PRSN_MLG_ADR_LINE_1_TXT) ? peopleAddress.Street.ToUpper() : string.Empty;
            buuUpdate.FFM_PRSN_MLG_ADR_CITY_NAME  = !string.IsNullOrEmpty(buuUpdate.FFM_PRSN_MLG_ADR_CITY_NAME) ? peopleAddress.City.ToUpper() : string.Empty;
            buuUpdate.FFM_PRSN_MLG_ADR_STATE_CD  = !string.IsNullOrEmpty(buuUpdate.FFM_PRSN_MLG_ADR_STATE_CD) ? peopleAddress.State.ToUpper() : string.Empty;
            buuUpdate.FFM_PRSN_MLG_ADR_ZIP_CD = !string.IsNullOrEmpty(buuUpdate.FFM_PRSN_MLG_ADR_ZIP_CD) ? peopleAddress.Zip : string.Empty;

            return buuUpdate;
        }

        private void createBUUUpdateObject(string[] headers)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("class BUUUpdate");
            sb.AppendLine("{");

            for(int i = 0; i < headers.Length; i++)
            {
                sb.AppendLine($"public string {headers[i]}");
                sb.AppendLine("{ get; set; }");
                sb.AppendLine();
            }

            sb.AppendLine("}");

            var @class = sb.ToString();

            TestTrace.Trace(@class);

            File.WriteAllText(TestProperties.TestOutput + "\\BUUUpdate.cs", @class);
        }

        private List<PeopleAddress> getPeopleAddresses(string filePath)
        {
            System.IO.TextReader readFile = new StreamReader(filePath);

            var config = new CsvHelper.Configuration.CsvConfiguration()
            {
                Delimiter = "\t",
            };

            var csv = new CsvReader(readFile, config);
            return new List<PeopleAddress>(csv.GetRecords<PeopleAddress>());
        }

        private List<BUUUpdate> getBUUUpdates(string filePath)
        {
            System.IO.TextReader readFile = new StreamReader(filePath);

            var config = new CsvHelper.Configuration.CsvConfiguration()
            {
                Delimiter = "|",
            };

            var csv = new CsvReader(readFile, config);

            return new List<BUUUpdate>(csv.GetRecords<BUUUpdate>());
        }

        #endregion

        #region Helper methods

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
