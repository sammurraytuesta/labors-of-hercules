using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<Inventory>().HasHydraDrop() && player.GetComponent<Inventory>().HasLionDrop())
        {
            SceneManager.LoadScene("Assets/Scenes/End.unity");
        }
    }
}
