using UnityEngine;
using System.Collections;

public partial class Slot {

	public class ConcreteState : IFSMState {
		public virtual void OnEntry() {}
		public virtual void OnExit() {}
	}

	public class NormalState : ConcreteState {
		public override void OnEntry() {}
		public override void OnExit() {}	
	}

	public class EmptyState : ConcreteState {
		public override void OnEntry() {}
		public override void OnExit() {}
	}
}
