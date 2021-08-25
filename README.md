# Game architecture with ScriptableObjects
Continuing my Unite Austin 2017 walkthrough. This time we've been introduced a couple amazing ScriptableObject design patterns.

### ScriptableObject events pattern
How it works:
 
1. We create script "GameEvent" derived from ScriptableObject that has a list of listeners and following methods: add, remove listener and raise the event.
2. Whatever GameObject needs to notify observers, has a UnityEvent with "GameEvent" scriptable object dragged in.
3. Listener GameObjects have a MonoBehaviour script "GameEventListener" with UnityEvent to perform required actions and a reference to "GameEvent" to know when those actions should be done. In OnEnable() listeners register themselves to the List of type GameEventListener in "GameEvent" scriptable object.
4. When target event occurs, method Raise() of "GameEvent" scriptable object gets called and all observers are notified. Listeners handle event actions on their own as with the traditional observer pattern.

#### My personal thoughts on this one

This is basically an extended UnityEvent with additonal layer - "bus" scriptable object. To me this looks like a beautiful customizable variation of observer pattern in Unity.

Benefits:
- less rigid and much more obvious connections between game components in comparsion to UnityEvents
- reusable both in the project and outside of it
- highly customizable: possible to add developer description, some additional actions on event raise etc
- easier to track bugs

Downsides:
- no return type by default - adding one would require either creating a generator or writing boilerplate code
- no control over execution order, since listeners are added in OnEnable() methods

**Overall** i think it's pretty much useful pattern, but it's definetely not a catch-all. Sometimes it might fit game logic or be used as a synchronization tool, but there are for sure times when regular UnityEvents could fit better or at least not worse (e.g. UI).

### ScriptableObject runtime sets (collections)
Another great example of utilizing ScriptableObjects capabilities. Basically this is a collection turned into a scriptable object. What for?

It literally destroys one of the singleton purposes - storing global high-level collections of some GameObjects. It might be enemies, minimap icons, weapons - whatever. By wrapping this collection in a scriptable object we are able to pass it to any script interested in tracking (e.g. audio manager, enemy counter etc).

### Asset bases
>*We heard you like ScriptableObjects. So we put ScriptableObjects in your ScriptableObjects so you can use ScriptableObjects while you use Scriptable objects.*

Idea of this pattern is basically to create a referencable system derived from SO, which will contain other SOs as references. It can be pretty useful with inventory, achievement systems because we wouldnt need to hard reference those systems in other scripts.

### Scriptable... EventArgs?
Not really a pattern from Unity Austin 2017, but i find it a must to put it here. This is pretty much close to SO UnityEvents pattern, but it has a few benefits:
- it's C# events now. They're a bit faster and trackable from code
- we can pass as much data as we want, and nothing would break if we add more data because we pass it through struct. Multiple constructors can be declared
