using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 0.025f;

    private void Update()
    {
        gameObject.transform.Translate(Vector2.left * speed);
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector2(21, transform.position.y);
    }
}
