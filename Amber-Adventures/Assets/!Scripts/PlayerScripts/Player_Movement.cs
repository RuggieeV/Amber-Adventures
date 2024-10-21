using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player_Movement : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody2D rb;
    Animator m_anim;
    float horizontal;
    float vertical;
    public float runSpeed = 3.0f;

    [Header("Dashing")]
    private bool canDash = true;
    private bool isDashing;
    public float dashingPower;
    public float dashingTime;
    public float dashingCooldown;
    public Transform dashTransform;

    [Header("Primary Attack")]
    private bool canAttack;
    private float attacktimer;

    public Transform primaryAttackTransform;
    public float primaryCooldown;
    public KeyCode primaryAttackKeybind;

    [Header("Secondary Attack")]
    private bool canAttack2;
    private float attacktimer2;

    public Transform secondaryAttackTransform;
    public float secondaryCooldown;
    public KeyCode secondaryAttackKeybind;

    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponentInChildren<Animator>();
        canAttack = false;
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
        PlayerAttack();
        if (attacktimer < primaryCooldown)
        {
            attacktimer += Time.deltaTime;
        }
        else
        {
            canAttack = true;
        }


        if (attacktimer2 < secondaryCooldown)
        {
            attacktimer2 += Time.deltaTime;
        }
        else
        {
            canAttack2 = true;
        }

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
            m_anim.Play("Lucario_Up");
        }
        else if (horizontal < 0)
        {
            m_anim.Play("Lucario_Left");
        }
        else if (vertical < 0)
        {
            m_anim.Play("Lucario_Down");
        }
        else if (horizontal > 0)
        {
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
        var NewDashFX = Instantiate(dashTransform, transform.position, transform.rotation);
        NewDashFX.transform.parent = gameObject.transform;
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



    private void PlayerAttack()
    {   
        if (Input.GetKeyDown(primaryAttackKeybind) && canAttack)
        {
            Instantiate(primaryAttackTransform, transform.position, transform.rotation); //Doesnt shoot in direction. Need fix
        }

        if (Input.GetKeyDown(secondaryAttackKeybind) && canAttack2)
        {
            Instantiate(secondaryAttackTransform, transform.position, transform.rotation);
        }
    }
}