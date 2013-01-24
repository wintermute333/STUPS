﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/27/2012
 * Time: 11:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace BDDAddinUnitTests.CheckCmdletParameters.BDD
{
    using System;
    using TMX;
    using MbUnit.Framework;

    /// <summary>
    /// Description of NewBDDFeatureCommand_ParamCheck.
    /// </summary>
    [TestFixture]
    public class NewBDDFeatureCommand_ParamCheck
    {
        public NewBDDFeatureCommand_ParamCheck()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspaceForParamChecks();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
        }
        
        [Test]
        [Category("Fast")]
        public void Happy_path()
        {
            CmdletUnitTest.TestRunspace.RunAndCheckCmdletParameters(
                "New-BDDFeature -FeatureName name -Asa user -IWant that -SoThat do;");
        }
    }
}
