using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの座標を調べる
        Vector3 playerPos = this.player.transform.position;
        //カメラのY座標に反映している。Y座標だけが変化するので、XとZにはカメラの元座標をそのまま代入
        //だからplayerPos.yは↑で調べた座標のyが入る
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
