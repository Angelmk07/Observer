using Assets._source;
using Assets._source.Observer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootatrapper : MonoBehaviour
{
    [SerializeField] private Sun sun;
    [SerializeField] private Stars[] stars;
    [SerializeField] private Ground ground;
    [SerializeField] private Timer timer;
    private void Awake()
    {
        timer.AddObserver(ground);
        timer.AddObserver(sun);
        foreach (var s in stars)
        {
            timer.AddObserver(s);
        }
    }
}
