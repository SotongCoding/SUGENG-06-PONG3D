using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int p1, p2, p3, p4;
    [SerializeField] int maxScore = 15;
    [SerializeField] List<GameObject> allPlayer;

    public bool isGameEnd { private set; get; } = false;

    [SerializeField] Text p1Score_text, p2Score_text, p3Score_text, p4Score_text;
    [SerializeField] Text maxScore_text;
    [SerializeField] GameObject gameoverUI;
    [SerializeField] Text playerWinText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        maxScore_text.text = "MAX COUNT\n" + maxScore.ToString();
    }
    public void IncreaseScore(int goalId, GameObject owner, GameObject wall)
    {
        switch (goalId)
        {
            case 1:
                p1++;
                p1Score_text.text = p1.ToString();
                CheckScore(p1, owner, wall);
                break;
            case 2:
                p2++;
                p2Score_text.text = p2.ToString();
                CheckScore(p2, owner, wall);
                break;
            case 3:
                p3++;
                p3Score_text.text = p3.ToString();
                CheckScore(p3, owner, wall);
                break;
            case 4:
                p4++;
                p4Score_text.text = p4.ToString();
                CheckScore(p4, owner, wall);
                break;
        }

    }

    void CheckScore(int scoreInput, GameObject ownerObject, GameObject wall)
    {
        if (scoreInput >= maxScore)
        {
            ownerObject.SetActive(false);
            wall.GetComponent<BoxCollider>().isTrigger = false;
            allPlayer.Remove(ownerObject);

            if (allPlayer.Count == 1)
            {
                GameOver(allPlayer[0].name);
            }
        }
    }

    void GameOver(string objectName)
    {
        playerWinText.text = (objectName + "\nWIN");
        isGameEnd = true;
        Time.timeScale = 0;
        gameoverUI.SetActive(true);
        //SceneManager.LoadScene("MainMenu");
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
