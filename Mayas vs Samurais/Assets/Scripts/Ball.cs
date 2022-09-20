using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = 1.5f;
    public float maxDragDistance = 2f;
    public float waitingSeconds = 2f;

    public GameObject nextBall;

    private bool isPressed = false;

    public Camera Cam;

    void Update()
    {

        if (isPressed)
        {
            Vector2 mousePos = Cam.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
            {
                rb.position = hook.position + (hook.position - hook.position).normalized * maxDragDistance;
            }

            else
                 rb.position = mousePos;
        }
    }

    void OnMouseDown ()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp ()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds (waitingSeconds);
        
        if (nextBall != null)
        {
            nextBall.SetActive(true);
        }
        else
        {
            // Usar la funcion de abajo si se reinicia el nivel o se cambia de nivel para que no se dupliquen los enemigos en la escena.
            //Enemy.EnemiesAlive = 0;
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
