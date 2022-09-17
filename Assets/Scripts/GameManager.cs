using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager: MonoBehaviour {
  bool gamePlaying = false;
  SceneController sceneController;

  public static GameManager Instance {
    get;
    private set;
  }
  [SerializeField] TMP_Text timeText;
  [SerializeField] TMP_Text scoreText;

  // int Score = 0;
  [SerializeField] float timeRemaining;
  int score = 0;

  //check and delete itself if it exists
  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(this);
    } else {
      Instance = this;
    }
  } 

  private void Start() {
	sceneController = FindObjectOfType<SceneController>();
	scoreText.text = "";
	timeText.text = "";
  }

  void Update() {
    if (gamePlaying) {
      Raycast();
      if (timeRemaining > 0) {
        timeRemaining -= Time.deltaTime;
        updateTime(timeRemaining);
      } else {
        timeText.text = "0";
        Debug.Log("End Game");
		sceneController.LoadGameOver();
      }
    }

  }

   void Raycast() {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100f)) {
      //draw invisible ray cast/vector
      Debug.DrawLine(ray.origin, hit.point);
      //log hit area to the console
      Debug.Log(hit.collider);

      //delete object 
      if (Input.GetMouseButton(0)) {
        Debug.Log("Pressed left click.");
        GameObject item = hit.collider.gameObject;

        if (item.tag == ("Food")) {
          timeRemaining += 5f;
          Destroy(hit.collider.gameObject);
          updateScore(50);

        } else if (item.tag == "Trash") {
          Destroy(hit.collider.gameObject);
        }

      }
          
    }
  }

  void updateTime(float newTime) {
    timeText.text = "Time Left:" + "\n" + newTime.ToString("0.00");
  }

  void updateScore(int points) {
    score += points;
    scoreText.text = "Score:" + "\n" + score.ToString();
  }

  public void StartGame(){
	Debug.Log("Game Playing");
	gamePlaying = true;
  }

   public void QuitGame(){
	Debug.Log("Exiting Game");
	Application.Quit();
  }

}