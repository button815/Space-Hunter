using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MeeleAI : MonoBehaviour
{


    private NavMeshAgent agent;
    public Transform player;
    private Animator animator;
    public Transform[] patrolpoints;
    private int currentPatrolidex;

    public float chaserange = 10f;
    public float attackRange = 2f;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (distanceToTarget <= attackRange)
        {
            agent.SetDestination(transform.position);
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", true);

        }
        else if (distanceToTarget <= chaserange)
        {
            agent.SetDestination(player.position);
            animator.SetBool("walk", true);
            animator.SetBool("attack", false);
        }
        else
        {
            animator.SetBool("walk", true);
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);
            patrol();
        }
    }
    void patrol()
    {
        if (patrolpoints.Length == 0) return;
        if (agent.remainingDistance < 0.5f)
        {
            currentPatrolidex = (currentPatrolidex + 1) % patrolpoints.Length;
            agent.SetDestination(patrolpoints[currentPatrolidex].position);
        }
    }
    public int health = 100;
    public Slider HealthBar;
    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthBar.value = health;
        if (health <= 0)
        {
            Debug.Log("Enemy died");
        }


    }
}


 
