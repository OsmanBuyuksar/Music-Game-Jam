using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneUI : MonoBehaviour {

    public Image gameEndMenu;

	// Use this for initialization
	void Start () {
        gameEndMenu.gameObject.SetActive(false);
	}
	void Awake()
    {
        gameEndMenu.gameObject.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
	
	}
    public void NextLevel()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i + 1);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        int i = Application.loadedLevel;
        Application.LoadLevel(i);
        Time.timeScale = 1;
    }
}
