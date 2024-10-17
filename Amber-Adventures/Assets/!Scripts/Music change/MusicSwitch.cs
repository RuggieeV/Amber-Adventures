using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public AudioSource currentBGM; // The current playing background music
    public AudioClip newBGM;       // The new music clip to switch to
    private bool hasSwitched = false; // To prevent multiple switches

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has entered the trigger zone
        if (other.CompareTag("Player") && !hasSwitched)
        {
            // Stop the current music
            currentBGM.Stop();

            // Switch to the new background music
            currentBGM.clip = newBGM;
            currentBGM.Play();

            // Prevent further switching
            hasSwitched = true;
        }
    }
}
