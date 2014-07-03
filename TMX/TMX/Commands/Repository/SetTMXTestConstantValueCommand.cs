﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 11:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace TMX.Commands
{
    using System;
    using System.Management.Automation;
	using TMX.Interfaces;
    
    /// <summary>
    /// Description of SetTmxTestConstantValueCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "TmxTestConstantValue")]
    [OutputType(typeof(ITestConstant))]
    public class SetTmxTestConstantValueCommand : TestConstantCmdletBase
    {
        public SetTmxTestConstantValueCommand()
        {
        }
    }
}
