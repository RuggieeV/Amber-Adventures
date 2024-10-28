using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Node currentNode;
    public Transform currentTarget;
    public float speed = 3;
    public float stoppingDistance = 1;
    public float aggroRange = 5;
    public CircleCollider2D aggroCollider;

    Rigidbody2D rb;
    Animator m_anim;

    public AudioSource playerDetectedSound;

    public Transform m_EnemyAttack;
    public float m_EnemyAttackCooldown;
    public AudioSource attackSound;

    float m_attackTimer;

    private void Start()
    {
        transform.position = currentNode.transform.position;
        rb = GetComponent<Rigidbody2D>(); //new
        m_anim = GetComponentInChildren<Animator>(); //new
        
    }

    private void Update()
    {
        aggroCollider.radius = aggroRange;
        CreatePath();
        EnemyAnimator();
    }

    public void CreatePath()
    {
        if (currentTarget != null)
        {
            if (Vector2.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                //Reached current node, move onto next one
                if (currentTarget == currentNode.transform)
                {
                    currentNode = currentNode.nextNode;
                    currentTarget = currentNode.transform;
                }
                else
                {
                    
                }
            }

            if (Vector2.Distance(transform.position, currentTarget.position) < stoppingDistance
                && currentNode.transform != currentTarget)
            {
                playerDetectedSound.Play();
                //We are close enough to the player to do something

                //Attack?
                if (m_attackTimer < m_EnemyAttackCooldown)
                {
                    m_attackTimer += Time.deltaTime;
                }
                else
                {
                    EnemyAttack();
                }
            }
            //Move towards target
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
            }
        }
        else
        {
            currentTarget = currentNode.transform;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentTarget = collision.transform;
            //playerDetectedSound.Play();
        }
    }

    private void EnemyAnimator()
    {
        float vertical = 0;
        float horizontal = 0;

        if (currentTarget != null)
        {
            vertical = currentTarget.position.y - transform.position.y;
            horizontal = currentTarget.position.x - transform.position.x;

            if (Mathf.Abs(vertical) > Mathf.Abs(horizontal))
            {
                horizontal = 0;
            }
            else
            {
                vertical = 0;
            }
        }

       m_anim.speed = 1;
       if (vertical > 0)
       {
           m_anim.Play("Up");
       }
       else if (horizontal < 0)
       {
           m_anim.Play("Left");
       }
       else if (vertical < 0)
       {
           m_anim.Play("Down");
       }
       else if (horizontal > 0)
       {
           m_anim.Play("Right");
       }
       else
       {
           m_anim.speed = 0;
       }
    }

    private void EnemyAttack()
    {
        m_attackTimer = 0;

        Vector3 direction = (currentTarget.position - transform.position).normalized;

        Transform projectile = Instantiate(m_EnemyAttack, transform.position, transform.rotation).transform;
        attackSound.Play();

        projectile.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }
}
