using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private Text score, record;

    private string text_score_base = "Score: ", text_record_base = "Record: ";
    private int score_cnt = 0;
    public GameController menuController;
    private int record_saved = 0;

    void Start()
    {
        menuController.isDeadEvent += isDeadTriger;
        menuController.restartEvent += Restart;
        record_saved = PlayerPrefs.GetInt("record_saved", 0);
        record.text = text_record_base + record_saved;
    }

    private void Restart()
    {
        score_cnt = 0;
        score.text = text_score_base + score_cnt;
    }

    public void isDeadTriger()
    {
        record_saved = PlayerPrefs.GetInt("record_saved", 0);
        if (score_cnt > record_saved)
        {
            PlayerPrefs.SetInt("record_saved", score_cnt);
            record.text = text_record_base + score_cnt;
        }
    }

    public void score_Inc()
    {
        score_cnt++;
        score.text = text_score_base + score_cnt;
    }
}
