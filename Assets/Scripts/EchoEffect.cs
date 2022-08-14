using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    public float startTimeBetweenSpawns;
    public GameObject echo;
    public Player player;
    
    private float _timeBetweenSpawns;

    private void Update()
    {
        if(!player.isMove) return;
        if (_timeBetweenSpawns <= 0)
        {
            Instantiate(echo, transform.position, Quaternion.identity);
            _timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            _timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
