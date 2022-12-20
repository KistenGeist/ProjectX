using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    [HideInInspector] public float DaggerVelocity;
    [SerializeField] Rigidbody2D rb;
    public Vector3 CurrenPostion;

    private void FixedUpdate()
    {
        if (rb != null)
            rb.velocity = transform.up * DaggerVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.isKinematic = false;
        rb.velocity = Vector2.zero;
        CurrenPostion = transform.position;
        Destroy(rb);
    }
}
