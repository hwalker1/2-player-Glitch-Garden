using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between spawns")]
	public float seenEverySeconds;
    private bool isPlayer1;
    public bool isBadGuy;
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animator;
	
	void Start()
    {
        //isPlayer1 = gameObject.GetComponent<Defenders>().isP1Team; //if it came from the buttons on the left side it is player 1's guy vs player 2 from the right side.
        //isPlayer1 = Defenders.isP1Team;
        isPlayer1 = GetComponent<Defenders>().isP1;
        animator = GetComponent<Animator>(); //firts one is opposite direction some reason
	}
	
	void Update () {
        if (isPlayer1)
        {
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        }
        else if(isBadGuy || !isPlayer1 ) //or player2
        {
            transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        }
		if(!currentTarget)
        {
			animator.SetBool("isAttacking", false);
		}
		
	}
	
	public void SetSpeed(float speed)
    {
		currentSpeed = speed;
	}
	
	//called from anim at time of actual attack
	public void StrikeCurrentTarget(float damage)
    {
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	
	//puts it in attack mode
	public void Attack(GameObject obj)
    {
		currentTarget = obj;
	}
}
