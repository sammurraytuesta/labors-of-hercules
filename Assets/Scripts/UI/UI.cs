using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject player;
    //inventory load
    public GameObject inventory;
    public Button inventEnter;
    public Button inventExit;
    //inventory items
    public GameObject lion;
    public GameObject hydra;
    //settings load
    public GameObject settings;
    public Button setEnter;
    public Button setExit;
    // Start is called before the first frame update
    void Start()
    {
        //inventory
        inventory.active = false;
        
        Button inventEnterBtn = inventEnter.GetComponent<Button>();
		inventEnterBtn.onClick.AddListener(InventEnter);
        Button inventExitBtn = inventExit.GetComponent<Button>();
		inventExitBtn.onClick.AddListener(InventExit);

        //inventory items
        lion.active = false;
        hydra.active = false;

        //settings
        settings.active = false;
        
        Button setEnterBtn = setEnter.GetComponent<Button>();
		setEnterBtn.onClick.AddListener(SetEnter);
        Button setExitBtn = setExit.GetComponent<Button>();
		setExitBtn.onClick.AddListener(SetExit);
    }

    // Update is called once per frame
    void Update()
    {
        //inventory items
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Inventory>().HasLionDrop())
        {
            lion.active = true;
        }
        if (player.GetComponent<Inventory>().HasHydraDrop())
        {
            hydra.active = true;
        }
    }

    //inventory
    void InventEnter()
    {
        inventory.active = true;
        Time.timeScale = 0;
    }

    void InventExit()
    {
        inventory.active = false;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    //settings
    void SetEnter()
    {
        settings.active = true;
        Time.timeScale = 0;
    }
    
    void SetExit()
    {
        settings.active = false;
        Cursor.visible = false;
        Time.timeScale = 1;
    }
}
