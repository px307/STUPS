﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/19/2012
 * Time: 11:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Tmx
{
    using System;
    using System.Management.Automation;
	using Tmx.Interfaces;
	using Tmx;
    
    /// <summary>
    /// Description of TmxAddTestScenarioCommand.
    /// </summary>
    class TmxAddTestScenarioCommand : TmxCommand
    {
        internal TmxAddTestScenarioCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            var cmdlet = (AddScenarioCmdletBase)Cmdlet;
            
            // 20141112
            var testPlatformId = cmdlet.TestPlatformId;
            if (string.IsNullOrEmpty(testPlatformId))
                if (null == cmdlet.InputObject || string.IsNullOrEmpty(cmdlet.InputObject.PlatformId))
                    testPlatformId = TestData.CurrentTestSuite.PlatformId;
                else
                    testPlatformId = cmdlet.InputObject.PlatformId;
            
            // 20140721
            var dataObject = new AddScenarioCmdletBaseDataObject {
                AfterTest = cmdlet.AfterTest,
                BeforeTest = cmdlet.BeforeTest,
                Description = cmdlet.Description,
                Id = cmdlet.Id,
                InputObject = cmdlet.InputObject,
                Name = cmdlet.Name,
                // 20141112
                // TestPlatformId = cmdlet.TestPlatformId,
                // TestPlatformId = string.IsNullOrEmpty(cmdlet.TestPlatformId) ? (stri cmdlet.InputObject.PlatformId) : cmdlet.TestPlatformId,
                TestPlatformId = testPlatformId,
                TestSuiteId = cmdlet.TestSuiteId,
                TestSuiteName = cmdlet.TestSuiteName
            };
            
            // bool result = TmxHelper.AddTestScenario(cmdlet);
            bool result = TmxHelper.AddTestScenario(dataObject);
            
            if (result)
                cmdlet.WriteObject(
                    cmdlet,
                    TestData.CurrentTestScenario);
            else
                cmdlet.WriteError(
                    cmdlet,
                    "Couldn't add a test scenario",
                    "AddingTestScenario",
                    ErrorCategory.InvalidArgument,
                    true);
        }
    }
}
