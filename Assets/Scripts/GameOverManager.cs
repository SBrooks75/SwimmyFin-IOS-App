using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public FishMovement fishDeadOrNot;
	public float restartDelay = 5f;
	Animator anim;
	float restartTimer;

	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (fishDeadOrNot.dead==true)
		{
			anim.SetTrigger("GameOver");
		}
	}
}
