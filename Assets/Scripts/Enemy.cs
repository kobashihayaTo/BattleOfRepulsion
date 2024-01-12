using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public int scoreValue;  // これが敵を倒すと得られる点数になる
    private ScoreManager sm;
    //GameObject型を変数targetで宣言します。
    public GameObject target;

    [SerializeField] GameObject deathEffect;

    public Sprite skillbullet;
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    int flag = 0;
    int time = 0;
    int HP = 2;

    //移動速度
    float moveSpeed = 1.0f;

    void Start()
    {
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.transform.position,
            moveSpeed * Time.deltaTime
            );

        if (flag == 1)
        {
            time++;
            moveSpeed = 0.0f;
            if (time > 60)
            {
                // 自身を消す
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("skill"))
        {
            HP = -2;
        }

        if (other.gameObject.CompareTag("bullet"))
        {
            HP--;
            // 弾も消す
            Destroy(other.gameObject);
        }

        if (HP <= 0)
        {

            // 当たったのがプレイヤーの弾
            if (other.gameObject.CompareTag("bullet"))
            {
                Instantiate(deathEffect, this.transform.position, this.transform.rotation);

                // 自身を消す
                Destroy(gameObject);

                // 弾も消す
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("skill"))
            {
                Instantiate(deathEffect, this.transform.position, this.transform.rotation);
                sr.sprite = skillbullet;

                flag = 1;
            }
            // ★追加
            sm.AddScore(scoreValue);
        }
    }


}