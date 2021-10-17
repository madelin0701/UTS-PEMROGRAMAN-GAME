using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{

    float batasKiriKamera;
    float setLebar;

    void Start()
    {
        
        batasKiriKamera = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        setLebar = GetComponent<SpriteRenderer>().bounds.size.x / 2f;

    }


    void Update()
    {
        if(GameManager.instance.gameOver)
            return;
        //cek kalau ground sudah tidak terlihat di kamera
        if(transform.position.x <= batasKiriKamera - setLebar)
            //pindahkan ground ke kanan
            transform.Translate(Vector3.right * ((setLebar * 4f) - 0.04f));


        //gerakkan si ground ke kiri
        transform.Translate(Vector3.left * GameManager.instance.kecepatan * Time.deltaTime);

    }
}
