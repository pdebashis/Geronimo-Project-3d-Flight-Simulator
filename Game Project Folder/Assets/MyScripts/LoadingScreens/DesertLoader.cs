using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesertLoader : MonoBehaviour {

	IEnumerator Start() {
		AsyncOperation async = SceneManager.LoadSceneAsync("Desert");
		yield return async;
		Debug.Log("Loading complete");
	}
}