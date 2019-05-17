using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    [SerializeField] int score = 0;
    [SerializeField] GameObject[] scoreFlags;
    public void IncreaseScore()
    {
        score++;
        scoreFlags[score-1].SetActive(true);
    }

    void Update()
    {
        if (score >= 3)
        {
        }
    }
}
