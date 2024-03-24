using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BgMover : MonoBehaviour

{
    [SerializeField]
    private float end_x, creat_x, speed;
    [SerializeField]
    private GameObject[] bgs = new GameObject[4];
    [SerializeField]
    private Queue<GameObject> queue_bgs = new Queue<GameObject>();
    
    private bool _isDead = false;
    private bool _isStart = false;
    public GameController menuController;
    private float[] bg_start_pos = { 9f, 32.6f, 56.2f, 79.8f };
    
    // Start is called before the first frame update
    void Start()
    {
        menuController.isDeadEvent += isDeadTriger;
        menuController.restartEvent += Restart;
        menuController.startEvent += isStartTriger;
        for (int i = 0; i < bgs.Length; i++)
        {
            queue_bgs.Enqueue(bgs[i]);
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

        for (int i = 0; i < bgs.Length; i++)
        {
            // Получаем текущую позицию объекта
            Vector2 currentPosition = bgs[i].transform.position;

            // Вычисляем новую позицию объекта с учетом движения влево
            Vector2 newPosition = new Vector2(currentPosition.x - (speed * Time.deltaTime), currentPosition.y);

            // Применяем новую позицию к объекту
            bgs[i].transform.position = newPosition;
        }
       
        if (queue_bgs.First().transform.position.x <= end_x)
        {
            Vector2 newPosition = new Vector2(creat_x, -0.92f);
            queue_bgs.First().transform.position = newPosition;
            queue_bgs.Enqueue(queue_bgs.First());
            queue_bgs.Dequeue();
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
        for (int i = 0; i < bgs.Length; i++)
        {
            Vector2 newPosition = new Vector2(bg_start_pos[i], -0.92f);

            // Применяем новую позицию к объекту
            bgs[i].transform.position = newPosition;
            queue_bgs.Dequeue();
            queue_bgs.Enqueue(bgs[i]);
        }
        
        _isDead = false;
    }
}
