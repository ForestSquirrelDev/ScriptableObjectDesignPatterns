# ScriptableObject design patterns
Continuing my Unite Austin 2017 walkthrough. This time we've been introduced to couple amazing ScriptableObject disign patterns.

### First one is ScriptableObject events pattern
How it works:
 
1. We create script "GameEvent" derived from ScriptableObject that has a list of listeners and following methods: add, remove listener and raise the event.
2. Whatever GameObject needs to notify observers, has a UnityEvent with "GameEvent" scriptable object dragged in.
3. Listener GameObjects have a MonoBehaviour script "GameEventListener" with UnityEvent to perform required actions and a reference to "GameEvent" to know when those actions should be done. In OnEnable() listeners register themselves to the List of type GameEventListener in "GameEvent" scriptable object.
4. When target event occurs, method Raise() of "GameEvent" scriptable object gets called and all observers are notified. Listeners handle event actions on their own as with the traditional observer pattern.

#### My personal thoughts on this one

To me this looks like a beautiful customizable variation of observer pattern in Unity.

Benefits:
- less rigid and much more obvious connections
- reusable both in the project or outside of it
- highly customizable: possible to add developer description, some additional actions on event raise etc

Downsides:
- no return type by default - adding one would require either creating a generator or writing boilerplate code
- no control over execution order, since listeners are added in OnEnable() methods

**Overall** i think it's pretty much useful pattern, but it's definetely not a catch-all. Sometimes it might fit game logic or be used as a synchronization tool, but there are for sure times when regular UnityEvents could fit better or at least not worse (e.g. UI).

### ScriptableObject runtime sets (collections)
Another great example of utilizing ScriptableObjects capabilities. Basically this is a collection turned into a scriptable object. What for?

It literally destroys one of the singleton purposes - storing global high-level collections of some GameObjects. It might be enemies, minimap icons, weapons - whatever. By wrapping this collection in a scriptable object we are able to pass it to any script interested in tracking (e.g. audio manager, enemies counter etc).

