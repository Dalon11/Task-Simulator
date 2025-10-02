using System;
using UnityEngine;

public abstract class AbstractGazAnalyzerButtonInput : MonoBehaviour
{
    public abstract event Action<bool> onPowerButton;
}
