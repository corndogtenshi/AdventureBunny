using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.gameObject.GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }

    public void DecreaseScore(int change)
    {
        score -= change;
        scoreText.text = "Score: " + score;
    }
    public void IncreaseScore(int change)
    {
        score += change;
        scoreText.text = "Score: " + score;
    }
}
