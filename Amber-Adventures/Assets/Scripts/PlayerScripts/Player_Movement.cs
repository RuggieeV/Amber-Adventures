using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator m_anim;
    float horizontal;
    float vertical;
    public float runSpeed = 3.0f;

    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;

    public Transform[] spawnPoints;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponentInChildren<Animator>();

        transform.position = spawnPoints[Scene_Transition.CurrentSpawnIndex].position;
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        } //'pauses' movement until dash is finished
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left, 1 is right, 0 is neither
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down, 1 is up, 0 is neither
        MovementAnimation();

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        } //if player canDash, active coroutine(Dash)
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        } //'pauses' movement until dash is finished
        rb.velocity = new Vector2(horizontal, vertical).normalized * runSpeed;
    }

    void MovementAnimation()
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

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(horizontal, vertical).normalized * dashingPower;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DashThrough" && isDashing == true)
        {
            other.collider.isTrigger = true;
            Destroy(other.gameObject, 0f);
        }
    }
}