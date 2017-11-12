using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class Pause : MonoBehaviour {

	public Canvas PauseMenu;
	// Use this for initialization
	private bool NV = false ;

	void Start () {
		Camera.main.GetComponent<ColorCorrectionCurves> ().enabled = NV;
		PauseMenu.GetComponent <Canvas>().enabled = false;

	}

	public void GamePause(){
		PauseMenu.GetComponent <Canvas>().enabled = true;
		Time.timeScale = 0;
	}

	public void Resume(){
		PauseMenu.GetComponent <Canvas>().enabled = false;
		Time.timeScale = 1;
	}

	public void Quit(){
		Time.timeScale = 1;
		SceneManager.LoadScene ("Titlemenu");
	}

	public void NightVision(){
		NV = !NV;
		Camera.main.GetComponent<ColorCorrectionCurves>().enabled = NV;

	}
}
