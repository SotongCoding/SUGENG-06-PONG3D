using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_BallSpeedUp : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DestroySelf", 5);
    }
    void DestroySelf()
    {
        Destroy(gameObject);
        PowerUpManager.Instance.ReduceSpawnLimit();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            other.GetComponent<BallControl>().IncreaseSpeed(1.3f);
            DestroySelf();
        }
    }
}
