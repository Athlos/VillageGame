using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField]
    private ResourceType m_resourceType = ResourceType.Food;
    public ResourceType ResourceType { get {return m_resourceType; } }

    [SerializeField]
    private int m_resourceAmount = 0;

    private int m_currentResourceAmount = 0;

    private void Awake()
    {
        m_currentResourceAmount = m_resourceAmount;
    }

    /// <summary>
    /// Removes resources from the resource pile
    /// </summary>
    /// <param name="amount">How many resources to remove</param>
    /// <returns>The actual amount removed, if the amount requested is higher than the amount left</returns>
    public virtual int GetResources(int amount)
    {
        if (amount < m_currentResourceAmount)
        {
            m_currentResourceAmount -= amount;
            return amount;
        }
        else
        {
            return m_currentResourceAmount;
        }
    }

    private void Update()
    {
        if (m_currentResourceAmount == 0)
        {
            OnResourceEmpty();
            m_currentResourceAmount = -1;
        }
    }

    protected virtual void OnResourceEmpty()
    {
        Destroy(this);
    }
}
