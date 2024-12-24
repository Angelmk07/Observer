using Assets._source.Observer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EarthObjectStats : MonoBehaviour, IObserver
{
    [SerializeField] protected float lerptime = 2;
    protected delegate void Message();
    protected Message _message;
    protected virtual void Update()
    {
        _message?.Invoke();
    }
    public void Invoke(string eventName)
    {
        if (eventName == "night")
        {
            _message = Night;
        }
        else if (eventName == "morning")
        {
            _message = Morning;
        }
        else if (eventName == "day")
        {
            _message = Day;
        }
        else if (eventName == "evening")
        {
            _message = Evening;
        }
        else if (eventName == "Afterevening")
        {
            _message = AfterEvening;
        }
        else
        {
            Debug.LogWarning($"Unknown event: {eventName}");
        }
    }

    protected abstract void Night();
    protected abstract void Morning();
    protected abstract void Day();
    protected abstract void Evening();
    protected abstract void AfterEvening();
    


}
