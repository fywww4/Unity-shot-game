using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText; // UI文字顯示分數
    public static int currentScore = 0;

    void Awake()
    {
        // 單例模式，確保只有一個計分管理器
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreDisplay();
        Debug.Log("目前分數: " + currentScore);
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }

    public static void ResetScore()
    {
        currentScore = 0;
        if (instance != null)
        {
            instance.UpdateScoreDisplay();
        }
    }
}