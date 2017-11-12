using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbottabadLoader : MonoBehaviour {

	IEnumerator Start() {
		AsyncOperation async = SceneManager.LoadSceneAsync("Abottabad");
		yield return async;
		Debug.Log("Loading complete");
	}
}