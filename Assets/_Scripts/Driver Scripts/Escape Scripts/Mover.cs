using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }
}