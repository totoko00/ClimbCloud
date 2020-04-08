using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;　//LoadSceneを使うため宣言

public class ClearDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // LoadSceneは引数に与えたシーン名のシーンをロードするメソッド
            SceneManager.LoadScene("GameScene");
        }
        
    }
}
