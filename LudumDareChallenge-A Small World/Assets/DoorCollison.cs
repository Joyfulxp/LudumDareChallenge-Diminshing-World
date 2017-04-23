using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollison : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BasicParams>().atDoor = true;
            collision.GetComponent<BasicParams>().doorNum = GetComponent<DoorParams>().DoorNum;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<BasicParams>().atDoor = false;
            collision.GetComponent<BasicParams>().doorNum = 0;
        }
    }
}
