using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Node currentNode;
    public Transform currentTarget;
    public float speed = 3;
    public float stoppingDistance = 1;

    private void Start()
    {
        transform.position = currentNode.transform.position;
    }

    private void Update()
    {
        CreatePath();
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
                //Reached target (probably the player)
                else
                {
                    
                }
            }
            if (Vector2.Distance(transform.position, currentTarget.position) < stoppingDistance
                && currentNode.transform != currentTarget)
            {
                //We are close enough to the player to do something
                
                //Attack?
                if (currentTarget.CompareTag("Player"))
                {

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
}
