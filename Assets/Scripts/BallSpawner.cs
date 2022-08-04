using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] Transform[] shootLocation;
    public Transform centerArea;

    [SerializeField] BallControl ballPrefab;
    Queue<BallControl> storedBall = new Queue<BallControl>();

    int currentBallOnArena = 0;
    [SerializeField] int maxBallOnArena = 5;

    private void Start()
    {
        InvokeRepeating("GenerateBall", 5, 5);
    }

    public void GenerateBall()
    {
        if(ScoreManager.Instance.isGameEnd) return;
        
        if (currentBallOnArena < maxBallOnArena)
        {
            BallControl createdBall;
            if (storedBall.Count <= 0)
            {
                createdBall = Instantiate(ballPrefab);
                createdBall.Initial(this);
            }
            else
            {
                createdBall = storedBall.Dequeue();
            }
            createdBall.gameObject.SetActive(true);
            createdBall.transform.position = GetSpawnPos().position;
            currentBallOnArena++;
            createdBall.ThrowBall();

        }

    }
    public void StoreBall(BallControl ball)
    {
        storedBall.Enqueue(ball);
        currentBallOnArena--;
    }
    Transform GetSpawnPos()
    {
        return shootLocation[Random.Range(0, shootLocation.Length)];
    }
}
