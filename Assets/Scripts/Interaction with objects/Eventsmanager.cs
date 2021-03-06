using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventsmanager : MonoBehaviour
{
    public static Eventsmanager current;
    public static bool canhoverright;
    public static bool canhoverleft;
    private void Awake()
    {
        current = this;
    }
    //Learned events and use this method https://www.youtube.com/watch?v=gx0Lt4tCDE0
    //This class receives the call when a specific event happens and it will notify to its subscribers.
    //When trigger is being pressed
    public event Action OnTriggerLeftTrue;
    public void TriggerLeftTrue()
    {
        if (OnTriggerLeftTrue != null)
        {
            OnTriggerLeftTrue();
        }
    }
    public event Action OnTriggerLeftFalse;
    public void TriggerLeftFalse()
    {
        if (OnTriggerLeftFalse != null)
        {
            OnTriggerLeftFalse();
        }
    }
    //When grip is being pressed
    public event Action OnGripLeftTrue;
    public void GripLeftTrue()
    {
        if (OnGripLeftTrue != null)
        {
            OnGripLeftTrue();
        }
    }
    public event Action OnGripLeftFalse;
    public void GripLeftFalse()
    {
        if (OnGripLeftFalse != null)
        {
            OnGripLeftFalse();
        }
    }
    public event Action OnTriggerRightTrue;
    public void TriggerRightTrue()
    {
        if (OnTriggerRightTrue != null)
        {
            OnTriggerRightTrue();
        }

    }
    public event Action OnTriggerRightFalse;
    public void TriggerRightFalse()
    {
        if (OnTriggerRightFalse != null)
        {
            OnTriggerRightFalse();
        }
    }
    public event Action OnGripRightTrue;
    public void GripRightTrue()
    {
        if (OnGripRightTrue != null)
        {
            OnGripRightTrue();
        }
    }
    public event Action OnGripRightFalse;
    public void GripRightFalse()
    {
        if (OnGripRightFalse != null)
        {
            OnGripRightFalse();
        }
    }
    //When an object is scaling
    public event Action OnScaling;
    public void Scaling()
    {
        if (OnScaling != null)
        {
            OnScaling();
        }
    }
    //I used a string so to prevent all objects from moving a t the same time.
    //If something is being hovered,no objects can be added.
    public event Action<string> OnHoverright;
    public void Hoverright(string name)
    {
        if (OnHoverright != null)
        {
            OnHoverright(name);
            canhoverright = false;
        }
    }
    public event Action<string> OnHoverleft;
    public void Hoverleft(string name)
    {
        if (OnHoverleft != null)
        {
            OnHoverleft(name);
            canhoverleft = false;
        }
    }

    public event Action<string> OnHoverexitright;
    public void Hoverexitright(string name)
    {
        if (OnHoverexitright != null)
        {
            canhoverright = true;
            OnHoverexitright(name);
        }
    }
    public event Action<string> OnHoverexitleft;
    public void Hoverexitleft(string name)
    {
        if (OnHoverexitleft != null)
        {
            canhoverleft = true;
            OnHoverexitleft(name);
        }
    }
}
