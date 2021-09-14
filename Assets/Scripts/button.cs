using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class button : MonoBehaviour {
	
	public GameObject protectorPrefab;
    //public int fadeInTime = 3; TODO implement fadin respawn
	private button[] buttonArray;
	public static GameObject selectedProtector;
	private Text costText;
    public bool leftSide;
    public static bool isLeftSide; //static? do i need side on the button?
   
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<button>();
		costText = GetComponentInChildren<Text>();
		if(!costText){
			Debug.LogWarning("no cost text assigned");
		}
		costText.text = protectorPrefab.GetComponent<Defenders>().starCost.ToString(); 
    }
	
	void OnMouseDown(){
        Color greyed = Color.white;
        greyed.a = 0.5f;
		foreach(button thisButton in buttonArray){
            thisButton.GetComponent<SpriteRenderer>().color = greyed;  
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedProtector = protectorPrefab;
        isLeftSide = leftSide;
    }

}
