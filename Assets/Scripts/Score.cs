using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Score : MonoBehaviour
{
    public static int scoreAmount;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
