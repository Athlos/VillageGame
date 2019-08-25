using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public bool IsComplete { get; private set; }

    protected Unit m_unit = null;

    public virtual void Initialise(Unit unit)
    {
        m_unit = unit;
        IsComplete = false;
    }

    public virtual void StartTask()
    {

    }

    public virtual void CompleteTask()
    {
        IsComplete = true;
    }

    public virtual void ProcessTask()
    {

    }
}
