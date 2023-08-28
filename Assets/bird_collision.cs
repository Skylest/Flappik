using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bird_collision : MonoBehaviour
{
    public menu_controller menuController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ќбработка столкновени€ с преп€тствием или землей
        menuController.isDead();
    }
}
