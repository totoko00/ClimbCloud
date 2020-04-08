using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); //Rifidbody2Dのコンポーネントを読み込んで、rigid2Dに代入
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ジャンプする
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //左右移動
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤの速度　velocityってのは速度。Mathfは関数ここでx軸における速度の絶対値を取得している
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //スピード制限（値はどちらも正の数（絶対値を取得しているので））
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
            //transform.rightってのは1だけ右に移動する方向を示す。なので、左にするには負の値をかければいいということ（それをkeyで制御している）
        }

        // 動く方向に応じてキャラ絵を反転
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        //プレイヤーの速度に応じてアニメーション速度を変える
        this.animator.speed = speedx / 2.0f;
    }

    //ゴールに到着
    //OnTriggerEnter2Dは公式のメソッド。ここだと旗に対してだけTriggerのチェックを入れてるので、雲に触れても大丈夫
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }
}
