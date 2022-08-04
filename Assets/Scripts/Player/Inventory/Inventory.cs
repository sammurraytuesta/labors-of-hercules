using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool hasLionDrop = false;
    private bool hasHydraDrop = false;

    //lion
    public bool HasLionDrop()
    {
        return hasLionDrop;
    }

    public void SetLionDrop(bool set)
    {
        hasLionDrop = set;
    }

    //hydra
    public bool HasHydraDrop()
    {
        return hasHydraDrop;
    }

    public void SetHydraDrop(bool set)
    {
        hasHydraDrop = set;
    }
}
