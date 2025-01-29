using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public Text scoreText; // Assign a UI Text element in Unity Inspector

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreUI();

        if (score >= 50) // If BB8 reaches 50 points (5 fruits destroyed)
        {
            ShowWinMessage();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    void ShowWinMessage()
    {
        if (scoreText != null)
            scoreText.text = "You Won!"; // Replace score text with "You Won!"
    }
}
