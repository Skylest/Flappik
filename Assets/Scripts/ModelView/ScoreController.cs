using TMPro;
using UnityEngine;

/// <summary>
/// ����� ����������� ��������� ����� � �� ������������� � �����������
/// </summary>
public class ScoreController : MonoBehaviour
{
    /// <summary>
    /// ������ �� ��������� ������
    /// </summary>
    [SerializeField] private TextMeshProUGUI scoreText, recordText;

    /// <summary>
    /// ������ �� ���������� ����
    /// </summary>
    [SerializeField] private GameController gameController;

    /// <summary>
    /// ��������� ������
    /// </summary>
    private const string TextScoreBase = "Score: ", TextRecordBase = "Record: ";
    
    /// <summary>
    /// �������
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
    /// ���������� ����
    /// </summary>
    public void Restart()
    {
        scoreCounter = 0;
        scoreText.text = TextScoreBase + scoreCounter;
    }

    /// <summary>
    /// ��������
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
    /// ���������� �����
    /// </summary>
    public void AddScore()
    {
        scoreCounter++;
        scoreText.text = TextScoreBase + scoreCounter;
    }
}
