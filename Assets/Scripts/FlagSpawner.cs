using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagSpawner : MonoBehaviour {

    [SerializeField] GameObject flag;

    public void RespwanFlag()
    {
        Instantiate(flag);
    }
}
