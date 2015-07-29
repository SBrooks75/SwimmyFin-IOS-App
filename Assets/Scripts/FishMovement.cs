using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public float swimSpeed = 450f;
	public float forwardSpeed = 6f;
	bool didFlap = false;
	Animator animator;
	private Rigidbody2D thisRigidbody;
	public bool dead = false;
	public bool godMode = false;
	float deathCoolDown;

	public AudioClip swimSound;

	// Use this for initialization
	void Start () {
		thisRigidbody = this.gameObject.GetComponent<Rigidbody2D>();

		animator = transform.gameObject.GetComponentInChildren<Animator>();

		if(animator == null) {
			Debug.LogError("Didn't find animator!");
		}

	
	}

	void Update() {
		if (dead) {
			deathCoolDown -= Time.deltaTime;

			if (deathCoolDown <= 0){
				if(Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
		else{
			if(Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				didFlap = true;
			}
		
		}

	
	
	}

	
	// Update is called once per frame
	void FixedUpdate () {

		if (dead)
			return;
		thisRigidbody.AddForce (Vector2.right * forwardSpeed);

		if (didFlap) {
			AudioSource.PlayClipAtPoint(swimSound, transform.position);
			AudioListener.volume = .3f;
			thisRigidbody.AddForce(Vector2.up * swimSpeed);
			didFlap = false;
		
		}
		if(thisRigidbody.velocity.y > 0) {
			float upAngle = Mathf.Lerp(0,20,(thisRigidbody.velocity.y/ 10f));
			transform.rotation = Quaternion.Euler(0, 0, upAngle);
		}
		else {
			float angle = Mathf.Lerp (0, -20, (-thisRigidbody.velocity.y / 10f) );
			transform.rotation = Quaternion.Euler(0, 0, angle);
		}

	}

	void OnCollisionEnter2D (Collision2D collision){
		if (godMode)
			return;
		animator.SetTrigger ("Death");
		dead = true;
		deathCoolDown = 1f;
	}

}
