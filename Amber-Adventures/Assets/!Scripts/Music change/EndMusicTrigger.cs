using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusicTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Drag your AudioManager object here
    public AudioClip endingMusic; // Drag your final ending music clip here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the end area
        {
            audioSource.Stop(); // Stop the current music
            audioSource.clip = endingMusic; // Set the ending music clip
            audioSource.loop = false; // Optional: Disable looping for ending music
            audioSource.Play(); // Play the ending music
        }
    }
}
