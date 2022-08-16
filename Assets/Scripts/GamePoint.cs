using System;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
    public GameObject effect;
    [HideInInspector] public GameController gameController;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var vector3 = col.transform.position - transform.position;
        var newPosition = vector3.magnitude * vector3.normalized + transform.position;
        Instantiate(effect, 
            new Vector3(newPosition.x, newPosition.y, effect.transform.position.z), 
            Quaternion.identity);
        gameController.AddScore();
        Destroy(gameObject);
    }
}