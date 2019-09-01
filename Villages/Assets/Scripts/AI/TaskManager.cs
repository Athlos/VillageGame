using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the jobs the ai should be doing
/// </summary>
public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private Unit m_unit = null;

    private Queue<Task> m_subTasks = new Queue<Task>();
    private Task m_currentTask = null;

    private void Start()
    {
        GenerateTestGatherTask();
    }

    public void GenerateTestGatherTask()
    {
        // Grab necessary info
        Resource resource = ResourceManager.Instance.GetResource(ResourceType.Food);
        ResourceDropoff dropoff = ResourceManager.Instance.GetDropOff(ResourceType.Food);

        // Create sub tasks
        // First, go to resource
        WalkTask goToResource = new WalkTask();
        goToResource.Initialise(m_unit);
        goToResource.SetWalkToLocation(resource.transform.position);
        m_subTasks.Enqueue(goToResource);

        // Then gather resource
        GatherTask gatherResource = new GatherTask();
        gatherResource.SetResource(resource);
        gatherResource.Initialise(m_unit);
        m_subTasks.Enqueue(gatherResource);

        // Walk to drop off
        WalkTask goToDropoff = new WalkTask();
        goToDropoff.Initialise(m_unit);
        goToDropoff.SetWalkToLocation(dropoff.transform.position);
        m_subTasks.Enqueue(goToDropoff);

        // Drop off resource
        EmptyInventoryTask emptyAtDropoff = new EmptyInventoryTask();
        emptyAtDropoff.SetDropoff(dropoff);
        emptyAtDropoff.Initialise(m_unit);
        m_subTasks.Enqueue(emptyAtDropoff);
    }

    private void Update()
    {
        // Update current task
        if (m_currentTask != null && m_currentTask.IsComplete)
            m_currentTask = null;
        
        if (m_currentTask == null && m_subTasks.Count > 0)
        {
            m_currentTask = m_subTasks.Dequeue();
            m_currentTask.StartTask();
        }

        if (m_currentTask == null)
            return;

        m_currentTask.ProcessTask();
    }
}
