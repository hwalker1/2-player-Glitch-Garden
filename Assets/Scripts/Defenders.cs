using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private StarDisplay p1StarDisplay;
    private StarDisplay p2StarDisplay;
    public int starCost;
    public bool isP1;

	// Use this for initialization
	void Start () {
        StarDisplay[] displays = GameObject.FindObjectsOfType<StarDisplay>();  //this only matters for star generator (should probably rename the sacirpt)
        foreach (StarDisplay display in displays)
        { 
            if (display.ToString().Contains("First"))
            {
                p1StarDisplay = display;
             
            }
            if (display.ToString().Contains("Second"))
            {
                p2StarDisplay = display;
               
            }
        }
        if (!p2StarDisplay || !p1StarDisplay)
        {
          //  Debug.Log("Error unable to find all star displays");
        }
    }
	
	public void AddStars(int amount){
        if (isP1)
        {
            p1StarDisplay.AddStars(25);
        }
        else
        {
            p2StarDisplay.AddStars(25);
        }
		
	}	
}
