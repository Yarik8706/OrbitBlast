using System;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameController.AddScore();
        Destroy(gameObject);
    }
}