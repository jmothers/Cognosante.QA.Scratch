using System;
using System.Threading;
using System.IO;
using System.Text;
using log4net;
using log4net.Config;
using Quintity.TestFramework.Core;

namespace Quintity.QA.Scratch.Test
{
    [TestClass]
    public class ScratchMethods : TestClassBase
    {
        // Define a static logger variable so that it references the
        // Logger instance named "MyApp".
        private static readonly ILog log = LogManager.GetLogger("A1");


        public ScratchMethods()
        {
            // Set up a simple configuration that logs on the console.
            //var configure = BasicConfigurator.Configure();

            var fileInfo = new FileInfo($"{TestProperties.TestData}\\Log4Net.config");

            var config = XmlConfigurator.Configure(fileInfo);

            //new log4net.Appender.DebugAppender()

            //log.Info("Entering application.");
            //log.Info("Exiting application.");
        }

        #region Test methods

        [TestMethod]
        public TestVerdict TestUsersGeneration(
            int startNumber)
        {
            try
            {
                Setup();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("\"First Name\",\"Last Name\",\"User Name\",\"Title\"");

                for (int i = startNumber; i <= 1000; i++)
                {
                    var testUser = string.Format("Test.User{0:D4}", i);
                    var record = $"\"{testUser}\",\"\",\"az\\{testUser}\",\"Automation Test User\"";
                    sb.AppendLine(record);
                }

                File.WriteAllText(TestProperties.TestOutput + "/TestUsers.csv", sb.ToString());

                TestMessage = "Complete";
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
        public TestVerdict Wait(
         int milliseconds)
        {
            try
            {
                Setup();

                log.Info("Before wait");

                Thread.Sleep(milliseconds);

                log.Info("After wait");

                TestMessage = "Complete";
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
