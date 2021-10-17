using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float batasKiriKamera;
    float batasKananKamera;
    float setLebar;

    void Start()
    {
        
        batasKiriKamera = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect;
        batasKananKamera = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
        setLebar = GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2f;
        transform.position = ((Vector3.right * transform.position.x) + (Vector3.up * Random.Range(GameManager.instance.minTinggiPipe,GameManager.instance.maxTinggiPipe)));

    }


    void Update()
    {
        if(GameManager.instance.gameOver)
            return;
        //cek kalau pipe sudah tidak terlihat di kamera
        if(transform.position.x <= batasKiriKamera - setLebar)
            //pindahkan pipe ke kanan
            transform.position = ((Vector3.right * (batasKananKamera + (setLebar * 2f))) + (Vector3.up * Random.Range(GameManager.instance.minTinggiPipe,GameManager.instance.maxTinggiPipe)));


        //gerakkan si pipe ke kiri
        transform.Translate(Vector3.left * GameManager.instance.kecepatan * Time.deltaTime);

    }
}
