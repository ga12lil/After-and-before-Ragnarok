using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    private AIPath aiPath;

    void Start()
    {
        animator = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
    }

    void Update()
    {
        if (aiPath.velocity.magnitude > 0)
        {
            Debug.Log("IsMoving true");
            animator.SetBool("IsMoving", true);
        }
        else
        {
            Debug.Log("IsMoving false");
            animator.SetBool("IsMoving", false);
        }
    }
}
