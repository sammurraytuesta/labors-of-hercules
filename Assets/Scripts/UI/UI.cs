using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //settings load
    public GameObject settings;
    public Button setEnter;
    public Button setExit;
    // Start is called before the first frame update
    void Start()
    {
        settings.active = false;
        
        Button setEnterBtn = setEnter.GetComponent<Button>();
		setEnterBtn.onClick.AddListener(SetEnter);
        Button setExitBtn = setExit.GetComponent<Button>();
		setExitBtn.onClick.AddListener(SetExit);
    }

    void SetEnter()
    {
        settings.active = true;
        Time.timeScale = 0;
    }
    
    void SetExit()
    {
        settings.active = false;
        Time.timeScale = 1;
    }
}
