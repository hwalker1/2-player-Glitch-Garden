using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	void OnMouseDown()
    {
        Time.timeScale = 1;
        levelManager.LoadLevel("01a Start");
    }
}
