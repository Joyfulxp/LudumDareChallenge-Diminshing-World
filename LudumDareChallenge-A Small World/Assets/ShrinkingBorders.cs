using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrinkingBorders : MonoBehaviour {

    public float horizontalScale=0.0001f;
    public float verticalScale=0.0001f;
    public float h_Speed;
    public float v_Speed;
    public Vector3 shrinkingScale;
    public bool isShrinking;
    public List<GameObject> doors;

    // Use this for initialization
    void Start () {
        shrinkingScale = new Vector3(1, 1, 1);
        h_Speed = 7;
        v_Speed = 7;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isShrinking)
        {
            shrinkingScale.x -= horizontalScale * h_Speed;
            shrinkingScale.y -= verticalScale * v_Speed;
            transform.localScale = shrinkingScale;
        }
        doors.Remove(null);
        if(doors.Count==0)//transform.localScale.x<0.08f||transform.localScale.y<0.08f)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<BasicParams>().Seeds -= 1;
            player.transform.position = new Vector3(1, 1, 1);
            SceneManager.LoadScene("Shelter");
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Obstacles" || collision.tag == "Door"|| collision.tag == "Gem"||collision.tag=="Enemy"||collision.tag=="BossRoom")
        {
            Debug.Log("triggered");

            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Background";
            collision.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Obstacles"||collision.tag=="Door"||collision.tag=="Enemy")
        {
            Destroy(collision.gameObject);
        }
        if(collision.tag=="Gem")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.5f,0.5f,0.2f);
            collision.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            collision.GetComponent<SpriteRenderer>().sortingOrder = 1;
            
        }
    }

}
