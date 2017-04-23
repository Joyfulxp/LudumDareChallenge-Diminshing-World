using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCondition1 : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            int sl = collision.GetComponent<BasicParams>().speedLevel;
            if(sl<1)
            {
                transform.parent.GetComponent<Text>().text = "Too high?\nGet that blue Gem!";
            }
            else if(sl==1)
            {
                transform.parent.GetComponent<Text>().text = "You did it!";

            }
            else
            {
                transform.parent.GetComponent<Text>().text = " ";
            }
        }
    }
}
