using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public string playerName;
    public int score = 0;
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName){
            if (other.GetComponent<FlagPickUp>().hasFlag == true)
            {
                score++;
                print(other.name + " wins");
            }
        }
    }

    void Update()
    {
        if (score >= 3)
        {
            //LoadWinningScene
        }
    }
}
