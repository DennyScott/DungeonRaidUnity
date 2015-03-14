using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Public delegates to use in other classes and this class
public delegate void VoidAction (GameObject g);
public delegate bool BoolAction (GameObject g);

/// <summary>
/// Used to connect publishers and subscriptions in a game.  All thats needed for subscribers is the key their waiting for publishing from,
/// as well as the handler they want to run when a publish is triggered.  A Publishers will need a key for what subscibers should subscribe to, and a gameObject that 
/// is associated with the publish.
/// </summary>
public static class EventDispatcher {
	private static Dictionary<string, VoidAction> voidSubscriptions = new Dictionary<string, VoidAction>();  //Used for the void actions
	private static Dictionary<string, BoolAction> boolSubscriptions = new Dictionary<string, BoolAction>();  //Used for the boolean actions

	/// <summary>
	/// Publish the specified key, and gameobject  to subscribed handlers, and then pass the return value back.
	/// </summary>
	/// <param name="key">Key to check subscriptions for</param>
	/// <param name="g">The gameobject component to pass to the subscribers.</param>
	/// <param name="returnValue">Return value of the boolean methods.</param>
	public static void Publish(string key, GameObject g, out bool returnValue) {
		//make true so that is there is no subscription, its automatically true
		returnValue = true;
		//Check to make sure the key exists
		if(boolSubscriptions.ContainsKey(key)) {
			//Check to see if there is a subscription by the given key
			if (boolSubscriptions[key] != null) {
				//if there is a subscription, cycle through each boolAction in the list
				returnValue = DoesBoolExist(boolSubscriptions[key], g);
			}
		}
	}

	/// <summary>
	/// Check each of the booleans in a BoolAction. If any of the returns are false,
	/// return false. If none of them are false, we can return true.
	/// </summary>
	/// <param name="actions">Event storage of methods.</param>
	private static bool DoesBoolExist(BoolAction actions, GameObject g) {
		foreach(BoolAction bAction in actions.GetInvocationList()) {
			//If the return value of the action is ever false, return value must be false
			if (bAction(g) == false) {
				return false;
			}
		}
		return true;
	}

	/// <summary>
	/// Publish the specified key and gameobject to subscribed handlers.
	/// </summary>
	/// <param name="key">Key to publish</param>
	/// <param name="g">The gameobject component to pass to the event handlers.</param>
	public static void Publish(string key, GameObject g) {
		//If the subscription exists
		if(voidSubscriptions.ContainsKey(key)) {
			//Make sure the delegate is not null
			if(voidSubscriptions[key] != null) {
				//If not null, call all the associated methods
				voidSubscriptions[key](g);
			}
		}
	}


	/// <summary>
	/// Subscribe the specified key with the given method.
	/// </summary>
	/// <param name="key">Key to subscribe to</param>
	/// <param name="d">The void action to run when published</param>
	public static void Subscribe(string key, VoidAction d) {
		//If the subscription already contains the key, 
		//add this delegate to the existing delegate under the given key
		if(voidSubscriptions.ContainsKey(key)) {
			//Add delegate to existing delegate
			voidSubscriptions[key] += d;
		} else {
			//Create a new entry in the subscription dictonary
			voidSubscriptions.Add(key, d);
		}
	}

	/// <summary>
	/// Subscribe the specified key with the given method
	/// </summary>
	/// <param name="key">Key to subscribe to</param>
	/// <param name="d">boolean action to run on publish</param>
	public static void Subscribe(string key, BoolAction d) {
		//If the subscription already contains the key, 
		//add this delegate to the existing delegate under the given key
		if(boolSubscriptions.ContainsKey(key)) {
			//Add delegate to existing delegate
			boolSubscriptions[key] += d;
		} else {
			//Create a new entry in the subscription dictonary
			boolSubscriptions.Add(key, d);
		}
	}

}


