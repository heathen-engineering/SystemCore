using UnityEngine;
using System.Collections;

namespace HeathenEngineering.Events
{
    public delegate void RoutedEvent<T>(object sender, T argument);
}
