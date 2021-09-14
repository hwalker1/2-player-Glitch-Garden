using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text starText;
    private int stars = 25;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
        if (GetComponent<Text>())
        {
            starText = GetComponent<Text>();
            UpdateDisplay();
        }
        else
        {
            Debug.Log("error no star display text");
        }
	}
	
	public void AddStars(int amount){
		stars += amount;
        UpdateDisplay();
	}
	
	public Status UseStars(int amount){
		if(stars >= amount){
			stars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}	
		return Status.FAILURE;			
	}
	
	private void UpdateDisplay(){
        starText.text = stars.ToString();
    }
}
