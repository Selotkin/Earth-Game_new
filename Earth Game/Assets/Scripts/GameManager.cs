using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private Text endGameText;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private GameObject buttons;

	private bool gameOver = false;
	private PlayerController playerController;
	private float timeSinceGameStarted = 0;


	public bool GameOver {
		get {return gameOver;}
	}
	void Awake(){
		if (instance == null) {
			instance = this;
		}
		else if(instance != this){
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		playerController = player.GetComponent<PlayerController> ();
		endGameText.enabled = false;
		buttons.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerController.PlayerIsDead) {
			gameOver = true;
			endGameText.enabled = true;
			scoreText.enabled = false;
			float gameOverScore = timeSinceGameStarted;
			endGameText.text = "Your score: " + Mathf.Round (gameOverScore);
			buttons.SetActive (true);
		} else {
			timeSinceGameStarted += Time.deltaTime;
		}
		scoreText.text = "Score: " + Mathf.Round (timeSinceGameStarted);
	}

	public void LoadMenu()
	{	
		Debug.Log ("Brt click");
		SceneManager.LoadScene ("Menu");
	}

	public void ReloadScene()
	{
		Debug.Log ("Brt click");
		SceneManager.LoadScene ("Main");
	}
}
