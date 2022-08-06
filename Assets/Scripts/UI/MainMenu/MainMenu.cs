using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
	public GameObject player;

	void Start () {
		Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		player = GameObject.FindGameObjectWithTag("Player");
		
		SceneManager.LoadScene("Assets/Scenes/Hub.unity");
	}
}
