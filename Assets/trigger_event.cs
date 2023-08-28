using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_event : MonoBehaviour
{
    public score_controller score_Controller;
    public GameObject trigger_target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(trigger_target))
        {
            score_Controller.score_Inc();
        }
    }
}
