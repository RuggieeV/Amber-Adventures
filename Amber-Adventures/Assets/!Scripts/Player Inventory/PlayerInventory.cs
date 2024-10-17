using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, InterfaceInventory
{
    public int Gemstones { get => gemstones; set => gemstones = value; }


    public int gemstones = 0;
}
