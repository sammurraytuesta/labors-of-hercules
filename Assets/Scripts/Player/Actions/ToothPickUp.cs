using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPickUp : MonoBehaviour
{
    public Inventory player;
    void Start()
    {
    }

    void OnTriggerEnter(Collider col){
	if(col.CompareTag("Player")){
		player = col.gameObject.GetComponent<Inventory>();
		player.SetHydraDrop(true);
		Destroy(gameObject);
		print("Hydra Poison collected!");
	}
    }
}
