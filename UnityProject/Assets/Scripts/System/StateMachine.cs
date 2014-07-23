using System;
using System.Collections.Generic;

namespace Inhouse.StateMachine
{
	class StateMachine
	{
		private List<Action> mCurrentStates;
		private List<Action> mNextStates;
		private Action mNextState;
		private bool mYield;
		private bool mExit;
		private string mName;

		public StateMachine(string name = null)
		{
			mName = name;
			Init();
		}

		public void Init()
		{
			mCurrentStates = new List<Action>();
			mNextStates = new List<Action>();
		}

		public void Exec()
		{
			next();

			Action current = null; // will be set in the first iteration
			foreach (Action state in mCurrentStates) {
				mYield = false;
				mExit = false;
				mNextState = state;

				while (mNextState != null && !mYield && !mExit) {
					current = mNextState;
					mNextState = null;
					current();
					if (mNextState != null && mName != null) {
#if DEBUG
						UnityEngine.Debug.Log("[STATE] " + mName + " : " + current.Method.Name + " -> " + mNextState.Method.Name);
#endif
					}
				}
				if (mExit) {
					continue;
				}

				mNextStates.Add(mNextState != null ? mNextState : current);
			}
		}

		private void next()
		{
			List<Action> tmp = mCurrentStates;
			mCurrentStates = mNextStates;
			mNextStates = tmp;
			mNextStates.Clear();
		}

		public void Spawn(Action func)
		{
			mNextStates.Add(func);
		}

		public void SwitchTo(Action func)
		{
			mNextState = func;
			mYield = false;
		}

		public void YieldTo(Action func)
		{
			mNextState = func;
			mYield = true;
		}

		public void Exit()
		{
			mExit = true;
		}
	}
}
