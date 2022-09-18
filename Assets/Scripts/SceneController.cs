using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	Scene currentSceneIndex;
	GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
		gameManager = FindObjectOfType<GameManager>();
		currentSceneIndex = SceneManager.GetActiveScene();
    }

	public void LoadGameStart(){
		Debug.Log("Loading Game Start");
		SceneManager.LoadScene(2);
	}

	public void LoadControls(){
		Debug.Log("Loading How to play");
		SceneManager.LoadScene("Controls");
	}


	public void LoadGameOver(){
		Debug.Log("Loading Game Over");
		SceneManager.LoadScene("Game Over");
	}

	public void LoadGameMenu(){
		Debug.Log("Loading Main Menu");
		SceneManager.LoadScene("Main Menu");
	}

	public void QuitGame() {
		#if UNITY_STANDALONE
			//Quit the application
			Application.Quit();
		#endif
	
			//If we are running in the editor
		#if UNITY_EDITOR
			//Stop playing the scene
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	


}
