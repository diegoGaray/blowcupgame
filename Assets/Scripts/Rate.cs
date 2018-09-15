using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rate : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Application.OpenURL("http://play.google.com/store/apps/details?id=com.garapps.blowcup.games");
    }
    

    // Update is called once per frame
    void Update()
    {
    }
    
}
