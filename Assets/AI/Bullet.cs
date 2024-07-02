using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    //public int scoreValue = 10;  // The score value to add when the player is hit

    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);

            // Add score
            //ScoreManager.Instance.AddScore(scoreValue);
           // ScoreManager.Instance.Kill();
        }

        Destroy(gameObject);
    }
}
