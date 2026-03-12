using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalTimeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //uses info from the level to display highscore, score and timer.
        if (PlayerPrefs.HasKey("HighScore"))
        {
            
            highScoreText.text = "highscore: " + PlayerPrefs.GetInt("HighScore");
            
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            
            scoreText.text = "Score: " + PlayerPrefs.GetInt("Score") ;

        }
        float time = PlayerPrefs.GetFloat("WinTime", 0f);
        finalTimeText.text = "Time: " + time.ToString("F2") + "secs";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
