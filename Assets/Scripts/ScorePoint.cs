using UnityEngine;
using System.Collections;

public class ScorePoint : MonoBehaviour {
	
	public int scoreValue = 1;
	
	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.tag == "Player") {
			
			ScoreManager.score += scoreValue;
			HighScoreManager.score+=scoreValue;
			ScoreManager2.score+=scoreValue;
		}
		
		
	}
	
	
	
}

