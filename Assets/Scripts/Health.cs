using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;
	
	public void DealDamage(float damage){
		health -= damage;
		if(health <= 0){
			//TODO die animation
			DestroyObject();
		} 
		
	}
	
	public void DestroyObject(){
		Destroy(gameObject);
	}
}
