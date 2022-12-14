using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosDestruibles : MonoBehaviour
{
    public float resistance;
    public GameObject explosionPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > resistance)
        {
            if(explosionPrefab != null)
            {
                var go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

                Destroy(go, 3);
            }
                Destroy(gameObject, 0.1f);
        }
        else
        {
            resistance -= collision.relativeVelocity.magnitude;
        }
    }
}
