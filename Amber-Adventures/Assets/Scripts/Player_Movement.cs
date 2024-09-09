using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D body;

    Animator m_anim;

    float horizontal;
    float vertical;

    public float runSpeed = 3.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        m_anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        Animation();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
    }

    void Animation()
    {
        m_anim.speed = 1;
        if (vertical > 0)
        {
            Console.WriteLine("lucario.anim.up");
            m_anim.Play("Lucario_Up");
        }
        else if (horizontal < 0)
        {
            Console.WriteLine("lucario.anim.left");
            m_anim.Play("Lucario_Left");
        }
        else if (vertical < 0)
        {
            Console.WriteLine("lucario.anim.down");
            m_anim.Play("Lucario_Down");
        }
        else if (horizontal > 0)
        {
            Console.WriteLine("lucario.anim.right");
            m_anim.Play("Lucario_Right");
        }
        else
        {
            m_anim.speed = 0;
        }
    }

}
