using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdCollision : MonoBehaviour
{
    public GameController menuController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������� ������������ � ������������ ��� ������
        menuController.isDead();
    }
}
