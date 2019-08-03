using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public TextMeshProUGUI textMesh;
    public TextMeshProUGUI highScoreUI;
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }

    
    void Update()
    {
        textMesh.text = score.ToString();
        highScoreUI.text = highScore.ToString();

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "scoreup")
        {
            score++;
        }
    }
}
