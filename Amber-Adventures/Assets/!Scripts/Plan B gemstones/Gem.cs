using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    public Transform FX;
    public AudioSource GemSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a tag "Player"
        {
            GemCounter gemCounter = other.GetComponent<GemCounter>();
            if (gemCounter != null)
            {
                gemCounter.AddGem();
                Instantiate(FX, transform.position, transform.rotation);
                //GemSound.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
