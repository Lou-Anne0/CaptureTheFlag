using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Unit : MonoBehaviour
{
    [Header("Health System")] 
    [SerializeField] private int maxHealth;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int damageLevel;
    [SerializeField] private int healLevel;
    private int currentHealth;
   
    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);
        currentHealth = 100;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))     
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

    private void OnDestroy()
    {
        //UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
        //UnitSelectionManager.Instance.nbtotunitslost += 1;
    }

    
}
