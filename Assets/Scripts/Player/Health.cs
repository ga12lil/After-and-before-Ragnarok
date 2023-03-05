using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float curHealth = 0;
    public float maxHealth = 100;

    [SerializeField] private float secondsToEmptyHealth = 10f;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        Food food = gameObject.GetComponentInParent(typeof(Food)) as Food;
        if ((food.curFood <= 0) && (curHealth > 0))
        {
            Damage(maxHealth / secondsToEmptyHealth * Time.deltaTime);

            if (curHealth <= 0)
                SceneManager.LoadScene("DeathScrene");
        }
    }

    public void Heal(float damage)
    {
        curHealth += damage;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }

    public void Damage(float damage)
    {
        curHealth -= damage;
        if (curHealth < 0)
            curHealth = 0;
    }
}
