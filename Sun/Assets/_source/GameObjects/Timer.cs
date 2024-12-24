using Assets._source.Observer;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

internal class Timer : MonoBehaviour, IObservable
{
    [SerializeField] private float morningTime = 4.8f;  
    [SerializeField] private float dayTime = 9.6f;     
    [SerializeField] private float eveningTime = 14.4f; 
    [SerializeField] private float AftereveningTime = 19.2f; 
    [SerializeField] private float nightTime = 24.0f;   
    private List<IObserver> observers;
    [SerializeField,ReadOnly]private float currentTime; 

    private void Awake()
    {
        observers = new List<IObserver>();
    }

    private void Update()
    {
        UpdateTime();
        CheckTimePeriod();
    }

    private void UpdateTime()
    {
        currentTime += Time.deltaTime; 
        if (currentTime >= 24.0f) 
        {
            currentTime = 0.0f;
        }
    }

    private void CheckTimePeriod()
    {
        if (currentTime >= nightTime || currentTime < morningTime)
        {
            NotifyObservers("night");
        }
        else if (currentTime >= morningTime && currentTime < dayTime)
        {
            NotifyObservers("morning");
        }
        else if (currentTime >= dayTime && currentTime < eveningTime)
        {
            NotifyObservers("day");
        }
        else if (currentTime >= eveningTime && currentTime < AftereveningTime)
        {
            NotifyObservers("evening");
        }
        else if (currentTime >= AftereveningTime)
        {
            NotifyObservers("Afterevening");
        }
    }

    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers(string eventName)
    {
        foreach (IObserver observer in observers)
        {
            observer.Invoke(eventName);
            
        }
    }
}
