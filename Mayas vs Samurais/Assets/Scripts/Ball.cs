using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public float releaseTime = 1.5f;
    public float maxDragDistance = 2f;

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
    }
}
