using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusUpd : MonoBehaviour
{
    [SerializeField] private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        print("problemo");
    }

    // Update is called once per frame
    void Update()
    {
        string a = "hjkj";
    }
    /*public void Damage(int damageLevel)
    {
        int calc = go.currentHealth - damageLevel;
        
        if (calc <=0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = calc;
        }

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }
    
    public void Heal(int healLevel)
    {
        int calc = currentHealth + healLevel;
        
        if (calc > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = calc;
        }
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }*/
}
