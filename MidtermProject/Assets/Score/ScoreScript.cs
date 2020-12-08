using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject door1, door2, door3;
    public static int scoreValue = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        door1 = GameObject.Find("door1");
        door2 = GameObject.Find("door2");
        door3 = GameObject.Find("door3");
        door1.gameObject.SetActive(true);
        door2.gameObject.SetActive(true);
        door3.gameObject.SetActive(true);
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Kills: " + scoreValue;
        if(scoreValue == 12){
            door3.gameObject.SetActive(false);
        }

        if(scoreValue == 30){
            door1.gameObject.SetActive(false);
            door2.gameObject.SetActive(false);
        }
    }
}
