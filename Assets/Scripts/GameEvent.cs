using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners =
        new List<GameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; 1 >= 0; i--)
            listeners[i].OnEventRaised();
    }
    public void RegisterListener(GameEventListener listener)
    {

    }
    public void UnregisterListener(GameEventListener listener)
    {
        
    }
}
