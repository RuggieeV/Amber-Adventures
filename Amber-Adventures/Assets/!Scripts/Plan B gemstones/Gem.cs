using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gem : MonoBehaviour
{
    public Transform FX;
    public AudioSource GemSound;
    public Image IdenticalGemInUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Assuming the player has a tag "Player"
        {
            GemCounter gemCounter = other.GetComponent<GemCounter>();
            if (gemCounter != null)
            {
                gemCounter.AddGem();
                Instantiate(FX, transform.position, transform.rotation);
                GemSound.Play();
                IdenticalGemInUI.color = Color.white;
                gameObject.SetActive(false);
            }
        }
    }
}
