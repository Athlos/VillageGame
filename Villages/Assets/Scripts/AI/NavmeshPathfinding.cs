using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshPathfinding : Pathfinding
{
    [SerializeField]
    protected Transform m_waypoint = null;

    [SerializeField]
    private NavMeshAgent m_agent = null;

    public override void SetWaypoint(Vector3 pos)
    {
        base.SetWaypoint(pos);

        m_agent.destination = m_waypointPos;
    }
}
