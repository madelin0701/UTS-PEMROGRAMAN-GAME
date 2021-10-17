using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;

    [SerializeField] Text pointText;

    void Awake(){

        if(instance == null)
            instance = this;
        else
            Destroy (gameObject);

    }

    public void UpdateScore(){

        pointText.text = GameManager.instance.point.ToString();
    }

}
