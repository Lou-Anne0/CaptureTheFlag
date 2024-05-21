using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;
public class HealthSystem : MonoBehaviour
{
    //public static HealthSystem Instance { get; set; }
    private NavMeshAgent enemyAgent;
    private Vector3 destPatrolLeft;
    private Vector3  destPatrolRight;
    

    //public Transform DestPatrol = new Transform();
    

    private void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        destPatrolLeft = this.transform.position;
        destPatrolLeft.z = 234;
        destPatrolRight= this.transform.position;
        destPatrolRight.z = 156;
        enemyAgent.destination = destPatrolLeft;
    }
    //destOne =
    private void Update()
    {
        float distPatrolLeft = Vector3.Distance(this.transform.position, destPatrolLeft);
        //print(distDestination);
        if (distPatrolLeft <= 1.5f)
        {
            enemyAgent.destination = destPatrolRight;
        }
        
        float distPatrolRight = Vector3.Distance(this.transform.position, destPatrolRight);
        //print(distDestination);
        if (distPatrolRight <= 1.5f)
        {
            enemyAgent.destination = destPatrolLeft;
        }
    }
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


