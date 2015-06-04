using UnityEngine;
using System.Collections;

public class SlotState{

	public enum SlotStates {
		Normal,
		Empty
	};

	public class NormalState : State {}

	public class EmptyState : State {}
}
