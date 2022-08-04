using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    [SerializeField] List<GameObject> avaiablePowerUps;
    [SerializeField] Vector2 minArea, maxArea;
    [SerializeField] int limitSpawnAmount = 2;
    int currentSpawn = 0;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InvokeRepeating("SpawnPowerUps", 5, 2f);
    }

    public void SpawnPowerUps()
    {
        if (currentSpawn >= limitSpawnAmount) return;
        var spawnedObject = Instantiate(avaiablePowerUps[Random.Range(0, avaiablePowerUps.Count)]);
        spawnedObject.transform.position = new Vector2(
            Random.Range(minArea.x, maxArea.x),
            Random.Range(minArea.y, maxArea.y));

        currentSpawn++;
    }
    public void ReduceSpawnLimit()
    {
        currentSpawn--;
    }
}
