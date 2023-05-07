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
        player = GameObject.Find("player");
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (playerAttack.takeDamage)
        {
            SetRunAnim();
            playerAttack.takeDamage = false;
        }
        if (Run && !IsTriggerGround)
        {
            float xForce = Random.Range(0.04f, 0.3f);
            float yForce = Random.Range(0.04f, 0.3f);
            
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
        if(!Run && !IsTriggerGround && (Mathf.Pow(player.transform.position.x - transform.position.x, 2) + Mathf.Pow(player.transform.position.y - transform.position.y, 2) < 100))
        {
            float seed = Random.Range(0, 1000);
            if (seed > 990)
            {
                anim.SetBool("isRun", true);
                float xForce = Random.Range(-2f, 2f);
                float yForce = Random.Range(-2f, 2f);
                if(xForce>1 || yForce > 1 || xForce < -1 || yForce < -1)
                {
                    if ((xForce > 0 && !LookRight) || (xForce < 0 && LookRight))
                        Flip();
                    transform.position = new Vector3(transform.position.x + xForce, transform.position.y + yForce, transform.position.z);
                }
                
            }
            else
            {
                anim.SetBool("isRun", false);
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
