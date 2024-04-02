using TMPro;
using UnityEngine;

/// <summary>
/// Класс управляющий подсчетом очков и их визуализацией и сохранением
/// </summary>
public class ScoreController : MonoBehaviour
{
    /// <summary>
    /// Ссылка на текстовые объект
    /// </summary>
    [SerializeField] private TextMeshProUGUI scoreText, recordText;

    /// <summary>
    /// Ссылка на контроллер игры
    /// </summary>
    [SerializeField] private GameController gameController;

    /// <summary>
    /// Константа текста
    /// </summary>
    private const string TextScoreBase = "Score: ", TextRecordBase = "Record: ";
    
    /// <summary>
    /// Счетчик
    /// </summary>
    private int scoreCounter = 0, recordSaved = 0;

    private void Start()
    {
        gameController.OnDead += Dead;
        gameController.OnRestart += Restart;

        recordSaved = PlayerPrefs.GetInt("recordSaved", 0);
        recordText.text = TextRecordBase + recordSaved;
    }

    /// <summary>
    /// Перезапуск игры
    /// </summary>
    public void Restart()
    {
        scoreCounter = 0;
        scoreText.text = TextScoreBase + scoreCounter;
    }

    /// <summary>
    /// Проиграш
    /// </summary>
    public void Dead()
    {
        recordSaved = PlayerPrefs.GetInt("recordSaved", 0);
        
        if (scoreCounter > recordSaved)
        {
            PlayerPrefs.SetInt("recordSaved", scoreCounter);
            recordText.text = TextRecordBase + scoreCounter;
        }
    }

    /// <summary>
    /// Добавление счета
    /// </summary>
    public void AddScore()
    {
        scoreCounter++;
        scoreText.text = TextScoreBase + scoreCounter;
    }
}
