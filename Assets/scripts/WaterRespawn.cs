using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = respawnPoint.gameObject.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }

}
