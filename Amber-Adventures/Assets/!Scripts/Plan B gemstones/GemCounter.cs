using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCounter : MonoBehaviour
{
    public int gemCount = 0; // Track the number of gems collected
    public int totalGemsNeeded = 6; // Total number of gems required to unlock the door

    // Method to add a gem
    public void AddGem()
    {
        gemCount++;
        Debug.Log("Gem collected! Total: " + gemCount);
    }

    // Check if all gems are collected
    public bool HasAllGems()
    {
        return gemCount >= totalGemsNeeded;
    }
}
