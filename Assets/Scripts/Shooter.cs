using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile,  gun;
	private GameObject projectileParent;
	private Animator animator;
    private Spawner myLaneSpawner; //legacy for 1player mode	
    private GameObject myLane;

	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		if(!projectileParent)
        {
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}
	
	void Update()
    {
		if(IsAttackerAheadInLane()){
			animator.SetBool("isAttacking", true);
		}else{
			animator.SetBool("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner() //tells shooter what lane its in
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        float f1 = transform.position.y, f2;


        f1 = f1 * 100;
        f1 = Mathf.RoundToInt(f1);
        f1 = f1 / 100;

        foreach (Spawner spawner in spawnerArray){
            f2 = spawner.transform.position.y;

            f2 = f2 *  100;
            f2 = Mathf.Round(f2);
            f2 = f2 / 100;

          

            


            

            if (f1 == f2){ //two lanes or one lane for players?
				myLaneSpawner = spawner;
                return;
			}
		}
		Debug.Log(name + " cant find spawner in lane (single player)"); 

        GameObject spawnLanes = GameObject.Find("Spawn Lanes");
        GameObject lane = null;
        if (!spawnLanes)
        {
            Debug.LogError("No lanes existing");
        }

        for(int i = 0; i < spawnLanes.transform.childCount; i++)
        {
            if (spawnLanes.transform.GetChild(i))
            {
         
                if (spawnLanes.transform.GetChild(i).position.y == transform.position.y) //OOOOOLd
                {
                    lane = spawnLanes.transform.GetChild(i).gameObject;
                    
                }
            }
        }

        lane = gameObject.transform.parent.transform.parent.gameObject;
       

        if (!button.isLeftSide)
        {
            myLane = lane.transform.GetChild(0).gameObject;        
        }
        else
        {
            myLane = lane.transform.GetChild(1).gameObject;          
        }

        if(myLane == null)
        {
            Debug.LogError("Unable to find lane");
        }
    }
	
	bool IsAttackerAheadInLane() 
    {
        if (myLaneSpawner)
        {
            if (myLaneSpawner.transform.childCount <= 0) { //legacy code for 1player mode 
                return false;
            }
            foreach (Transform attacker in myLaneSpawner.transform) {

                if (attacker.transform.position.x > transform.position.x) { //if lane has children that arent p1 tagg then shoot
                    return true;
                }
            }
            return false; //attackers in lane but behind us*/
        }

        if (myLane.transform.childCount <= 0)
        {
            return false;
        }
   
        if (myLane.ToString().Contains("2")) //TODO this is bad
        {
            foreach (Transform attacker in myLane.transform)
            {
                if (attacker.transform.position.x > transform.position.x)
                { 
                    return true;
                }
            }
            return false;
        }
        else
        {        
            foreach (Transform attacker in myLane.transform)
            {
                if (attacker.transform.position.x < transform.position.x)
                { 
                    return true;
                }
            }
            return false;
        }
	}

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        if (newProjectile.GetComponent<Projectile>())
        {
           
            newProjectile.GetComponent<Projectile>().isP1 = GetComponent<Defenders>().isP1;
           
        }
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
