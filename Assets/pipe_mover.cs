using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class pipe_mover : MonoBehaviour

{
    [SerializeField]
    private float end_x, creat_x, speed;
    [SerializeField]
    private GameObject[] pipes = new GameObject[4];
    [SerializeField]
    private Queue<GameObject> queue_pipes = new Queue<GameObject>();
    
    private float y_max = -4f, y_min = -7.5f;
    private bool _isDead = false;
    private bool _isStart = false;
    public menu_controller menuController;
    private float[] pipe_start_pos = { 11f, 14f, 17f, 20f };
    
    // Start is called before the first frame update
    void Start()
    {
        menuController.isDeadEvent += isDeadTriger;
        menuController.restartEvent += Restart;
        menuController.startEvent += isStartTriger;
        for (int i = 0; i < pipes.Length; i++)
        {
            // Получаем текущую позицию объекта
            Vector2 currentPosition = pipes[i].transform.position;

            // Вычисляем новую позицию объекта с учетом движения влево
            Vector2 newPosition = new Vector2(currentPosition.x, Random.Range(y_min, y_max));

            // Применяем новую позицию к объекту
            pipes[i].transform.position = newPosition;
            queue_pipes.Enqueue(pipes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
        {
            return;
        }

        if (!_isStart)
        {
            return;
        }

        for (int i = 0; i < pipes.Length; i++)
        {
            // Получаем текущую позицию объекта
            Vector2 currentPosition = pipes[i].transform.position;

            // Вычисляем новую позицию объекта с учетом движения влево
            Vector2 newPosition = new Vector2(currentPosition.x - (speed * Time.deltaTime), currentPosition.y);

            // Применяем новую позицию к объекту
            pipes[i].transform.position = newPosition;
        }
       
        if (queue_pipes.First().transform.position.x <= end_x)
        {
            Vector2 newPosition = new Vector2(creat_x, Random.Range(y_min, y_max));
            queue_pipes.First().transform.position = newPosition;
            queue_pipes.Enqueue(queue_pipes.First());
            queue_pipes.Dequeue();
        }

    }

    public void isDeadTriger()
    {
        _isDead = true;
    }

    public void isStartTriger()
    {
        _isStart = true;
    }

    private void Restart()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            // Вычисляем новую позицию объекта с учетом движения влево
            Vector2 newPosition = new Vector2(pipe_start_pos[i], Random.Range(y_min, y_max));

            // Применяем новую позицию к объекту
            pipes[i].transform.position = newPosition;
            queue_pipes.Dequeue();
            queue_pipes.Enqueue(pipes[i]);
        }
        
        _isDead = false;
    }
}
