using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStarManager : MonoBehaviour
{
    public static AStarManager instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Node> GeneratePath(Node start, Node end)
    {
        return null;
    }
}
