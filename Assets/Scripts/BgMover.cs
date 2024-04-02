using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BgMover : MonoBehaviour
{
    [SerializeField] private float endX, creatX, speed;

    [SerializeField] private GameObject[] backgroundsObjects = new GameObject[4];

    [SerializeField] private Queue<GameObject> backgroundsQueue = new Queue<GameObject>();

    [SerializeField] private GameController gameController;

    private readonly float creatY = -0.92f;

    private readonly float[] BgStartPos = { 9f, 32.6f, 56.2f, 79.8f };

    // Start is called before the first frame update
    void Start()
    {
        gameController.OnRestart += Restart;

        for (int i = 0; i < backgroundsObjects.Length; i++)
            backgroundsQueue.Enqueue(backgroundsObjects[i]);
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalParams.isDead || !GlobalParams.isStart)
            return;

        for (int i = 0; i < backgroundsObjects.Length; i++)
        {
            // Получаем текущую позицию объекта
            Vector2 currentPosition = backgroundsObjects[i].transform.position;

            // Вычисляем новую позицию объекта с учетом движения влево
            Vector2 newPosition = new Vector2(currentPosition.x - (speed * Time.deltaTime), currentPosition.y);

            // Применяем новую позицию к объекту
            backgroundsObjects[i].transform.position = newPosition;
        }

        if (backgroundsQueue.First().transform.position.x <= endX)
        {
            Vector2 newPosition = new Vector2(creatX, creatY);
            backgroundsQueue.First().transform.position = newPosition;
            backgroundsQueue.Enqueue(backgroundsQueue.First());
            backgroundsQueue.Dequeue();
        }
    }

    private void Restart()
    {
        for (int i = 0; i < backgroundsObjects.Length; i++)
        {
            Vector2 newPosition = new Vector2(BgStartPos[i], creatY);

            // Применяем новую позицию к объекту
            backgroundsObjects[i].transform.position = newPosition;
            backgroundsQueue.Dequeue();
            backgroundsQueue.Enqueue(backgroundsObjects[i]);
        }
    }
}
