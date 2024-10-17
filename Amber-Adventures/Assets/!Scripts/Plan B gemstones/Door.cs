using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Plate; // The actual door object (physical blocking part)
    private bool doorUnlocked = false;
    public Transform FX;
    private BoxCollider2D doorCollider; // Non-trigger collider to block the door

    private void Start()
    {
       doorCollider = Plate.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GemCounter gemCounter = other.GetComponent<GemCounter>();
            if (gemCounter != null && gemCounter.HasAllGems() && !doorUnlocked)
            {
                UnlockDoor();
            }
            else
            {
                Debug.Log("Not enough gems to unlock the door");
            }
        }
    }

    void UnlockDoor()
    {
        Debug.Log("Door unlocked!");
        doorUnlocked = true;
        Instantiate(FX, transform.position, transform.rotation);
        doorCollider.enabled = false; // Disable the blocking collider
        Plate.SetActive(false); // Optionally disable the door visually
    }
}
