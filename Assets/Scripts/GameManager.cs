using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour {

  AudioSource gameAudioSource;
  AudioClip timeAddedSFX;
  AudioClip[] countDownSFXList;

  Animator timeAddedAnim;


  public bool gamePlaying = false;
  SceneController sceneController;

  public int startGameTime = 60;

  public static GameManager Instance {
    get;
    private set;
  }
  [SerializeField] TMP_Text timeText;
  [SerializeField] TMP_Text scoreText;
  [SerializeField] TMP_Text timeUpText;
  GameObject timeUpObj;

  // int Score = 0;
  [SerializeField] float timeRemaining;
  public int score = 50;

  //check and delete itself if it exists
  void Awake() {
    if (Instance != null && Instance != this) {
      Destroy(this);
    } else {
      Instance = this;
      DontDestroyOnLoad(gameObject);
      SceneManager.sceneLoaded += OnSceneLoaded;
    }
  } 

  void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
    Debug.Log("Loaded Level Again");
    if (SceneManager.GetActiveScene().name == "WheelyBinLevel") {
      timeRemaining = startGameTime;
      score = 0;
      Debug.Log(GameObject.Find("Score"));
      scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();
      timeText = GameObject.Find("Time").GetComponent<TMP_Text>();
      timeUpText = GameObject.Find("TimeUp").GetComponent<TMP_Text>();
      timeUpObj = GameObject.Find("TimeUp");
      timeUpObj.SetActive(false);
      timeAddedAnim = GameObject.Find("5 Seconds Added").GetComponent<Animator>();
 
    }
  }

  private void Start() {
    sceneController = FindObjectOfType<SceneController>();
    scoreText.text = "";
    timeText.text = "";
  }

  void Update() {
    if (gamePlaying) {
      // Raycast();
      if (SceneManager.GetActiveScene().name == "WheelyBinLevel") {
        if (timeRemaining > 0) {
          timeRemaining -= Time.deltaTime;
          updateTime(timeRemaining);
        } else {
          timeText.text = "0";
          Debug.Log("End Game");
          // Start Coroutine
          gamePlaying = false;
          //
          StartCoroutine(ShowTimeIsUp());
        }
      }

      //Handle Quit game 
      if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

  }

    IEnumerator ShowTimeIsUp()
    {
       timeUpObj.SetActive(true);
       EventManager.TriggerEvent(AudioEventName.PlayTimeIsUp);
        yield return new WaitForSeconds(3); 
        sceneController.LoadGameOver();   
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

  public void EatFood(int score = 50, float time = 5) { 
    timeRemaining += time;
    updateScore(score);
    EventManager.TriggerEvent(AudioEventName.PlayDing);
    timeAddedAnim.SetTrigger("Active");
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