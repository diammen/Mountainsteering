using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour {

    [SerializeField] int score = 0;
    [SerializeField] GameObject[] scoreFlags;
    [SerializeField] string sceneName;

    public void IncreaseScore()
    {
        score++;
        scoreFlags[score-1].SetActive(true);
    }

    void Update()
    {
        if (score >= 3)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
