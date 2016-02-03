using UnityEngine;
using System.Collections.Generic;
using System;

public class MessagingManager : MonoBehaviour {
    public static MessagingManager Instance
    {
        get;
        private set;
    }

    private List<Action> subscribers = new List<Action>();

    void Awake()
    {
        Debug.Log("Messaging manager started");

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Subscribe(Action subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(Action subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void ClearAllSubscribers()
    {
        subscribers.Clear();
    }

    public void Broadcast()
    {
        Debug.Log("Broadcast requested, Nº of subscribers: " + subscribers.Count);

        foreach(var subscriber in subscribers)
        {
            subscriber();
        }
    }
}
