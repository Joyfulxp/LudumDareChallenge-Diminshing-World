using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraAspectRatio : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject levelBorder;
	// Use this for initialization
	void Start () {
        //ChangeRatio();
	}
	
	// Update is called once per frame
	void Update () {
		if(mainCamera==null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        if(levelBorder==null)
        {
            levelBorder = GameObject.FindGameObjectWithTag("LevelBorder");
        }
    }
    public void ChangeRatio()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        levelBorder = GameObject.FindGameObjectWithTag("LevelBorder");
        float cameraSize = (levelBorder.GetComponent<EdgeCollider2D>().points[0].x - levelBorder.GetComponent<EdgeCollider2D>().points[2].x) / (levelBorder.GetComponent<EdgeCollider2D>().points[2].y - levelBorder.GetComponent<EdgeCollider2D>().points[0].y);
        Screen.SetResolution(100 * (Mathf.CeilToInt(Mathf.Abs((levelBorder.GetComponent<EdgeCollider2D>().points[0].x - levelBorder.GetComponent<EdgeCollider2D>().points[2].x)))),100 * Mathf.CeilToInt(Mathf.Abs((levelBorder.GetComponent<EdgeCollider2D>().points[2].y - levelBorder.GetComponent<EdgeCollider2D>().points[0].y))), false);
        mainCamera.GetComponent<Camera>().aspect = cameraSize;
    }
}
