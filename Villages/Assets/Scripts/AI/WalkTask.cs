using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTask : Task
{
    private Vector3 m_walkTo = Vector3.zero;

    public void SetWalkToLocation(Vector3 pos)
    {
        m_walkTo = pos;
    }

    public override void StartTask()
    {
        m_unit.PathingSystem.SetWaypoint(m_walkTo);
    }

    public override void ProcessTask()
    {
        if (IsComplete) return;

        base.ProcessTask();

        if (Vector3.Distance(m_unit.transform.position, m_walkTo) <= 3.0f)
        {
            CompleteTask();
        }
    }
}
