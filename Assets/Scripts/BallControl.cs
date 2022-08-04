using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Vector3 speed;
    [SerializeField] Rigidbody rigid;
    BallSpawner spawner;

    public PaddleControl lastTouchPaddle { private set; get; }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        ThrowBall();
    }
    internal void ResetPos()
    {
        gameObject.SetActive(false);
        rigid.velocity = Vector3.zero;
        spawner.StoreBall(this);
    }

    public void ThrowBall()
    {
        if (ScoreManager.Instance.isGameEnd) return;
        speed = (spawner.centerArea.position + new Vector3(Random.Range(-2, 3), 0, Random.Range(-2, 3)))
         - transform.position;

        rigid.velocity = speed.normalized * 10;

        Debug.Log("Ball Speed : " + rigid.velocity);
    }


    internal void IncreaseSpeed(float multipleSpeed)
    {
        rigid.velocity *= Mathf.Clamp(multipleSpeed, 1, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("paddle"))
        {
            lastTouchPaddle = other.gameObject.GetComponent<PaddleControl>();
        }
    }

    internal void Initial(BallSpawner ballSpawner)
    {
        spawner = ballSpawner;
    }
}
