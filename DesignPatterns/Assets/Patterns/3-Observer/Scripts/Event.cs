﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Game Event", order = 52)]
public class Event : ScriptableObject
{
    private List<EventListener> elisteners = new List<EventListener>();

    public void Register(EventListener listener)
    {
        elisteners.Add(listener);
    }

    public void UnreGister(EventListener listener)
    {
        elisteners.Remove(listener);
    }

    public void Occurred()
    {
        for (int i = 0; i < elisteners.Count; i++)
        {
            elisteners[i].OnEventOccurs();
        }
    }
}
