using UnityEngine;
using UnityEngine.AI;
public class Robot : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navmeshagent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navmeshagent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            navmeshagent.SetDestination(player.position);
        }
    }
}
