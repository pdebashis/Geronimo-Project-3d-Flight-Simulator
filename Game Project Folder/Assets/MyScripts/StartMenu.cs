using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Canvas QUITMENU;
    public Button SYRIA;
    public Button AFGHAN;
    public Button TORABORA;
    public Button ABOTTABAD;
    public Button EXItTEXT;
	public Button Test;
    // Use this for initialization
    void Start()
    {
        QUITMENU = QUITMENU.GetComponent<Canvas>();
        SYRIA = SYRIA.GetComponent<Button>();
        AFGHAN = AFGHAN.GetComponent<Button>();
        TORABORA = TORABORA.GetComponent<Button>();
        ABOTTABAD = ABOTTABAD.GetComponent<Button>();
        EXItTEXT = EXItTEXT.GetComponent<Button>();
		Test = Test.GetComponent<Button> ();
		QUITMENU.enabled = false;
    }

    public void EXITPRESS()
    {
        QUITMENU.enabled = true;
        SYRIA.enabled = false;
        AFGHAN.enabled = false;
		Test.enabled = false;
        TORABORA.enabled = false;
        ABOTTABAD.enabled = false;
        EXItTEXT.enabled = false;
    }

    public void NOPRESS()
    {

        QUITMENU.enabled = false;
        SYRIA.enabled = true;
        AFGHAN.enabled = true;
		Test.enabled = true;
        TORABORA.enabled = true;
        ABOTTABAD.enabled = true;
        EXItTEXT.enabled = true;
    }

    // Update is called once per frame
    public void Syria()
    {
		SceneManager.LoadScene ("DesertLoading");
        
    }
    public void afghanistan()
    {
		SceneManager.LoadScene ("MountainLoading");
    }
    public void torabora()
    {
		SceneManager.LoadScene ("CaveLoading");
    }
    public void abottabad()
    {
		SceneManager.LoadScene ("AbottabadLoading");
    }
	public void test()
	{
		SceneManager.LoadScene ("testLoading");
	}
    public void EXITGAME()
    {
        Application.Quit();
    }
}