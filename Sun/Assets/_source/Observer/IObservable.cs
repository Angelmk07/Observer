using Assets._source.Observer;
using System;

interface IObservable
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers(string eventName);
}