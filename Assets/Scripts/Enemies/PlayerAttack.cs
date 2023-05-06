using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Inventory inv;
    public ItemClass NeedEquip;
    public float attackDelay = 2f;
    public float HP = 100;
    public Texture2D attackCursorTexture;
    public bool takeDamage = false;

    private bool Contact;
    private bool isAttacking = false;
    private Animator animPlayer;
    private SpriteRenderer enemySprite;

    public void Awake()
    {
        enemySprite = GetComponent<SpriteRenderer>();
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
                if (eq.itemClass == ItemClass.Weapon)
                {
                    StartCoroutine(PlayerAttackCoroutine());
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
                Cursor.SetCursor(attackCursorTexture, Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseOver()
    {
        OnMouseEnter();
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Имя корутины должны быть уникальным, иначе она дополнительно вызывает функции из других скриптов
    IEnumerator PlayerAttackCoroutine()
    {
        isAttacking = true;
        enemySprite.color = new Color(1f, 0.6914f, 0.6914f); // 177 : 256
        animPlayer.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        enemySprite.color = Color.white;
        isAttacking = false;
    }
}