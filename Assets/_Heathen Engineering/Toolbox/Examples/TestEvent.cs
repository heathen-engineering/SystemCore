using HeathenEngineering.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    public StringGameEvent stringEvent;

    private void Start()
    {
        stringEvent.AddListener(HeardString);
    }

    public void EventListenerString(string value)
    {
        Debug.Log("Listener: " + value);
    }

    public void HeardString(EventData<string> data)
    {
        Debug.Log("Manual: " + data.value);
    }

}
