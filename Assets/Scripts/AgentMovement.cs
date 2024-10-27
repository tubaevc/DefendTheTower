using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private SpriteRenderer spriteRenderer; 

    //[SerializeField] private int damageToBase = 1;
    [SerializeField] private float reachDistance = 0.5f;

    private bool hasReachedEnd = false;
    private Vector3 lastPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
        if (targetPoint != null)
        {
            SetDestination(targetPoint.position);
        }

        transform.rotation = Quaternion.identity;
        lastPosition = transform.position;
    }

    private void Update()
    {
        if (hasReachedEnd) return;

        if (Vector3.Distance(transform.position, targetPoint.position) <= reachDistance)
        {
            ReachEnd();
            return;
        }

        Vector3 movementDirection = (transform.position - lastPosition).normalized;

        if (movementDirection != Vector3.zero)
        {
            if (Mathf.Abs(movementDirection.x) > 0.1f)
            {
                spriteRenderer.flipX = movementDirection.x < 0;
            }
        }

        lastPosition = transform.position;
    }

    public void SetDestination(Vector3 target)
    {
        if (agent != null && agent.isActiveAndEnabled)
        {
            agent.SetDestination(target);
        }
    }

    private void ReachEnd()
    {
        if (hasReachedEnd) return;
        hasReachedEnd = true;

     

        Destroy(gameObject);
    }

    public void SetSpeed(float speed)
    {
        if (agent != null)
        {
            agent.speed = speed;
        }
    }

    public void SetMovementState(bool state)
    {
        if (agent != null)
        {
            agent.isStopped = !state;
        }
    }
}
