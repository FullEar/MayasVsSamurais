using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;
    public float health = 3f;
    public static int EnemiesAlive = 0;

    private void Start()
    {
        EnemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > health)
        {
            Die();
        }       
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        EnemiesAlive--;
        if (EnemiesAlive <= 0)
        {
            Debug.Log("Level Won");
            SceneManager.LoadScene("WinScene");
            
        }
        Destroy(gameObject);
    }
}
