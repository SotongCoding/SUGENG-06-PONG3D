using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] KeyCode moveUp;
    [SerializeField] KeyCode moveDown;
    [SerializeField] bool alongZAxis = true;
    [SerializeField] float speed;

    float originalSpeed;
    Vector3 originalPaddlesize = new Vector3(0.5f, 2.5f, 1);

    WaitForSeconds buffLastingTime = new WaitForSeconds(5);

    private void Start()
    {
        //Some Comment Here
        originalSpeed = speed;

    }
    private void Update()
    {
        MovePaddle(GetInput());
    }

    Vector3 GetInput()
    {
        if (Input.GetKey(moveUp)) return alongZAxis ? Vector3.forward : Vector3.left;
        else if (Input.GetKey(moveDown)) return alongZAxis ? Vector3.back : Vector3.right;

        else return Vector3.zero;

    }
    void MovePaddle(Vector3 movementDir)
    {
        Debug.Log("Move Dir : " + movementDir);
        transform.Translate(movementDir * speed * Time.deltaTime);
        //     transform.position = new Vector2(transform.position.x,
        //     Mathf.Clamp(transform.position.y, -3.3f, 3.3f));
    }

    internal void IncreaseLenght(float lengthIncrease)
    {
        transform.localScale = new Vector3(transform.localScale.x,
        transform.localScale.y * lengthIncrease,
        transform.localScale.z);

        StopCoroutine(LengthBuff());
        StartCoroutine(LengthBuff());

        IEnumerator LengthBuff()
        {
            yield return buffLastingTime;
            transform.localScale = originalPaddlesize;
        }
    }

    internal void IncreaseSpeed(float speedIncrease)
    {
        speed *= speedIncrease;
        StopCoroutine(SpeedBuff());
        StartCoroutine(SpeedBuff());

        IEnumerator SpeedBuff()
        {
            yield return buffLastingTime;
            speed = originalSpeed;
        }
    }
}
