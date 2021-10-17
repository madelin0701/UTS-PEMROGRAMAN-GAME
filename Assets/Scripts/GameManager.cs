using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [Header("Game Mechanic")]
    public float kecepatan;
    public float maxTinggiPipe;
    public float minTinggiPipe;
    public bool gameOver = false;

    [Header("Game Stats")]
    public int point;


    void Awake(){

        if(instance == null)
            instance = this;
        else 
            Destroy (this);

    }

}
