/*
 * Created by SharpDevelop.
 * User: t.ho
 * Date: 5/07/2019
 * Time: 12:15 PM
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
	/// Delete Unused views.
	/// REFERENCE: https://archsmarter.com/first-revit-macro/
	/// </summary>
	public partial class ThisApplication
	{

		private void DeleteUnusedViews() {
		  // define current document
		  Document curDoc = this.ActiveUIDocument.Document;
		
		  // get all views
		  FilteredElementCollector viewCollector = new FilteredElementCollector(curDoc);
		  viewCollector.OfCategory(BuiltInCategory.OST_Views);
		
		  // get all sheets
		  FilteredElementCollector sheetCollector = new FilteredElementCollector(curDoc);
		  sheetCollector.OfCategory(BuiltInCategory.OST_Sheets);
		
		  // create a list of views to delete
		  List<View> viewsToDelete = new List<View>();
		
		  // loop through views and check if it's on a sheet
		  foreach (View curView in viewCollector) {
		    // check if current view is a template
		    if(curView.IsTemplate == false) {
		      // check if view can be added to sheet
		      if(Viewport.CanAddViewToSheet(curDoc, sheetCollector.FirstElementId(), curView.Id) == true) {
		        // add view to delete list
		        viewsToDelete.Add(curView);
		      }
		    }
		  }
		
		  // create transaction
		  Transaction curTrans = new Transaction(curDoc);
		  curTrans.Start("Delete Views");
		
		  // delete views in list
		  foreach (View viewToDelete in viewsToDelete) {
		    curDoc.Delete(viewToDelete.Id);
		  }
		
		  // commit changes
		  curTrans.Commit();
		  curTrans.Dispose();
		
		  // alert user
		  TaskDialog.Show("Deleted Views", "Deleted " + viewsToDelete.Count().ToString() + " views.");
		}
	}
}
