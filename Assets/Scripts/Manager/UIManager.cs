using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText != null)
        {
            Debug.Log("Restart Text is not null");
        }
        if (scoreText != null)
        {
            Debug.Log("Score Text is not null");
        }

        restartText.gameObject.SetActive(false);
    }
    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();        
    }
}
