﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/11/2012
 * Time: 2:47 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace SePSX
{
    /// <summary>
    /// Description of SeAddFirefoxExtensionCommand.
    /// </summary>
    internal class SeAddFirefoxExtensionCommand : SeCommand
    {
        internal SeAddFirefoxExtensionCommand(CommonCmdletBase cmdlet) : base (cmdlet)
        {
        }
        
        internal override void Execute()
        {
            SeHelper.AddFirefoxExtension(Cmdlet);
        }
    }
}
