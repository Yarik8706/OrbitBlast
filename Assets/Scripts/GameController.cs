using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public float mainCircleRotateSpeed;
    public Transform mainCircle;
    public Transform attackPoint;
    public GamePoint gamePoint;
    public Transform[] gamePointsSpawnPoint;
    public int score;
    public Text scoreText;
    
    [HideInInspector]public bool isStop;

    private void Start()
    {
        SpawnGamePoint();
    }

    private void Update()
    {
        if(isStop) return;
        mainCircle.Rotate(0, 0, Time.deltaTime * mainCircleRotateSpeed);
    }

    public void ContinueRotate()
    {
        isStop = false;
        mainCircleRotateSpeed *= -1;
    }

    private void SpawnGamePoint()
    {
        var randomPoint = gamePointsSpawnPoint[Random.Range(0, gamePointsSpawnPoint.Length)];
        Instantiate(gamePoint, randomPoint.position, Quaternion.identity).gameController = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "" + score;
        SpawnGamePoint();
    }
}
