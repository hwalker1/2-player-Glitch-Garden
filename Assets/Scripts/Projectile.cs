using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed, damage;
    public bool isP1;

	void Update ()
    {
        if (isP1)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); //TODO add isBadGuy bool so opponents can have cacti too
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }	
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
		Health health = collider.gameObject.GetComponent<Health>();
        if (collider.GetComponent<Defenders>())
        {
            if (isP1 != collider.GetComponent<Defenders>().isP1 && health)
            {
                health.DealDamage(damage);
                Destroy(gameObject); //Destroy projectile cause it smacked somebody
            }
        }
	}
}
