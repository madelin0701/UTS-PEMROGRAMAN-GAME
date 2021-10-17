using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] float kekuatanLoncat;
    [SerializeField] AudioClip suaraLoncat;
    [SerializeField] AudioClip suaraNabrak;
    [SerializeField] AudioClip suaraPoint;
    
    Rigidbody2D myRigidbody;
    AudioSource[] myAudioSources;
    bool loncat = false;

    void Awake(){

        myRigidbody = GetComponent<Rigidbody2D>();
        myAudioSources = GetComponents<AudioSource>();

    }

    void Update(){

        if(Input.GetKeyDown (KeyCode.Space) && !GameManager.instance.gameOver)
            loncat = true;

    }

    void FixedUpdate(){

        if (loncat) {

            Loncat();
            loncat = false;

        }

    }

    void OnTriggerEnter2D(Collider2D col){
        if(GameManager.instance.gameOver)
            return;
        else if(col.CompareTag("Pipe")){
            //kita harus jatuh ke tanah
            GameManager.instance.gameOver = true;
            MainkanSuara(suaraNabrak,0);

        }
        else if(col.CompareTag("Point")){
            //dapat point
            GameManager.instance.point++;
            MainkanSuara(suaraPoint,1);
            UIManager.instance.UpdateScore();

        }

    }

    void Loncat(){

        Vector3 velocity = myRigidbody.velocity;
        velocity.y = kekuatanLoncat;
        myRigidbody.velocity = velocity;
        MainkanSuara(suaraLoncat,0);

    }

    void MainkanSuara(AudioClip _suaraYangAkanDimainkan, int _audiosourceID){

        myAudioSources[_audiosourceID].clip = _suaraYangAkanDimainkan;
        myAudioSources[_audiosourceID].Play ();

    }


}