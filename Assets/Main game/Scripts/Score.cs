using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public int maxScore = 1;
    public Text score;

    void Start()
    {
        score = GetComponent<Text>();
        score.fontSize = 14;
        score.fontStyle = FontStyle.Normal;
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Pontos: " + scoreValue;
        if (scoreValue == maxScore)
        {
            win();
        }
    }

    void win() {
        score.fontSize = 24;
        score.fontStyle = FontStyle.Bold;
        score.text = "Você venceu, Parabéns";
    }
}
