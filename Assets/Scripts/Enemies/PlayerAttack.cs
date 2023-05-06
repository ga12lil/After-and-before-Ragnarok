using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Inventory inv;
    public ItemClass NeedEquip;
    public float attackDelay = 5f;
    public float NeedDamage;
    public float HP;
    public Texture2D attackCursorTexture;

    private bool Contact;
    private bool isAttacking = false;
    private Animator animPlayer;
    private Animator anim;
    public bool takeDamage = false;

    public void Awake()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        animPlayer = GameObject.Find("player").GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Contact = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Contact = false;
        }
    }

    public void OnMouseDown()
    {
        if (Contact && inv.InHand != null && !isAttacking)
        {
            Equipment eq = inv.InHand.gameObject.GetComponent<Equipment>();
            if (NeedEquip == eq.itemClass)
            {
                if (NeedDamage <= eq.Damage)
                {
                    if (eq.itemClass == ItemClass.Axe)
                    {
                        StartCoroutine(Attack());
                    }
                    HP -= eq.Damage;
                    takeDamage = true;
                }
            }
        }
    }

    public void FixedUpdate()
    {
        if (HP <= 0)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Destroy(gameObject);
        }

    }

    void OnMouseEnter()
    {
        if (Contact && inv.InHand != null && !isAttacking)
        {
            Equipment eq = inv.InHand.gameObject.GetComponent<Equipment>();
            if (NeedEquip == eq.itemClass)
            {
                if (NeedDamage <= eq.Damage)
                {
                    StartCoroutine(DelayedCursorChange());
                    return;
                }
            }
        }
    }

    IEnumerator DelayedCursorChange()
    {
        yield return new WaitForSeconds(0.2f); // задержка в 0.2 секунды
        Cursor.SetCursor(attackCursorTexture, Vector2.zero, CursorMode.Auto);
    }

    //private void OnMouseOver()
    //{
    //    OnMouseEnter();
    //}

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animPlayer.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }
}
