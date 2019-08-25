using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Pathfinding m_pathingSystem = null;
    public Pathfinding PathingSystem { get { return m_pathingSystem; } }

    [SerializeField]
    private int m_maxCarryAmount = 0;

    public bool InventoryFull { get { return m_maxCarryAmount >= m_currentCarriedItem.ResourceAmount; } }

    private ResourceItem m_currentCarriedItem = null;

    public void PickUpResource(ResourceItem item)
    {
        m_currentCarriedItem = item;
    }

    public void DropItem(ResourceDropoff dropOff)
    {
        dropOff.DropOffResource(m_currentCarriedItem);

        m_currentCarriedItem = null;
    }
}
