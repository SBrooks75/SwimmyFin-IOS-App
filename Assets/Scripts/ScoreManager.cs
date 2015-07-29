using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	public static int score;
	
	
	public static Text text;
	
	
	
	public static int highScore;
	
	
	
	
	
	
	
	
	void Awake()
	{
		text = GetComponent <Text> ();
		
		highScore = PlayerPrefs.GetInt ("highScore", 0);
		
		
		score = 0;
		
		
	}
	
	void OnDestroy() {
		
		if (score > highScore) {
			highScore = score;
			
			
		}
		PlayerPrefs.SetInt ("highScore", highScore);
		
	}
	
	
	
	void Update ()
	{
		text.text = "Score: " + score;
		
		if (score > highScore) {
			highScore = score;
			
			
		}
		
	}
}
