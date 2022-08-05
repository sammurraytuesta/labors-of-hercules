using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTutorial : MonoBehaviour
{
    public GameObject UI;
    public GameObject tutorial;
    // Start is called before the first frame update
    void Start()
    {
        UI.active = false;
        //skips welcome to leave it active
        tutorial.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("n"))
        {
            tutorial.active = false;
            UI.active = true;
        }
    }
}
