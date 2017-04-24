using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    public levelGems[] gems; 

    //param for tutorial&Shelter

    //param for 1-1

    //param for 1-2

    //param for horizontal

    //param for Vertical

    //param for DeadLine 


    // Use this for initialization
    void Awake () {
        gems = new levelGems[5];
        gems[0] = new levelGems(3);//shelter
        gems[1] = new levelGems(5);//1-1
        gems[2] = new levelGems(4);//1-2
        gems[3] = new levelGems(1);//horizontal
        gems[4] = new levelGems(1);//vertical
        for (int i = 0; i < 3; i++)
        { gems[0].gemList[i] = true; }
        for (int i = 0; i < 5; i++)
        { gems[1].gemList[i] = true; }
        for (int i = 0; i < 4; i++)
        { gems[2].gemList[i] = true; }
        gems[3].gemList[0] = true; 
        gems[4].gemList[0] = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public class levelGems
    {
        public bool[] gemList;
        public levelGems(int count)
        {
            gemList =new bool[count];
            for (int i = 0; i < count; i++)
            { gemList[i] = true; }
        }
    }

    public void fillList(ref bool[] list, int count)
    {
        //list = new bool[count];
        for(int i=0;i<count;i++)
        {
            list[i] = true;
        }
        return;
    }

    public void disableGem(int level,int ID)
    {
        gems[level].gemList[ID] = false;
    }
    private void OnLevelWasLoaded(int level)
    {
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
        foreach(GameObject i in gems)
        {
            GemGet gg = i.GetComponent<GemGet>();
            if (!ifEnabled(gg.level, gg.id))
            {
                i.SetActive(false);
            }
        }
    }
    public bool ifEnabled(int level, int ID)
    {
        return gems[level].gemList[ID];
    }

}
