using System;

namespace Inhouse.View
{	
	public class EventInfo
	{
		protected string mName;
		protected object mData;
		
		public EventInfo(string pName, object pData = null)
		{
			mName = pName;
			mData = pData;
		}

		public string Name
		{
			get{return this.mName;}
		}
	
		public object Data
		{
			get{return this.mData;}
		}
		
	}
}
