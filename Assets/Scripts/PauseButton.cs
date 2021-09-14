using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    private LevelManager levelManager;
    private bool paused;
    private GameObject obj;
    private GameObject bar;

    // Use this for initialization
    void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
        paused = false;
        obj = GameObject.Find("PauseMenuText");
        obj.SetActive(false);
        bar = GameObject.Find("Red line");
 
    }
	
	void OnMouseDown()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
            obj.SetActive(true);
            bar.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            obj.SetActive(false);
            bar.SetActive(true);
        }      
    }
}
