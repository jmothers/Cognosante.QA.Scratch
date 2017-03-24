using System;
using System.ServiceProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quintity.TestFramework.Core;
using Cognosante.QA.TestEngineering.RemoteService.API;

namespace ScratchTestProject
{
    [TestClass]
    public class WindowsService : TestClassBase
    {
        #region Data members
        //protected RemoteOperations remoteOperations = new RemoteOperations(new Uri(TestProperties.GetPropertyValueAsString("RemoteServerUri")));
        #endregion

        #region Constructors

        public WindowsService()
        { }

        #endregion

        #region Test methods

        [TestMethod]
        public TestVerdict StartRemoteWindowsService(
          [TestParameter("Remote Server Uri", "Enter the Uri of the remote server")]
            string remoteServerUri,
         [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
         [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 1000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                RemoteOperations remoteOperations = new RemoteOperations(new Uri(remoteServerUri));
                remoteOperations.StartWindowsService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} has been started.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict StopRemoteWindowsService(
            [TestParameter("Remote Server Uri", "Enter the Uri of the remote server")]
            string remoteServerUri,
           [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
           [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 10000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                RemoteOperations remoteOperations = new RemoteOperations(new Uri(remoteServerUri));
                remoteOperations.StopWindowsService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} has been stopped.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict RestartRemoteWindowsService(
           [TestParameter("Remote Server Uri", "Enter the Uri of the remote server")]
            string remoteServerUri,
          [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
          [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 1000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                RemoteOperations remoteOperations = new RemoteOperations(new Uri(remoteServerUri));
                remoteOperations.RestartWindowsService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} has been started.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict GetRemoteWindowsServiceStatus(
          [TestParameter("Remote Server Uri", "Enter the Uri of the remote server")]
            string remoteServerUri,
         [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName)
        {
            try
            {
                Setup();

                RemoteOperations remoteOperations = new RemoteOperations(new Uri(remoteServerUri));
                var status = remoteOperations.GetWindowsServiceStatus(serviceName);

                TestMessage += $"Service {serviceName} current status is \"{status}\".";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict StartServiceTest(
            [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
            [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 5000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                TestTrace.Trace($"Starting Windows service {serviceName} with {milliSeconds} wait time.");

                StartService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} started.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict StopServiceTest(
          [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
          [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 5000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                TestTrace.Trace($"Stopping Windows service {serviceName} with {milliSeconds} wait time.");

                StopService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} stopped.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict RestartServiceTest(
          [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
          [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 5000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                TestTrace.Trace($"Restarting Windows service {serviceName} with {milliSeconds} wait time.");

                RestartService(serviceName, milliSeconds);

                TestMessage += $"Service {serviceName} restarted.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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
        public TestVerdict GetServiceStatusTest(
          [TestParameter("Service Name", "Enter the name of the service to start")]
            string serviceName,
          [TestParameter("Timeout (milliseconds)", "Enter the timeout to start in milliseconds", 5000)]
            int milliSeconds)
        {
            try
            {
                Setup();

                TestTrace.Trace($"Getting Windows service \"{serviceName}\" status.");

                var status = GetServiceStatus(serviceName);

                TestMessage += $"Service \"{serviceName}\" status:  {status}.";
                TestVerdict = TestVerdict.Pass;
            }
            catch (TestAssertFailedException e)
            {
                TestMessage += e.ToString();
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

        #region Private methods

        public static void StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);

            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                throw;
            }
        }

        public static void StopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);

            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch
            {
                throw;
            }
        }

        public static void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);

            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                throw;
            }
        }

        public static ServiceControllerStatus GetServiceStatus(string serviceName)
        {
            ServiceController service = new ServiceController(serviceName);

            return service.Status;
        }

        #endregion

        #region Protected methods

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
