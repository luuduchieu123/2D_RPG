using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapmovement : MonoBehaviour
{
    [SerializeField] Transform playertransform;
    [SerializeField] float speed = 1f;
    [SerializeField] float minX = -11f;
    [SerializeField] float maxX = -4f;
    Rigidbody2D rb;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Mathf.Abs(transform.position.x - playertransform.position.x) <= 1.5f)
        {
            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                speed = -speed;
            }

            rb.velocity = new Vector2(speed, 0);
        }

        else
        {
            rb.velocity = new Vector2();
        }
    }
}
