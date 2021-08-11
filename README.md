# ScriptableObject events pattern
Continuing my Unite Austin 2017 walkthrough. This time we've been introduced to ScriptableObject events pattern. How it works:
 
1. We create script "GameEvent" derived from ScriptableObject that has a list of listeners and following methods: add, remove listener and raise the event.
2. Whatever GameObject needs to notify observers, has a UnityEvent with "GameEvent" ScriptableObject dragged in.
3. Listener GameObjects have a MonoBehaviour script "GameEventListener" with UnityEvent to perform required actions and a reference to "GameEvent" to know when those actions should be done. In OnEnable() method listeners register themselves to the List of type GameEventListener in "GameEvent" instance.
4. When target event occurs, method Raise() of "GameEvent" instance gets called and all observers are notified. Listeners handle event actions on their own as with the traditional observer pattern.

### My personal thoughts on this one

To me this looks like a beautiful customizable variation of observer pattern in Unity.

Benefits:
- less rigid connections
- reusable both in the project or outside of it
- highly customizable: possible to add developer description, some additional actions on event raise etc
- more obvious to both programmers and designers

Downsides:
- no return type by default - adding one would require either creating a generator or writing boilerplate code
- no control over execution order, since listeners are added in OnEnable() methods

### Conclusion
Overall i think it's pretty much useful pattern, but it's definetely not a catch-all. Sometimes it might fit game logic or be used as a synchronization tool, but there are for sure times when regular UnityEvents could fit better or at least not worse (e.g. UI). 

