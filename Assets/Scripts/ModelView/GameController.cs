using System;
using UnityEngine;

/// <summary>
/// ����� ����������� ��������� ����������� ���� � �� �������������
/// </summary>
public class GameController : MonoBehaviour
{ 
    // ������ �� CanvasGroup ���� ������� � ����
    [SerializeField] private CanvasGroup textStart, textScore, textRestart, textRecord;

    /// <summary>
    /// ����� ������ (���������)
    /// </summary>
    public event Action OnDead;

    /// <summary>
    /// ����� �������� ����
    /// </summary>
    public event Action OnRestart;

    /// <summary>
    /// ������ ����� (��������)
    /// </summary>
    public void Dead()
    {
        OnDead?.Invoke();
        GlobalParams.isDead = true;
        textRestart.alpha = 1;
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    public void RestartGame()
    {
        OnRestart?.Invoke();
        GlobalParams.isDead = false;
        textRestart.alpha = 0;
    }

    /// <summary>
    /// ������ ����� ����
    /// </summary>
    public void StartGame()
    {
        GlobalParams.isStart = true;
        textStart.alpha = 0;
        textScore.alpha = 1;
        textRecord.alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalParams.isDead)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
                RestartGame();

        if (!GlobalParams.isStart)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
                StartGame();
    }
}
