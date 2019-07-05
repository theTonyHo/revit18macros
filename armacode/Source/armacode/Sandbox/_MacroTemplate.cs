/*
 * Created by SharpDevelop.
 * User: t.ho
 * Date: 5/07/2019
 * Time: 12:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace armacode
{
	/// <summary>
	/// Macro Template. This way the macros can be organised separately by its own cs file. Useful for source control per macro.
	/// </summary>
	public partial class ThisApplication
	{
		private void MacroName()
		{
			//Change to public to list macro in the macro browser.
			TaskDialog.Show("Revit", "HELLO WORLD");
			//Do something..
		}
	}
}
