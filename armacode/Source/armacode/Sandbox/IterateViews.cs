/*
 * Created by SharpDevelop.
 * User: t.ho
 * Date: 5/07/2019
 * Time: 12:21 PM
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
	/// Description of IterateViews
	/// </summary>
	public partial class ThisApplication
	{

		private void IterateViews()
		{
		//Non working attempt to retrieve "Project View"
		//Project Browser is an internal view, which can not be set as active view programmatically.
		
		IList<UIView> views= ActiveUIDocument.GetOpenUIViews();
		string viewIds = "view count: " + views.Count.ToString() + "\n\r";
		for (int i = 0; i < views.Count; i++)
		{
			UIView view = views[i];
			viewIds += view.ViewId.ToString();
			viewIds += view.ToString();
			viewIds += "\n\r";
		}
		TaskDialog.Show("Revit", viewIds);
		
		UIApplication application = this;
		UIDocument uidoc = application.ActiveUIDocument;
		Document document = application.ActiveUIDocument.Document;
		
		FilteredElementCollector viewCollector = new FilteredElementCollector(document);
		viewCollector.OfClass(typeof(Autodesk.Revit.DB.View));
		TaskDialog.Show("Revit", viewCollector.Count().ToString());
		TaskDialog.Show("Revit", "BEFORE : " + ActiveUIDocument.Document.ActiveView.Name + "Cat:" + ActiveUIDocument.Document.ActiveView.ViewType);
		foreach (Element viewElement in viewCollector)
		{
		  Autodesk.Revit.DB.View view = (Autodesk.Revit.DB.View)viewElement;
		  if (view.ViewType == ViewType.ProjectBrowser){
//		  	uidoc.ActiveView = view;
		  	uidoc.RequestViewChange(view);
		  }
		  //Do something...
		}
		
//		internal static List<Autodesk.Revit.DB.View> SheetsAndView()
//        {
//            Document doc = DocumentManager.Instance.CurrentDBDocument;
//            FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views);
//            List<Autodesk.Revit.DB.View> viewList = collector.ToElements() as List<Autodesk.Revit.DB.View>;
//
//            return viewList;
//        }
		
//		
//		UIDocument uiDoc = ActiveUIDocument;
////		UIView view = uiDoc.GetOpenUIViews().FirstOrDefault(item => item.ViewId.ToString() == "Project View");
//		UIView view = uiDoc.GetOpenUIViews().FirstOrDefault(item => TaskDialog.Show("Revit", item.ViewId.ToString()));
		}
		
	}
}
