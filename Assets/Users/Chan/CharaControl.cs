using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaControl : MonoBehaviour
{
    public float moveSpeed = 3f;
    Rigidbody2D rb;
    Sprite sp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();

        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x > 0)
        {
            transform.localScale = new Vector3 (-1, 1, 1);
        }
        else if(x < 0)
        {
            transform.localScale = new Vector3 (1, 1, 1);
        }
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
    }

    void Attack()
    {

    }
}
