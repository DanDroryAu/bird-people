using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 5f;
	GameManager gameManager;
 
    [SerializeField]TMP_Text countdownText;
 
    private void Start()
    {
		gameManager = FindObjectOfType<GameManager>();
        currentTime = startingTime;
    }
 
    private void Update()
    {
		if(currentTime <= 0) {
			gameManager.StartGame();
			gameObject.SetActive(false);
		} else {
			currentTime -= 1 * Time.deltaTime;

			if(currentTime < 1) {
			countdownText.text = "Fkin Oath";
			GameManager.Instance.StartGame();
			} else {

       		countdownText.text = currentTime.ToString("0");
			}
		}
    }
}
