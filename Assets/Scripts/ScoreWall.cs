using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    [SerializeField] int goalId;
    [SerializeField] GameObject ownerObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ScoreManager.Instance.IncreaseScore(goalId, ownerObject,this.gameObject);
            other.GetComponent<BallControl>().ResetPos();
        }
    }
}
