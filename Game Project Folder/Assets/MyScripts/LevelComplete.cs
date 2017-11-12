using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

	public Canvas LevelCompleteMenu;
	public int leftEnemies;
	public int nextLevel;

	// Use this for initialization
	void Start () {
		LevelCompleteMenu = LevelCompleteMenu.GetComponent<Canvas>();
		LevelCompleteMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (leftEnemies == 0) {
			LevelCompleteMenu.enabled = true;
		}
		
	}

	public void EnemyDestroyed(){
		leftEnemies -= 1;
	}

	public void LoadNext(){
		SceneManager.LoadScene (nextLevel);
	}

	public void MainMenu(){
		SceneManager.LoadScene ("Titlemenu");
	}
}
