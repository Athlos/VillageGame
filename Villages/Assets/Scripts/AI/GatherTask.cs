using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherTask : Task
{
    private Resource m_resource = null;

    public void SetResource(Resource resource)
    {
        m_resource = resource;
    }

    public void PickUpResource()
    {
        int resourceAmount = m_resource.GetResources(10);

        ResourceItem newResourceItem = new ResourceItem()
        {
            Type = m_resource.ResourceType,
            ResourceAmount = resourceAmount
        };

        m_unit.PickUpResource(newResourceItem, m_resource.ResourcePrefab);
        CompleteTask();
    }

    public override void ProcessTask()
    {
        PickUpResource();
    }
}
