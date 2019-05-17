using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    [SerializeField] FlagSpawner flagSpawner;
    [SerializeField] Score score;
    public string playerName;
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName){
            if (other.GetComponent<FlagPickUp>().hasFlag == true)
            {
                score.IncreaseScore();
                Transform flag = other.gameObject.transform.Find("Flag");
                if (flag == null)
                {
                    Destroy(other.gameObject.transform.Find("Flag(Clone)").gameObject);
                }
                else
                {
                    Destroy(flag.gameObject);
                }
                other.GetComponent<FlagPickUp>().hasFlag = false;
                flagSpawner.RespwanFlag();
            }
        }
    }

}
