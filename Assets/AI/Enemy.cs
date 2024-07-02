using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform targetPlayer;
    public string tagObject;
    NavMeshAgent navMeshAgent;
    public int maxHealth = 100;
    private int currentHealth;
    public int damage = 10;
    public float attackRange = 2f;
    public float detectionRange = 10f;

     void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        if (targetPlayer == null)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    internal void SetPatrolPoints(Transform[] transforms)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (distanceToPlayer <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
        
    }

    void AttackPlayer()
    {
        navMeshAgent.isStopped = true;
        PlayerHealth playerHealth = targetPlayer.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void ChasePlayer()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(targetPlayer.position);
    }

     public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            
            Die();
        }
    }

    void Die()
    {
        ScoreManager.Instance.Kill();
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagObject))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            Destroy(other.gameObject);
            navMeshAgent.isStopped = true;
            StartCoroutine(ClearObject());
        }
    }

    IEnumerator ClearObject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}





