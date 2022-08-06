using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public Button startButton;
    public GameObject player;

	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Inventory>().SetHydraDrop(false);
        player.GetComponent<Inventory>().SetLionDrop(false);
	}
}
