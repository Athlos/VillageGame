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
    private void Awake()
    {
        SetWaypoint();
    }

    public override void SetWaypoint()
    {
        base.SetWaypoint();

        m_waypointPos = m_waypoint.position;
        m_agent.destination = m_waypointPos;
    }
}
