using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HealthSystem
{
    /*
    public void Damage(Unit cible, int damage)
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
    }*/
    /*
    private NavMeshAgent agent;
    private Transform target; // Destination or enemy to follow
    public float attackRange = 1f; // Radius for attacking enemies
    public int attackDamage = 5; // Amount of damage dealt per attack

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target != null)
        {
            // Move towards the target
            agent.SetDestination(target.position);

            // If the target is an enemy and within attack range, attack
            if (target.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, target.position);
                if (distance <= attackRange)
                {
                    AttackEnemy(target);
                }
            }
        }
    }

    // Brouillon
    /*
    public void SetDestination(Vector3 destination)
    {
        target = null; // Reset the target to prevent following enemies
        agent.SetDestination(destination);
    }

    // Set the enemy to follow
    public void FollowEnemy(Transform enemy)
    {
        target = enemy;
    }

    // Example method for attacking an enemy
    void AttackEnemy(Transform enemy)
    {
        // Reduce enemy's health
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(attackDamage);
        }
    }
    */
}


