using UnityEngine;
using System.Collections;

/// <summary>
/// EventEmitter is used to attach Scripts to the Global PubSub System. If a script
/// inherits from this script, the class can make publish and subscription calls.
/// </summary>
public abstract class EventEmitter : AdvMonoBehaviour {

	/// <summary>
	/// Subscribe to an event in the pub sub dictionaries. This will attach
	/// to the dictionary containing only VoidActions, which do not return values
	/// on execution.
	/// </summary>
	/// <param name="key">Name of Value in Dictionary</param>
	/// <param name="sub">Subscription of methods to Key</param>
	public void Subscribe(string key, VoidAction sub) {
		EventDispatcher.Subscribe(key, sub);
	}

	/// <summary>
	/// Subscribe to an event in the pub sub dictionaries. This will attach
	/// to the dictionary containing only BoolActions, which return bool values
	/// on execution.
	/// </summary>
	/// <param name="key">Name of Value in Dictionary</param>
	/// <param name="sub">Subscription of methods to Key</param>
	public void Subscribe(string key, BoolAction b) {
		EventDispatcher.Subscribe(key, b);
	}

	/// <summary>
	/// Publish an Event. This will find the dictionary containing only VoidActions
	/// and then find the event with a key attached named the same as the passed string.
	/// </summary>	
	/// <param name="key">Name of the Event in Dictionary</param>
	/// <param name="g">Game Object where the Event took place </param>
	public void Publish(string key, GameObject g) {
		EventDispatcher.Publish(key, g);
	}

	/// <summary>
	/// Publish an Event. This will find the dictionary containing only BoolActions
	/// and then find the event with a key attached named the same as the passed string.
	///
	/// This publish will be used if we are connected to some sort of "CanMove"-like 
	/// event, where we want to determine if it's possible to enact an event.
	/// </summary>	
	/// <param name="key">Name of the Event in Dictionary</param>
	/// <param name="g">Game Object where the Event took place </param>
	/// <param name="returnValue">Boolean returned from the publish event</param>
	public void Publish(string key, GameObject g, out bool returnValue) {
		EventDispatcher.Publish(key, g, out returnValue);
	}
}
