using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemstones : MonoBehaviour
{
    public int GemValue = 1;
    public Transform FX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            InterfaceInventory inventory = other.GetComponent<InterfaceInventory>();

            if (inventory != null)
            {
                inventory.Gemstones = inventory.Gemstones + GemValue;
                print("Player inventory has " + inventory.Gemstones + "Gem/s in it");
                Instantiate(FX, transform.position, transform.rotation);
                gameObject.SetActive(false);
            }
        }
    }

}
