using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс реализовываюищий движение объектов в сторону
/// </summary>
public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float endX, creatX, speed;

    [SerializeField] private float yMax = -4f, yMin = -7.5f;

    [SerializeField] private GameObject[] objects = new GameObject[4];       

    [SerializeField] private float[] StartPos = { 11f, 14f, 17f, 20f };

    [SerializeField] private GameController gameController;

    private Queue<GameObject> queueObjects = new Queue<GameObject>();

    //private readonly float[] BgStartPos = { 9f, 32.6f, 56.2f, 79.8f };

    void Start()
    {
        gameController.OnRestart += Restart;
        Restart();
    }

    void Update()
    {
        if (GlobalParams.isDead || !GlobalParams.isStart)
            return;

        foreach (var pipe in objects)
        {
            Vector2 newPosition = new Vector2(pipe.transform.position.x - (speed * Time.deltaTime), pipe.transform.position.y);
            pipe.transform.position = newPosition;
        }

        if (queueObjects.Peek().transform.position.x <= endX)
        {
            Vector2 newPosition = new Vector2(creatX, Random.Range(yMin, yMax));
            queueObjects.Peek().transform.position = newPosition;
            queueObjects.Enqueue(queueObjects.Dequeue());
        }

    }

    /// <summary>
    /// Рестарт игры. Установка стартовых позиций
    /// </summary>
    private void Restart()
    {
        queueObjects.Clear();

        for (int i = 0; i < objects.Length; i++)
        {
            Vector2 newPosition = new Vector2(StartPos[i], Random.Range(yMin, yMax));
            objects[i].transform.position = newPosition;
            queueObjects.Enqueue(objects[i]);
        }
    }
}
