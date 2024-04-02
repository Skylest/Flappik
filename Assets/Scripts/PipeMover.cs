using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    [SerializeField] private float endX, creatX, speed;
    
    [SerializeField] private GameObject[] pipes = new GameObject[4]; 
    
    [SerializeField] private GameController gameController;

    private Queue<GameObject> queuePipes = new Queue<GameObject>();

    private readonly float yMax = -4f, yMin = -7.5f;
    
    private readonly float[] PipesStartPos = { 11f, 14f, 17f, 20f };

    // Start is called before the first frame update
    void Start()
    {
        gameController.OnRestart += Restart;
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalParams.isDead || !GlobalParams.isStart)
            return;

        foreach (var pipe in pipes)
        {
            Vector2 newPosition = new Vector2(pipe.transform.position.x - (speed * Time.deltaTime), pipe.transform.position.y);
            pipe.transform.position = newPosition;
        }

        if (queuePipes.Peek().transform.position.x <= endX)
        {
            Vector2 newPosition = new Vector2(creatX, Random.Range(yMin, yMax));
            queuePipes.Peek().transform.position = newPosition;
            queuePipes.Enqueue(queuePipes.Dequeue());
        }

    }

    /// <summary>
    /// Рестарт игры. Установка стартовых позиций труб
    /// </summary>
    private void Restart()
    {
        queuePipes.Clear();

        for (int i = 0; i < pipes.Length; i++)
        {
            Vector2 newPosition = new Vector2(PipesStartPos[i], Random.Range(yMin, yMax));
            pipes[i].transform.position = newPosition;
            queuePipes.Enqueue(pipes[i]);
        }
    }
}
