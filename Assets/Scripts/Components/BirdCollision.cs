using UnityEngine;

/// <summary>
/// Класс обрабатывающий взаимодействие птицы с другими объектами
/// </summary>
public class BirdCollision : MonoBehaviour
{
    /// <summary>
    /// Ссылка на игровой контроллер
    /// </summary>
    [SerializeField] private GameController gameController;

    /// <summary>
    /// Ссылка на контроллер счета
    /// </summary>
    [SerializeField] private ScoreController scoreController;

    // Обработка столкновения с препятствием или землей
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        gameController.Dead();
    }

    //Обработка прохождения труб
    private void OnTriggerEnter2D(Collider2D colliderObject)
    {
        if (colliderObject.CompareTag("PointTriger"))
            scoreController.AddScore();
    }
}
