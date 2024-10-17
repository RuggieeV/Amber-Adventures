using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Node : MonoBehaviour
{
    public Node nextNode;


    public float FScore()
    {
        return 1;// gScore + hScore;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, nextNode.transform.position);
    }
}
