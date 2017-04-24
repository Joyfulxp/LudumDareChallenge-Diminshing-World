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
            case 301:
                {
                    SceneManager.LoadScene("BossHorizontal");
                    break;
                }
            case 302:
                {
                    SceneManager.LoadScene("BossVertical");
                    break;
                }
            case 303:
                {
                    SceneManager.LoadScene("End");
                    break;
                }
            case 304:
                { if (player.GetComponent<BasicParams>().VerticalDefeated)
                    {
                        SceneManager.LoadScene("End");
                        break;
                    }
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
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = false;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().shrinkingScale = new Vector3(1, 1, 1);
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
            player.GetComponent<BasicParams>().Seeds = 5;
            //player.transform.position = new Vector3(0, 0, 0);
        }
        if (SceneManager.GetActiveScene().name == "Shelter")
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = false;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().shrinkingScale = new Vector3(1, 1, 1);
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale = new Vector3(0.5f, 1, 1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
            player.GetComponent<BasicParams>().Seeds = 5;
            player.transform.position = new Vector3(0, 0, 0);
        }
        if (SceneManager.GetActiveScene().name.Contains("Level"))
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = true;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().h_Speed = 7;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().v_Speed = 7;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale=new Vector3(1,1,1);
            Debug.Log("reset!");
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
        }
        if (SceneManager.GetActiveScene().name == "BossHorizontal")
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = true;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().h_Speed =1.25f;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().v_Speed = 1.25f;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().shrinkingScale = new Vector3(1, 1, 1);
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale = new Vector3(1f, 1, 1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
            player.GetComponent<BasicParams>().Seeds = 5;
            player.transform.position = new Vector3(0, 0, 0);
            if(player.GetComponent<BasicParams>().HorizonDefeated==true)
            {
                GameObject.FindGameObjectWithTag("Enemy").transform.parent.gameObject.SetActive(false);
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("board (16)").SetActive(false);
                //GameObject.Find("doorGreen").SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().name == "BossVertical")
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().isShrinking = true;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().h_Speed = 1.25f;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().v_Speed = 1.25f;
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().shrinkingScale = new Vector3(1, 1, 1);
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<Transform>().localScale = new Vector3(1f, 1, 1);
            GetComponent<ChangeCameraAspectRatio>().ChangeRatio();
            player.GetComponent<BasicParams>().Seeds = 5;
            player.transform.position = new Vector3(0, 0, 0);
            if (player.GetComponent<BasicParams>().VerticalDefeated == true)
            {
                GameObject.FindGameObjectWithTag("Enemy").transform.parent.gameObject.SetActive(false);
                GameObject.Find("Canvas").SetActive(false);
                GameObject.Find("board (16)").SetActive(false);
                //GameObject.FindGameObjectWithTag("Door").SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().name == "End")
        {
            GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            mainCamera.GetComponent<Camera>().aspect=1.6f;
            Screen.SetResolution(800, 500, false);
            Destroy(GameObject.FindGameObjectWithTag("Border"));
            Destroy(player);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(this.gameObject, 2f);
                SceneManager.LoadScene("Main");
            }
        }
        if(player.GetComponent<BasicParams>().HorizonDefeated)
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().horizontalScale = 0;
        }
        if (player.GetComponent<BasicParams>().VerticalDefeated)
        {
            GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>().verticalScale = 0;
        }

        //check every level
        player.GetComponent<BasicParams>().UseSeed();
        ShrinkingBorders skb = GetComponent<GMDontDestroyOnLoad>().border.GetComponent<ShrinkingBorders>();
        skb.shrinkingScale += new Vector3(0.4f, 0.4f,0);
        if(skb.shrinkingScale.x>1.0)
        {
            skb.shrinkingScale /= skb.shrinkingScale.x/1f;
        }
        if(!player.GetComponent<BasicParams>().avatarChanged&& player.GetComponent<BasicParams>().gemsCollected>6)
        {
            SpriteRenderer spr = player.GetComponent<SpriteRenderer>();
            spr.sprite = GetComponent<BasicParams>().substitute;
            player.GetComponent<BasicParams>().avatarChanged = true;
        }
    }
}
