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

    [SerializeField]
    private Transform m_itemHeldPos = null;

    private GameObject m_itemHeld = null;

    public bool InventoryFull { get { return m_maxCarryAmount >= m_currentCarriedItem.ResourceAmount; } }

    private ResourceItem m_currentCarriedItem = null;

    public void PickUpResource(ResourceItem item, GameObject spawnObject)
    {
        // if we are already carrying the same type
        if (m_currentCarriedItem == null || m_currentCarriedItem.Type != item.Type)
        {
            m_currentCarriedItem = item;

            if (m_itemHeld != null)
                Destroy(m_itemHeld);

            m_itemHeld = Instantiate(spawnObject, m_itemHeldPos);
        }
        else
        {
            m_currentCarriedItem.ResourceAmount += item.ResourceAmount;
        }
    }

    public void DropItem(ResourceDropoff dropOff)
    {
        dropOff.DropOffResource(m_currentCarriedItem);

        m_currentCarriedItem = null;
        if (m_itemHeld != null)
            Destroy(m_itemHeld);
    }
}
