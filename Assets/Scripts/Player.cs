using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Transform mainPoint;
    public Transform attackPoint;
    public GameController gameController;
    public AnimationCurve movementSpeedGraph = AnimationCurve.Linear(0, 0, 1f,  1f);
    
    [HideInInspector]public bool isMove;

    private void Start()
    {
        transform.position = mainPoint.position;
    }

    private void CheckClick()
    {
        if (Input.GetMouseButtonDown(0) && !isMove)
        {
            gameController.isStop = true;
            StartCoroutine(MoveTo(attackPoint.position, MoveBack));
        }
    }

    private void MoveBack()
    {
        StartCoroutine(
                            MoveTo(mainPoint.position, 
                                () => gameController.ContinueRotate()));
    }

    private void Update()
    {
        CheckClick();
    }

    private IEnumerator MoveTo(Vector3 target)
    {
        yield return null;
        var moveTime = 0f;
        var distance = Vector2.Distance(transform.position, target);
        var speed = distance / 10 * movementSpeed;
        isMove = true;
        while(transform.position != target && isMove)
        {
            moveTime += Time.deltaTime;
            var newPosition = Vector2.MoveTowards(
                transform.position, 
                target, 
                speed * Time.deltaTime * movementSpeedGraph.Evaluate(moveTime));
            transform.position = newPosition;
            yield return null;
        }
        isMove = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        isMove = false;
        MoveBack();
    }

    private IEnumerator MoveTo(Vector3 target, Action callback)
    {
        yield return MoveTo(target);
        callback.Invoke();
    }
}
