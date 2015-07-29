using UnityEngine;
using System.Collections;

public class SandMover : MonoBehaviour {
	
	
	Rigidbody2D player;
	
	float speed = 13f;
	void Awake () {
		GameObject player_go = GameObject.FindGameObjectWithTag ("Player");
		
		if (player_go == null) {
			Debug.LogError ("Couldn't find an object with tag 'Player'");
			return;
			
		}
		
		player = player_go.GetComponent<Rigidbody2D>();
	}
	
	
	
	void FixedUpdate() {
		float vel = player.velocity.x * 0.75f;
		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
		
		
	}
	
	
}
