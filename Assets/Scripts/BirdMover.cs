using UnityEngine;

/// <summary>
/// Класс реализовываюищий управление птицей
/// </summary>
public class BirdMover : MonoBehaviour
{
    /// <summary>
    /// Ссылка на птицу
    /// </summary>
    [SerializeField] private GameObject bird;

    /// <summary>
    /// Ссылка на контроллер игры
    /// </summary>
    [SerializeField] private GameController gameController;

    private Rigidbody2D birdRigidbody;

    /// <summary>
    /// Высота при которой вызывается прижок для птицы в анимации
    /// </summary>
    private const float AnimJumpHeight = 0f;

    /// <summary>
    /// Сила прыжка птицы
    /// </summary>
    private const float JumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        gameController.OnDead += Dead;
        gameController.OnRestart += Restart;
        birdRigidbody = bird.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalParams.isDead)
            return;

        if (!GlobalParams.isStart)
        {
            MenuAnimation();
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Применяем силу прыжка к птице
            Jump();
        }
    }

    /// <summary>
    /// Анимация постоянного прыжка в меню
    /// </summary>
    private void MenuAnimation()
    {
        // Проверка, достиг ли объект определенной высоты для взлета
        if (bird.transform.position.y <= AnimJumpHeight)
            Jump();
    }

    /// <summary>
    /// Рестарт игры
    /// </summary>
    private void Restart()
    {
        birdRigidbody.velocity = Vector2.zero;
        Vector2 newPosition = new Vector2(-1.67f, 0.02f);
        bird.transform.position = newPosition; // Применяем новую позицию к объекту
        birdRigidbody.angularVelocity = 0;
        bird.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        bird.GetComponent<Animator>().enabled = true;
    }

    /// <summary>
    /// Смерть птицы
    /// </summary>
    public void Dead()
    {
        bird.GetComponent<Animator>().enabled = false;
    }

    /// <summary>
    /// Взлет птицы
    /// </summary>
    private void Jump()
    {
        birdRigidbody.velocity = Vector2.up * JumpForce;
    }
}
