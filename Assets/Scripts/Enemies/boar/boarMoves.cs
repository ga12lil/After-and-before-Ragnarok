using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boarMoves : MonoBehaviour
{
    public GameObject player;
    private Animator anim;
    private int Health = 100;
    bool Run = false;
    public PlayerAttack playerAttack;
    bool LookRight = true;
    bool IsTriggerGround = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerAttack.takeDamage)
        {
            SetRunAnim();
            playerAttack.takeDamage = false;
        }
        if (Run && !IsTriggerGround)
        {
            float xForce = Random.Range(0.1f, 1f);
            float yForce = Random.Range(0.1f, 1f);
            
            if (player.transform.position.x > transform.position.x)
            {
                xForce *= -1;
            }
            if (player.transform.position.y > transform.position.y)
                yForce *= -1;
            if ((xForce > 0 && !LookRight) || (xForce < 0 && LookRight))
                Flip();
            transform.position = new Vector3(transform.position.x + xForce, transform.position.y + yForce, transform.position.z);
            if (Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2) >= 100)
            {
                SetStayAnim();
            }
        }

        //if(Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2) <= 5)
        //{
        //    Debug.Log("ey");
        //}
    }
    public void SetRunAnim()
    {
        Run = true;
        anim.SetBool("isRun", true);
    }
    public void SetStayAnim()
    {
        anim.SetBool("isRun", false);
        Run = false;
    }
    private void Flip()
    {
        LookRight = !LookRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            IsTriggerGround = true;
            Debug.Log("Out!!!!!!!!!!!!!!!!!");
            SetStayAnim();
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            IsTriggerGround = true;
            Debug.Log("Out!!!!!!!!!!!!!!!!!");
            SetStayAnim();
        }
    }
    
}
