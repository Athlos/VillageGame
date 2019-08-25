using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private ResourceDropoff m_dropoff = null;

    public static ResourceManager Instance
    {
        get
        {
            return m_instance;
        }
    }

    private static ResourceManager m_instance = null;

    private Resource[] m_allResources = null;

    // Gross hack for now
    public void Awake()
    {
        m_instance = this;

        // Get all resources

        m_allResources = GetComponentsInChildren<Resource>();
    }

    public Resource GetResource(ResourceType type)
    {
        for (int i = 0; i < m_allResources.Length; i++)
        {
            if (type == m_allResources[i].ResourceType)
                return m_allResources[i];
        }

        return null;
    }

    public ResourceDropoff GetDropOff(ResourceType type)
    {
        return m_dropoff;
    }
}

public enum ResourceType
{
    None,
    Food,
    Wood,
    Stone
}
