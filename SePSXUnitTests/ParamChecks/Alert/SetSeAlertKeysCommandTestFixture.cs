﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 9/3/2012
 * Time: 1:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.ParamChecks
{
    using System;
    using SePSX; using MbUnit.Framework;
    using OpenQA.Selenium;
    
    /// <summary>
    /// Description of SetSeAlertKeysCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "SeAlertKeys")]
    [OutputType(typeof(bool))]
    public class SetSeAlertKeysCommandTestFixture // AlertCmdletBase
    {
        public SetSeAlertKeysCommandTestFixture()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true,
                   Position = 0)]
        public string Text { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            this.checkInputAlert(true);
            
            SeHelper.AlertSendKeys(this, this.InputObject, this.Text);
        }
    }
}