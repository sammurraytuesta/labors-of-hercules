using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<playerMove>().health <= 0)
        {
            SceneManager.LoadScene("Assets/Scenes/Retry.unity");
        }
    }
}
