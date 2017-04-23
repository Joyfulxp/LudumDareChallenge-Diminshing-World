using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChangeResolution : MonoBehaviour {

    public int width = 1024;
    public int height = 768;
    public float time;
    public float interval = 1f;
    //[DllImport("user32.dll")]
    //public static extern bool SetWindowPos(int x, int y, int Width, int Height, uint flags);
    // Use this for initialization
    void Start () {

        //Screen.SetResolution(505,621, false);
	}
	
	// Update is called once per frame
	void Update () {
		if(time+interval<Time.time)
        {
            time = Time.time;
            width -= 10;
            height -= 10;
            Screen.SetResolution(width, height, false);
        }
	}
}
