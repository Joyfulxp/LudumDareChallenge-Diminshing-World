using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Texture2D startButton;
    public GUIStyle sbStyle;
    void Start () {
        ;
	}
	void Update () {
		
	}

    private void OnGUI()
    {
        
        float sb_width = Screen.width * 0.15f;
        float sb_height = Screen.height * 0.05f;
        if(GUI.Button(new Rect(new Vector2(Screen.width * 0.5f - sb_width / 2, Screen.height * 0.7f - sb_height / 2), new Vector2(sb_width, sb_height)), startButton,sbStyle))
        {
            SceneManager.LoadScene("Tutorial");
        }

    }
}
