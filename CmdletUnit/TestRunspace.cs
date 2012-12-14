﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 09:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace CmdletUnitTest
{
    using System;
    using System.Diagnostics;
    using System.Management.Automation;
//    using System.Management.Automation.Runspaces;
    
    using MbUnit.Framework;//using MbUnit.Framework; // using MbUnit.Framework;
    
    using System.Collections.Generic;
    
    /// <summary>
    /// Description of TestRunspace.
    /// </summary>
    public static class TestRunspace
    {
        
        private static bool showCode = true;

        public static bool IitializeRunspace(string command)
        {
            return PSRunner.Runner.IitializeRunspace(command);
        }
        
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(string codeSnippet)
        {
            return PSRunner.Runner.RunPSCode(codeSnippet, showCode);
        }
        
        public static bool CloseRunspace()
        {
            return PSRunner.Runner.CloseRunspace();
        }
        
        public static void RunAndGetTheException(
            string codeSnippet, 
            string exceptionType,
            string message)
        {
            //reportRunningCode(codeSnippet);
            try{
                System.Collections.ObjectModel.Collection<PSObject> coll =
                    PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            }
            catch (Exception ee) {
                Assert.AreEqual(exceptionType, ee.GetType().Name);
                //Assert.AreEqual(message, ee.Message);
                if (!ee.Message.Contains(message)) {
                    //Assert.Fail("Exception description does not match: ", new object[]{ ee.Message });
                    Assert.Fail("Exception description does not match: " + ee.Message);
                }
            }
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndCheckParameters(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                "CmdletInvocationException",
                "Parameters checked");
        }
        
        public static void RunAndCheckParameters_ParameterMissing(string codeSnippet)
        {
            RunAndGetTheException(
                codeSnippet,
                "ParameterBindingException",
                "Cannot process command because of one or more missing mandatory parameters:");
        }
        
        public static void RunAndEvaluateAreEqual1(string codeSnippet)
        {
            RunAndEvaluateAreEqual(codeSnippet, "1");
        }
        
        public static void RunAndEvaluateIsNull(string codeSnippet)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsNull(coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateIsEmpty(string codeSnippet)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsEmpty(coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateIsTrue(
            string codeSnippet,
            string strValue)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.IsTrue(coll[0].ToString() == strValue);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual(
            string codeSnippet,
            string strValue)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.AreEqual(strValue, coll[0].ToString());
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual(
            string codeSnippet,
            System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> strValues)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            Assert.AreEqual(strValues, coll);
            PSRunner.Runner.FinishRunningCode();
        }
        
        public static void RunAndCompareTwoOutputs(
            string codeSnippet,
            List<int> sourceIndices,
            List<int> targetIndices)
        {
            //reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                PSRunner.Runner.RunPSCode(codeSnippet, showCode);
            List<object> sourceList = new List<object>();
            foreach (int i in sourceIndices) {
                sourceList.Add(coll[i]);
            }
            List<object> targetList = new List<object>();
            foreach (int i in targetIndices) {
                targetList.Add(coll[i]);
            }
            Assert.AreEqual(sourceList, targetList);
            PSRunner.Runner.FinishRunningCode();
        }
        
//        private static void reportRunningCode(string codeSnippet)
//        {
//            finishRunningCode();
//            Console.WriteLine(codeSnippet);
//        }
        
//        private static void finishRunningCode()
//        {
//            Console.WriteLine("# ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
//        }
    }
}