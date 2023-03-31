using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float aggroDistance = 3f;
    public float attackCooldown = 2f;
    public int damage = 10;

    public float rotationSpeed = 5f;

    private bool isAggroed = false;
    private float lastAttackTime = 0f;
    private Health playerHealth;
    private Animator animator;

    void Start()
    {
        playerHealth = player.GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!isAggroed && distanceToPlayer < aggroDistance)
        {
            isAggroed = true;
            Debug.Log("isAggroed = true");
        }
        else if ((isAggroed && distanceToPlayer > aggroDistance) || !isAggroed)
        {
            isAggroed = false;
            StopAttacking();
            Debug.Log("isAggroed = false");
        }

        if (isAggroed && Time.time > lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;

            //transform.right = player.position - transform.position;
        }
    }

    void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            animator.SetBool("IsAttacking", true);
        }
    }

    void StopAttacking()
    {
        animator.SetBool("IsAttacking", false);
    }
}