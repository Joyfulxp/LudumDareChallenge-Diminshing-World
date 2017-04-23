using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetInDoor : MonoBehaviour {

    public int doorNum;
    GameObject player;
	// Use this for initialization
	void Awake () {
        player = GetComponent<GMDontDestroyOnLoad>().player;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void getInDoor(int doorNum)
    {
        switch (doorNum)
        {
            case 201:
                {
                    SceneManager.LoadScene("Shelter");
                    break;
                }
            case 1:
                {
                    SceneManager.LoadScene("Level1-1");
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene("Level1-2");
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene("Level1-3");
                    break;
                }

            default: { break; }
        }
        //clear all params
        player.GetComponent<BasicParams>().atDoor = false;
        player.GetComponent<Movement>().canJump = false;

    }
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "Tutorial"|| SceneManager.GetActiveScene().name == "Shelter")
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = false;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().shrinkingScale = new Vector3(1, 1, 1);
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
            player.GetComponent<BasicParams>().Seeds = 5;
        }
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = true;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale=new Vector3(1,1,1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
        }
        if(true)
        {
            player.GetComponent<BasicParams>().UseSeed();
            ShrinkingBorders skb = GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>();
            skb.shrinkingScale += new Vector3(0.4f, 0.4f,0);
            if(skb.shrinkingScale.x>1.0)
            {
                skb.shrinkingScale /= skb.shrinkingScale.x/1f;
            }
        }
    }
}
