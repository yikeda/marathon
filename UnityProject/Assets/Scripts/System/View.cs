using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Inhouse.View
{
	public class View : MonoBehaviour
	{
		protected Queue<EventInfo> mEvents;
		
		public void Awake()
		{
			mEvents = new Queue<EventInfo>();
			this.transform.parent = ViewEngine.SharedInstance().transform;
		}
		
		public bool TryPopEvent(out EventInfo eventInfo)
		{
			if(mEvents.Count == 0){
				eventInfo = null;
				return false;
			}
			eventInfo = mEvents.Dequeue();
			return true;
		}

		public void ClearEvent()
		{
			mEvents.Clear();
		}

		protected void handleEvent(EventInfo eventInfo)
		{
			mEvents.Enqueue(eventInfo);
		}		
	}
}