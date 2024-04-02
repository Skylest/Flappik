using UnityEngine;

/// <summary>
/// ����� �������������� �������������� ����� � ������� ���������
/// </summary>
public class BirdCollision : MonoBehaviour
{
    /// <summary>
    /// ������ �� ������� ����������
    /// </summary>
    [SerializeField] private GameController gameController;

    /// <summary>
    /// ������ �� ���������� �����
    /// </summary>
    [SerializeField] private ScoreController scoreController;

    // ��������� ������������ � ������������ ��� ������
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        gameController.Dead();
    }

    //��������� ����������� ����
    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("PointTriger"))
            scoreController.AddScore();
    }
}
