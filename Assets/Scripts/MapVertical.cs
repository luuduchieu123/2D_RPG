using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVertical : MonoBehaviour
{
    [SerializeField] Transform playertransform;
    [SerializeField] float speed = 2f;
    [SerializeField] float minY;
    [SerializeField] float maxY;
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
            if (transform.position.y <= minY || transform.position.y >= maxY)
            {
                speed = -speed;
            }

            rb.velocity = new Vector2(0, speed);
        }

        else
        {
            rb.velocity = new Vector2();
        }
    }
}
