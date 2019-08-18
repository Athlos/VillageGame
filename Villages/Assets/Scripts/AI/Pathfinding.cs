using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    protected Vector3 m_waypointPos = Vector3.zero;

    public virtual void SetWaypoint()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, m_waypointPos);
        Gizmos.DrawSphere(m_waypointPos, 0.5f);
    }
}
