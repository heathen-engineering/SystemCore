using HeathenEngineering.Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleDemo_RandomizeColor : MonoBehaviour
{
    public void RandomizeColor(ColorVariable target)
    {
        target.SetValue(Random.ColorHSV());
    }
}
