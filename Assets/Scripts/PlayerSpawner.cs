using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour { //previously DefenderSpawner
	
	public Camera myCamera;
	private StarDisplay p1StarDisplay;
    private StarDisplay p2StarDisplay;
    private GameObject parent;
    public Vector2 gridSize;
    public bool isSinglePlayer;
   
    void Start()
    {
        parent = GameObject.Find("Spawn Lanes");
        if (!parent)
        {
            parent = new GameObject("Spawn Lanes");



            for (float i = gridSize.y; i >= 1; i--)
            {

                float yPos = gridSize.y / 5 * i; //calculates y position for lane
                GameObject lane = new GameObject("Lane " + i);
                lane.transform.position += new Vector3(0, yPos, 0);
                lane.transform.parent = parent.transform;

                GameObject p1Lane = new GameObject("Player 1"); //lane for player 1 defenders
                p1Lane.transform.parent = lane.transform;

                GameObject p2Lane = new GameObject("Player 2"); //lane for player 2 defenders 
                p2Lane.transform.parent = lane.transform;
            }
        }

        StarDisplay[] displays = GameObject.FindObjectsOfType<StarDisplay>();
      

        foreach(StarDisplay display in displays)
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
        if(!p2StarDisplay || !p1StarDisplay)
        {
            Debug.Log("Error unable to find all star displays");
        }




        /*p1StarDisplay = displays[0];    //0  
        p2StarDisplay = displays[1]; //why doesnt this one work
        if (!p2StarDisplay) { p2StarDisplay = displays[2];  }
        if (!p1StarDisplay) { print("bad star display p1"); }
        //what the fuuuuuck why does this one work*/
    }
	
	void OnMouseDown()
    {
		Vector2 rawPos =  CalculateWorldPointOfMouseClick();
        Vector2 gridDimensions = gridSize;
        Vector2 roundPos = CustomSnapToGrid(rawPos, gridDimensions);

        if (button.selectedProtector)
        {
            GameObject defender = button.selectedProtector; //TODO add fade in here?
            int defenderCost = defender.GetComponent<Defenders>().starCost;
            
            if (button.isLeftSide)
            {
                if (roundPos.x <= 4.5 || isSinglePlayer)
                {
                    if (p1StarDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
                    {
                        SpawnDefender(roundPos, defender);
                    }
                    else
                    {
                        Debug.Log("insufficient stars");
                        //TODO add little star text shake insteadof log
                    }
                }              
                else
                {
                    Debug.Log("must be on p1 side");
                }
            }
            else
            {
                if (roundPos.x >= 5.5)
                {
                    if (p2StarDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
                    {
                        SpawnDefender(roundPos, defender);
                    }
                    else
                    {
                        Debug.Log("insufficient stars");
                        //TODO add little star text shake insteadof log
                    }
                }
                else
                {
                    Debug.Log("must be on p2 side");
                }
            }
        }
        else
        {
            Debug.Log("No protector selector");
        }
	}
	
	Vector2 CalculateWorldPointOfMouseClick()
    {
		float mouseX= Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		Vector3 weirdTriplet = new Vector3(mouseX,mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		return worldPos;
	}

    float RoundToGrid(float pos, float gridLength, bool isYAxis) //rounds position to center of one of the units of the lane with adjustable grid
    {
        float roundedPos, scale;
        if (isYAxis) //yAxis is 5 unity (world?)units long 
        {
            scale = 5 / gridLength;   
        }
        else // xAxis is 9 unity (world?)units long 
        {    
            scale = 9 / gridLength;   
        }
        roundedPos = Mathf.RoundToInt(pos / scale) * scale;  //round to closest unit of scale
        return roundedPos;
    }

    Vector2 CustomSnapToGrid(Vector2 rawWorldPos, Vector2 gridDimensions)
    {
        float newX = RoundToGrid(rawWorldPos.x, gridDimensions.x, false); //the true/false is isYAxis
        float newY = RoundToGrid(rawWorldPos.y, gridDimensions.y, true);
        return new Vector2(newX, newY);
    }

    void RoundToLane(int yPos)
    {
        float amtLanes = gridSize.y;
    }


    void SpawnDefender (Vector2 roundPos, GameObject defender)
    {
        float xScale = 9 / gridSize.x;
        
        if(button.isLeftSide)
        {
           xScale = xScale * -1;
        }
        float yScale = 5 / gridSize.y;
        float laneNum = roundPos.y / yScale; //nice

        GameObject newDef = Instantiate (defender, roundPos, Quaternion.identity) as GameObject;
        Vector3 gridScale = new Vector3( xScale, yScale, 0); //TODO add left and right facing scaling
        newDef.transform.localScale = gridScale; //changes size so it fits better

        if(GameObject.Find("Lane " + laneNum.ToString()))
        {
            parent = GameObject.Find("Lane " + laneNum.ToString());
        }
        else
        {
            print("missing lane " + laneNum);
        }
        if (button.isLeftSide)
        {
            newDef.transform.parent = parent.transform.Find("Player 1");   
        }
        else
        {
            newDef.transform.parent = parent.transform.Find("Player 2");
        }  
	}
}
