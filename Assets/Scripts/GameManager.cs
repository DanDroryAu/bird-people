using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

public static GameManager Instance {
	get; private set;
}


//check and delete itself if it exists
void Awake() {
	if(Instance != null && Instance != this) {
		Destroy(this);
	}
	else {
		Instance = this;
	}
}
	

	[SerializeField] TMP_Text timeText;
	[SerializeField] TMP_Text scoreText;

	// int Score = 0;
	float timeRemaining = 60f;
	

    // Start is called before the first frame update
    void Start()
    {
		// Set the text test
		timeText.text = "Time" ;
		scoreText.text = "Score test";
    }


	// Creates a Ray from the mouse position
	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


    void Update()
    {

        // Debug.DrawRay(Input.mousePosition, d);


		
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
			updateTimeText(timeRemaining);
        }
		else {
			timeText.text = "0";
			Debug.Log("End Game");
		}
    }

	void updateTimeText(float newTime) {
		timeText.text = newTime.ToString();

	}


	
	private void handleStartGame() {


	}

	private void handleQuitGame() {
		
	}

}
