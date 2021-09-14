using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private bool isP1;
	private Attacker attacker;

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

        if (obj.GetComponent<Stone>())
        {
			anim.SetTrigger("Jump trigger");
		} else
        {
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
		
	}
}
