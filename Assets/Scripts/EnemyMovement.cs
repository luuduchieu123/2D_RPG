using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float runSpeed;
    Rigidbody2D rb;
    //public Transform[] wps;
    //bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //  moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(runSpeed, 0f);

        //if(moveRight)
        //{
        //    if (transform.position.x >= wps[1].position.x)
        //    {
        //        moveRight = false;
        //    }
        //}
        //else
        //{
        //    if (transform.position.x <= wps[0].position.x)
        //    {
        //        moveRight = true;
        //    }
        //}

        //if (moveRight)
        //    runSpeed = 1;
        //else
        //    runSpeed = -1;

        //EnemyFlip();
        
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        runSpeed = -runSpeed;
        EnemyFlip();

    }

    void EnemyFlip()
    {
        transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x), 1f);
    }
}
