using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Unit : MonoBehaviour
{
    [Header("Health System")] 
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int damageLevel;
    [SerializeField] private int healLevel;
    public int currentHealth;
    public bool isUnderOrder = false;
   
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
        currentHealth = 100;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)&& CompareTag("Enemy"))     
        {
            int calc = currentHealth - damageLevel;
        
            if (calc <=0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = calc;
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
            //print(currentHealth);
        }
        
        if (Input.GetKeyDown(KeyCode.E)&& CompareTag("Unit"))     
        {
            int calc = currentHealth - damageLevel;
        
            if (calc <=0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = calc;
            }

            healthBar.UpdateHealthBar(maxHealth, currentHealth);
            //print(currentHealth);
        }
    
        if (Input.GetKeyDown(KeyCode.H))   
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
            //print(currentHealth);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((this.CompareTag("Unit"))&&(other.CompareTag("Enemy"))  )
        {
            other.GetComponent<Unit>().Damage(damageLevel);
        }
        if ((this.CompareTag("Enemy"))&&(other.CompareTag("Unit"))  )
        {
            other.GetComponent<Unit>().Damage(damageLevel/2);
        }
        if ((this.CompareTag("Unit"))&&(other.CompareTag("Unit"))  )
        {
            other.GetComponent<Unit>().Heal(healLevel);
        }
    }

    private void OnDestroy()
    {
        //UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
        UnitSelectionManager.Instance.nbtotunitslost += 1;
    }

    public void Damage(int damage)
    {
        int calc = currentHealth - damage;
        
        if (calc <=0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = calc;
        }

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        //print(currentHealth);
    }
    
    public void Heal(int heal)
    {
        int calc = currentHealth + heal;
        
        if (calc >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = calc;
        }

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        //print(currentHealth);
    }
    

    
}
