using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Inventory inv;
    public ItemClass NeedEquip;
    public float attackDelay = 0.7f;
    public float HP = 100;
    public Texture2D attackCursorTexture;
    public bool takeDamage = false;

    private bool Contact;
    private bool isAttacking = false;
    private Animator animPlayer;
    private SpriteRenderer enemySprite;
    private MoveController playerMoveController;
    private GameObject player;

    public List<GameObject> FarmRes;

    public void Awake()
    {
        player = GameObject.Find("player");
        enemySprite = GetComponent<SpriteRenderer>();
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
        playerMoveController = player.GetComponent<MoveController>();
        animPlayer = player.GetComponent<Animator>();
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
        if (Contact && inv.InHand != null && !isAttacking && Time.timeScale != 0)
        {
            Equipment eq = inv.InHand.gameObject.GetComponent<Equipment>();
            if (NeedEquip == eq.itemClass)
            {
                if (eq.itemClass == ItemClass.Weapon)
                {
                    var position = transform.position - player.transform.position;
                    if (position.x < 0 && playerMoveController.LookRight || position.x > 0 && !playerMoveController.LookRight)
                        playerMoveController.Flip();

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
            System.Random rand = new System.Random();
            foreach (var i in FarmRes)
            {
                int randX = rand.Next(-3, 3);
                int randY = rand.Next(-3, 3);
                Instantiate(i, new Vector3(gameObject.transform.position.x + randX, gameObject.transform.position.y + randY, gameObject.transform.position.z), new Quaternion());
            }
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            playerMoveController.CanMove = true;
            Destroy(gameObject);
        }

    }

    void OnMouseEnter()
    {
        if (Contact && inv.InHand != null && !isAttacking && Time.timeScale != 0)
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

    // ��� �������� ������ ���� ����������, ����� ��� ������������� �������� ������� �� ������ ��������
    IEnumerator PlayerAttackCoroutine()
    {
        playerMoveController.CanMove = false;
        isAttacking = true;

        enemySprite.color = new Color(1f, 0.6914f, 0.6914f); // 177 : 256
        animPlayer.SetTrigger("Attack");
        yield return new WaitForSeconds(attackDelay);
        enemySprite.color = Color.white;

        playerMoveController.CanMove = true;
        isAttacking = false;
    }
}