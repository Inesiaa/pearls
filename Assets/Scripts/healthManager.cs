using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    //public Image healthBar;
    public int maxHealth = 10;
    public int currentHealth;

    public GameObject SpawnPos;

    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        //if (healthAmount <= 0)
        //{
        //    Application.LoadLevel(Application.loadedLevel);
        //}

        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    TakeDamage(20);
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Heal(20);
        //}
        if(currentHealth <= 0)
        {
            transform.position = SpawnPos.transform.position;
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(/*float damage*/ int amount)
    {
        //healthAmount -= damage;
        //healthBar.fillAmount = healthAmount / 100f;

        currentHealth -= amount;
    }

    //public void Heal(float healingAmount)
    //{
    //    healthAmount += healingAmount;
    //    healthAmount = Mathf.Clamp(healingAmount, 0, 100);

    //    healthBar.fillAmount = healthAmount / 100f;
    //}

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
