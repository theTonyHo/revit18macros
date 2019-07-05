/*
 * Created by SharpDevelop.
 * User: t.ho
 * Date: 5/07/2019
 * Time: 2:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using SWF = System.Windows.Forms;

namespace armacode
{
	/// <summary>
	/// Macro Template. This way the macros can be organised separately by its own cs file. Useful for source control per macro.
	/// </summary>
	public partial class ThisApplication
	{

		public void GetCurrentViewName()
		{
		string viewName = ActiveUIDocument.Document.ActiveView.Name;
		
		SWF.Clipboard.Clear();
		SWF.Clipboard.SetText(viewName);
					
		TaskDialog.Show("Revit", "Copied to Clipboard : \"" + viewName + "\"");
		
		}
	}
}
