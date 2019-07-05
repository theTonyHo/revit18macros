/*
 * Created by SharpDevelop.
 * User: t.ho
 * Date: 5/07/2019
 * Time: 10:28 AM
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
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("3C75B2E4-B45A-436D-9E9B-08D27287D06A")]
	public partial class ThisApplication
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
		public void GetCurrentViewName()
		{
		string viewName = ActiveUIDocument.Document.ActiveView.Name;
		
		SWF.Clipboard.Clear();
		SWF.Clipboard.SetText(viewName);
					
		TaskDialog.Show("Revit", "Copied to Clipboard : \"" + viewName + "\"");
		
		}
		
	}
}