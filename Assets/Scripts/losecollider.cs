using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))] //this?
public class losecollider : MonoBehaviour {

	private LevelManager levelManager;
    public int life;
    private Text healthText;
	// Use this for initialization
	void Start () {
        life = 3;
		levelManager = GameObject.FindObjectOfType<LevelManager>();

        if (gameObject.GetComponentInChildren<Text>())  //.Child.GetComponent<Text>())
        {
            healthText = gameObject.GetComponentInChildren<Text>();
            UpdateHealth();
        }
        else{
            Debug.Log("Error no health display");
        }
	}
	
	void OnTriggerEnter2D(Collider2D collider){
        if (!collider.GetComponent<Projectile>()) //why this no work
        {
            print("empty proj");
           
        }
        //print(collider.GetComponent<Projectile>().damage);
        print(collider.GetComponent<HealthColliderProjectile>());
        if (collider.GetComponent<HealthColliderProjectile>()) //why this no work
        {
            print("projectile no hurt");
            return;
        }
        life--;
        UpdateHealth();
        if (life <= 0)
        {
            levelManager.LoadLevel("04b Lose");
        }
		
	}

     void UpdateHealth()
     {
        healthText.text = life.ToString();
     }
}
