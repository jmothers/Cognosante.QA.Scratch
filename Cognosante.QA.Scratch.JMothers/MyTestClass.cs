using System;
using Quintity.TestFramework.Core;

namespace ScratchTestProject
{
    [TestClass]
    public class MyTestClass : TestClassBase
    {
        #region Test methods

        [TestMethod]
        public TestVerdict MyTestMethod(
            [TestParameter("My string parameter", "This is the description")]
            string stringParam)
        {
            try
            {
                Setup();



                TestMessage = stringParam;
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
