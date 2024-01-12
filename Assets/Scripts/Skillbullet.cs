using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skillbullet : MonoBehaviour
{
    // デフォルトの画像(爆弾の画像)
    public Sprite defaultImage;
    // デフォルトの画像(爆発後の画像)
    public Sprite explodeImage;
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    bool Skillrender = PlayerMove.Skillrender;

    int timer = 0;
    int flag = 0;

    public float MoveSpeed = 20.0f;         // 移動値

    // Start is called before the first frame update
    void Start()
    {
        // SpriteのSpriteRendererコンポーネントを取得
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Skillrender == false){
            // 位置の更新
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        }
        if (Skillrender == true)
        {
            // 位置の更新
            transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
        }

        if (flag == 1)
        {
            sr.sprite = explodeImage;
            timer++;
            MoveSpeed = 0.0f;
        }
    }

    void OnBecameInvisible()
    {
        //Destroy(this.gameObject);
    }


    public void Flag()
    {
        flag = 1;
    }
}
