using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;

	//REMEMBER attacker damage and speed is set in animator events
	
	// Update is called once per frame
	void Update () { 

                // is Spawning is disabled?
		foreach(GameObject thisAttacker in attackerPrefabs){
			if(isTimeToSpawn (thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}
	
	void Spawn (GameObject myGameObject){
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
        
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn (GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond  = 1 / meanSpawnDelay;
		if(Time.deltaTime > meanSpawnDelay){
			Debug.LogWarning("spawnrate capped by framerate");
		}
		float threshold = spawnsPerSecond * Time.deltaTime;
		return (Random.value < threshold);
		
	}
}
