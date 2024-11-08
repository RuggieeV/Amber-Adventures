using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoolDownUI : MonoBehaviour
{
    public Sprite cooldownSprite;         // Assign your sprite from the assets
    public float cooldownDuration = 5f;   // Set cooldown duration here
    private Image cooldownImage;          // Image created at runtime
    private bool isCooldown = false;

    void Start()
    {
        // Create an Image object on the Canvas
        GameObject canvas = GameObject.Find("Canvas"); // Ensure there's a Canvas in the scene
        if (canvas != null)
        {
            GameObject imageObject = new GameObject("CooldownImage");
            imageObject.transform.SetParent(canvas.transform);
            cooldownImage = imageObject.AddComponent<Image>();

            // Set the sprite and initial color
            cooldownImage.sprite = cooldownSprite;
            cooldownImage.color = Color.white;  // Default to normal color
            cooldownImage.fillAmount = 1f;      // Full fill amount to start
        }
        else
        {
            Debug.LogError("No Canvas found in the scene.");
        }
    }

    public void StartCooldown()
    {
        if (!isCooldown && cooldownImage != null)
        {
            StartCoroutine(CooldownRoutine());
        }
    }

    private IEnumerator CooldownRoutine()
    {
        isCooldown = true;

        // Change image color to grey
        Color originalColor = cooldownImage.color;
        cooldownImage.color = new Color(0.5f, 0.5f, 0.5f, originalColor.a);

        float elapsedTime = 0f;
        while (elapsedTime < cooldownDuration)
        {
            // Update the fill amount or apply other effects as needed
            cooldownImage.fillAmount = 1 - (elapsedTime / cooldownDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset the color and fill amount
        cooldownImage.color = originalColor;
        cooldownImage.fillAmount = 1f;
        isCooldown = false;
    }
}
