using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker;
    private bool isP1;
 
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        isP1 = GetComponent<Defenders>().isP1;
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		GameObject obj = collider.gameObject;

        if (obj.GetComponent<Defenders>())
        {
            if (obj.GetComponent<Defenders>().isP1 == isP1)
            {
                return;
            }
        }
        else
        {
            return;
        }      
		anim.SetBool("isAttacking", true);
		attacker.Attack(obj);
    }
}
