using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : StateMachineBehaviour
{
    public float attackRange = 3f;
    public int damage = 10;

    Transform player;
    private SpriteRenderer sprite;
    private AIPath aiPath;
    private Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = animator.GetComponent<SpriteRenderer>();
        aiPath = animator.GetComponent<AIPath>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (aiPath.desiredVelocity.x < 0)
            sprite.flipX = true;
        else if (aiPath.desiredVelocity.x > 0)
            sprite.flipX = false;

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}
