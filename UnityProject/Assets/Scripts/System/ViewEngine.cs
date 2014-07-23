using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Inhouse.View
{
	public class ViewEngine : MonoBehaviour
	{
		static ViewEngine sViewEngine;
		
		List<View> mViews;
		
		private ViewEngine(){}
		
		public static ViewEngine SharedInstance()
		{
			if (sViewEngine == null) {
				GameObject gameObject = new GameObject("ViewEngine");
				sViewEngine = gameObject.AddComponent<ViewEngine>();
				DontDestroyOnLoad(gameObject);
			}
			return sViewEngine;
		}
		
		void Start()
		{
		}
		
		void LateUpdate()
		{
			foreach (View view in mViews)
			{
				view.ClearEvent();
			}
		}
				
		public void AddView(string viewName)
		{
			if (mViews == null)
				mViews = new List<View>();

			GameObject gameObject = new GameObject(viewName);
			View view = (View)gameObject.AddComponent(viewName);
			
			if (view != null)
			{
				mViews.Add(view);
			}			
		}

		public void RemoveView(string viewName)
		{
			View view = mViews.Find(s => s.GetType().ToString() == viewName);
			Destroy(view.gameObject);
			mViews.RemoveAll(s => s.GetType().ToString() == viewName);
		}		

		public bool TryPopEvent(string viewName, out EventInfo eventInfo)
		{
			eventInfo = null;

			View view = mViews.Find(s => s.GetType().ToString() == viewName);

			if (view == null)
				return false;

			if (!view.TryPopEvent(out eventInfo))
				return false;
			
			return true;
		}

		public View View(string viewName)
		{
			return mViews.Find(s => s.GetType().ToString() == viewName);						
		}

	}
}
