using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour
{
    public float jumpForce = 5f;             // Сила прыжка птицы
    private bool _isDead = false;             // Флаг, указывающий, мертва ли птица
    private bool _isStart = false;
    public GameObject bird;
    public GameController menuController;
    private bool isFalling = true;
    private Rigidbody2D birdRigidbody;

    public float minHeight = 0f;

    // Start is called before the first frame update
    void Start()
    {
        menuController.isDeadEvent += isDeadTriger;
        menuController.restartEvent += Restart;
        menuController.startEvent += isStartTriger;
        birdRigidbody = bird.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
            return;
        if (!_isStart)
        {
            onStartAnim();
            return;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Применяем силу прыжка к птице
            birdRigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    private void onStartAnim()
    {
        if (isFalling)
        {        
            // Проверка, достиг ли объект определенной высоты для взлета
            if (bird.transform.position.y <= minHeight)
            {
                isFalling = false;
            }
        }
        else
        {
            birdRigidbody.velocity = Vector2.up * jumpForce;
            isFalling = true;
        }
    }

    private void Restart()
    {
        birdRigidbody.velocity = Vector2.zero;
        Vector2 newPosition = new Vector2(-1.67f, 0.02f);        
        bird.transform.position = newPosition; // Применяем новую позицию к объекту
        birdRigidbody.angularVelocity = 0;
        bird.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        bird.GetComponent<Animator>().enabled = true;
        _isDead = false;
    }

    public void isDeadTriger()
    {
        _isDead = true;
        bird.GetComponent<Animator>().enabled = false;
    }

    public void isStartTriger()
    {
        birdRigidbody.velocity = Vector2.up * jumpForce;
        _isStart = true;
    }

    
}
