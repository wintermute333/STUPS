﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/18/2012
 * Time: 2:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMXUnitTests.Commands.Status
{
    using System;
    using MbUnit.Framework;
    using PSTestLib;
    //using Moq;
    //using Autofac;
    //using Autofac.Builder;
    using TMX;
    
    /// <summary>
    /// Description of GetTMXTestSuiteStatusCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class GetTMXTestSuiteStatusCommandTestFixture
    {
        public GetTMXTestSuiteStatusCommandTestFixture()
        {
        }
        
        [SetUp]
        public void SetUp()
        {
            UnitTestingHelper.PrepareUnitTestDataStore();
        }
        
        [TearDown]
        public void TearDown()
        {
        }
        
//        internal static string getTestSuiteStatus()
//        {
//            NewSuiteCmdletBase cmdlet =
//                new NewSuiteCmdletBase();
//            cmdlet.UnitTest = true; // here is optional
//            cmdlet.Name = "suite";
//            
//            TMXNewTestSuiteCommand command =
//                new TMXNewTestSuiteCommand(cmdlet);
//            command.Execute();
//            
//            return TestData.CurrentTestSuite.Status;
//        }
        
        [Test]
        [Description("Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_New()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithNotTested()
        {
            string expectedResult = TMX.TestData.TestStateNotTested;
            //UnitTestingHelper.CloseTestResult(TestResultStatuses.NotTested);
            UnitTestingHelper.GetNewTestSuite("name", "id", "description");
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithPassed()
        {
            string expectedResult = TMX.TestData.TestStatePassed;

            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, false);

            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed:$false; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithFailed()
        {
            string expectedResult = TMX.TestData.TestStateFailed;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, false);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed -KnownIssue; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithPassedKnownIssue()
        {
            string expectedResult = TMX.TestData.TestStatePassed; //.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Passed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
        
        [Test]
        [Description("New-TMXTestSuite -Name suite1; Close-TMXTestResult -TestResultName result -TestPassed:$false -KnownIssue; Get-TMXTestSuiteStatus")]
        [Category("Fast")]
        public void GetTestSuite_Current_WithFailedKnownIssue()
        {
            string expectedResult = TMX.TestData.TestStateFailed; //.TestStateKnownIssue;
            UnitTestingHelper.CloseTestResult(TestResultStatuses.Failed, true);
            Assert.AreEqual(
                expectedResult,
                UnitTestingHelper.GetTestSuiteStatus());
        }
    }
}
