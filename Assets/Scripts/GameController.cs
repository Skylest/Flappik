using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public delegate void isDeadDelegate();
    public event isDeadDelegate isDeadEvent;

    public delegate void restartDelegate();
    public event restartDelegate restartEvent;

    public delegate void startDelegate();
    public event startDelegate startEvent;

    public Text text_start, text_score, text_restart, text_record;

    private bool _isDead = false;
    private bool _isStart = false;

    public void isDead()
    {
        if (isDeadEvent != null)
        {
            isDeadEvent();
            _isDead = true;
            text_restart.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    public void restart()
    {
        if (restartEvent != null)
        {
            restartEvent();
            _isDead = false;
            text_restart.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    public void start()
    {
        if (startEvent != null)
        {
            startEvent();
            _isStart = true;
            text_start.GetComponent<CanvasGroup>().alpha = 0;
            text_score.GetComponent<CanvasGroup>().alpha = 1;
            text_record.GetComponent<CanvasGroup>().alpha = 1;
        }        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDead)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                restart();
            }
        }

        if (!_isStart)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                start();
            }
        }
    }
}
