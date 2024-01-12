using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageReplace : MonoBehaviour
{
    // デフォルトの画像(爆発後の画像)
    public Sprite explodeImage;
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    void Start()
    {
        // SpriteのSpriteRendererコンポーネントを取得
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Playerタグがついたオブジェクトと衝突した時に処理
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Enemy_")
        {
            // デフォルトの画像を爆発後の画像に切り替える
            sr.sprite = explodeImage;
        }
    }
}
