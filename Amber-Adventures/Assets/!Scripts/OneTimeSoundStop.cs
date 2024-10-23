using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeSoundStop : MonoBehaviour
{
    static bool Play = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (!Play)
        {
            Play = true;
            gameObject.SetActive(false);
        }
    }
}
