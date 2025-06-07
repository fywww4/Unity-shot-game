using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText; // UI��r��ܤ���
    public static int currentScore = 0;

    void Awake()
    {
        // ��ҼҦ��A�T�O�u���@�ӭp���޲z��
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
        Debug.Log("�ثe����: " + currentScore);
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