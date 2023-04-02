using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float aggroDistance = 20f;

    private Animator animator;
    private AIPath aiPath;
    private float maxSpeed;
    private Path path;
    private Seeker seeker;
    private Vector2 spawnPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
        maxSpeed = aiPath.maxSpeed;
        seeker = GetComponent<Seeker>();
        spawnPosition = transform.position;
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void Update()
    {
        if (aiPath.velocity.magnitude > 0)
        {
            //Debug.Log("IsMoving true");
            animator.SetBool("IsMoving", true);
        }
        else
        {
            //Debug.Log("IsMoving false");
            animator.SetBool("IsMoving", false);
        }
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            float distanceToPlayer = Vector2.Distance(spawnPosition, player.position);
            Debug.Log(distanceToPlayer);

            if (distanceToPlayer > aggroDistance)
            {
                aiPath.maxSpeed = maxSpeed + 2f;
                path = seeker.StartPath(transform.position, spawnPosition);
                aiPath.canSearch = false;
                //Debug.Log("Return");
            }
            else
            {
                aiPath.maxSpeed = maxSpeed;
                aiPath.canSearch = true;
                path = seeker.StartPath(transform.position, player.position);
                //Debug.Log("ToPlayer");
            }
        }
    }
}
