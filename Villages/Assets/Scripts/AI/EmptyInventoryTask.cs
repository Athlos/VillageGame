using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInventoryTask : Task
{
    private ResourceDropoff m_dropoff = null;

    public void SetDropoff(ResourceDropoff dropoff)
    {
        m_dropoff = dropoff;
    }

    public void EmptyInventory()
    {
        m_unit.DropItem(m_dropoff);
        CompleteTask();
    }

    public override void ProcessTask()
    {
        EmptyInventory();
    }
}
