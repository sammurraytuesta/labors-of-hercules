using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    public playerMove player;
    void Start()
    {
    }

    void OnTriggerEnter(Collider col){
	if(col.CompareTag("Player")){
		player = col.gameObject.GetComponent<playerMove>();
		player.hasLionDrop = true;
		Destroy(gameObject);
		print("Nemean Hide collected!");
	}
    }
}
