﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_PaddleSpeedUp : MonoBehaviour
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
            var paddle = other.GetComponent<BallControl>().lastTouchPaddle;
            if(paddle !=null) paddle.IncreaseSpeed(2f);
            
            DestroySelf();
        }
    }
}
