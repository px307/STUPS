﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 11/29/2012
 * Time: 12:23 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSXUnitTests.Commands.Driver.ChromeOptions
{
    using SePSX;
    using SePSX.Commands;
    using MbUnit.Framework;
    using OpenQA.Selenium.Chrome;
    using System.Collections.ObjectModel;
    using Autofac;
    
    /// <summary>
    /// Description of AddSeChromeExtensionCommandTestFixture.
    /// </summary>
    [TestFixture]
    public class AddSeChromeExtensionCommandTestFixture
    {
        public AddSeChromeExtensionCommandTestFixture()
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
        
        [Test]
        [Category("Fast")]
        [Ignore]
        public void ChromeOptions_add_one_extension()
        {
            string[] expected = { "SePSX.dll" };
            AddSeChromeExtensionCommand cmdlet =
                //new AddSeChromeExtensionCommandTestFixture();
                WebDriverFactory.Container.Resolve<AddSeChromeExtensionCommand>();
            //AddSeChromeExtensionCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.ExtensionList =
                expected;
            SeAddChromeExtensionCommand command =
                new SeAddChromeExtensionCommand(cmdlet);
            command.Execute();
            System.Collections.Generic.List<string> listOfArguments =
                new System.Collections.Generic.List<string>();
            listOfArguments.Add(expected[0]);
            ReadOnlyCollection<string> expectedList =
                new ReadOnlyCollection<string>(listOfArguments);
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).Extensions);
            Assert.AreEqual(
                expectedList,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Extensions);
        }
        
        [Test]
        [Category("Fast")]
        [Ignore]
        public void ChromeOptions_add_five_extensions()
        {
            string[] expected = { "SePSX.dll", "SePSX.dll", "SePSX.dll", "SePSX.dll", "SePSX.dll" };
            AddSeChromeExtensionCommand cmdlet =
                //new AddSeChromeExtensionCommandTestFixture();
                WebDriverFactory.Container.Resolve<AddSeChromeExtensionCommand>();
            //AddSeChromeExtensionCommand.UnitTestMode = true;
            cmdlet.InputObject =
                //WebDriverFactory.GetChromeOptions();
                // resolve ChromeOptions
                WebDriverFactory.Container.Resolve<ChromeOptions>();
            cmdlet.ExtensionList =
                expected;
            SeAddChromeExtensionCommand command =
                new SeAddChromeExtensionCommand(cmdlet);
            command.Execute();
            System.Collections.Generic.List<string> listOfArguments =
                new System.Collections.Generic.List<string>();
            listOfArguments.Add(expected[0]);
            listOfArguments.Add(expected[1]);
            listOfArguments.Add(expected[2]);
            listOfArguments.Add(expected[3]);
            listOfArguments.Add(expected[4]);
            ReadOnlyCollection<string> expectedList =
                new ReadOnlyCollection<string>(listOfArguments);
            //Assert.AreEqual(expectedList, (SePSX.CommonCmdletBase.UnitTestOutput[0] as ChromeOptions).Extensions);
            Assert.AreEqual(
                expectedList,
                ((ChromeOptions)(object)PSTestLib.UnitTestOutput.LastOutput[0]).Extensions);
        }
    }
}
