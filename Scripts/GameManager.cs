using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int highScore = 0;
    private float startTime;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI finalTimeText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //allows for highscore and score displays plus saving the info for the start/end screen and replays

    void Start()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore;
        }
        
        startTime = Time.time;
        
    }
    public void AddScore (int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
        PlayerPrefs.SetInt("Score", score);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + score;
        }
    }
    void Update()
    {
        //allows for ingame timer
        float ingameTime = Time.time - startTime;
        PlayerPrefs.SetFloat("WinTime", ingameTime);
        finalTimeText.text = "Time: " + ingameTime.ToString("F2") + "secs";

    }
}
