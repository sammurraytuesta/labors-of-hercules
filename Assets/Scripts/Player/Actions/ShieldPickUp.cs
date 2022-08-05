using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShieldPickUp : MonoBehaviour
{
    public Inventory player;
    void Start()
    {
    }

    void OnTriggerEnter(Collider col){
	if(col.CompareTag("Player")){
		player = col.gameObject.GetComponent<Inventory>();
		player.SetLionDrop(true);
		Destroy(gameObject);
		print("Nemean Hide collected!");
        SceneManager.LoadScene("Assets/Scenes/Hub.unity");
        }
    }
}
