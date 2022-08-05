using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnControllsHelp : MonoBehaviour
{
    public Canvas controllCanvas;

    private void Start()
    {
        controllCanvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controllCanvas.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            controllCanvas.enabled = false;
        }
    }
}
