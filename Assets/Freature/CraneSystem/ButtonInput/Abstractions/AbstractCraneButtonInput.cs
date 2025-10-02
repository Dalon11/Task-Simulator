using System;
using UnityEngine;

public abstract class AbstractCraneButtonInput : MonoBehaviour
{
    public abstract event Action<bool> onUpButton;
    public abstract event Action<bool> onDownButton;
    public abstract event Action<bool> onRightButton;
    public abstract event Action<bool> onLeftButton;
    public abstract event Action<bool> onForwardButton;
    public abstract event Action<bool> onBackButton;
}
