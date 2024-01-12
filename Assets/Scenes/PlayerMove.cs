using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float fMoveSpeed = 0.05f;     // 移動値
    //---------------------------
    //          追加
    public GameObject BulletObj;        // 弾のゲームオブジェクト
    public GameObject SkillObj;
    public SpriteRenderer renderer;
    //public GameObject ParticleEffect;   //パーティクル
    //---------------------------

    Vector3 bulletPoint;                // 弾の位置

    /// ---------------
    /// スペシャルアタックのタイマー
    public static int skillFlag = 0;
    public int TimerValue;
    private Text CoolTimer;
    /// ---------------

    public static int SkillintervalTimer = 0;
    public static int intervalFlag = 0;
    public static bool render = false;
    public static bool Skillrender = false;

    void Start()
    {
        bulletPoint = transform.Find("BulletPoint").localPosition;

        //---ここから追加----
        renderer = GetComponent<SpriteRenderer>();
        //---ここまで追加----

        skillFlag = 0;
        CoolTimer = GameObject.Find("CoolTimer").GetComponent<Text>();
        CoolTimer.text = "COOLTIMER:" + skillFlag;
    }
    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {
        skillFlag += amount;
        CoolTimer.text = "COOLTIMER:" + skillFlag;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        #region 
        //自機移動
        if (Input.GetKey("left") /*|| Input.GetAxis("Horizontal") < 0*/)
        {
            position.x -= fMoveSpeed;
        }
        else if((Input.GetKey("left")&&Input.GetKey("up")))//斜め左上
        {
            position.x -= fMoveSpeed ;
            position.y += fMoveSpeed ;
        }
        else if ((Input.GetKey("left") && Input.GetKey("down")))//斜め左下
        {
            position.x -= fMoveSpeed ;
            position.y -= fMoveSpeed;
        }

        if (Input.GetKey("right") /*|| Input.GetAxis("Horizontal") > 0*/)
        {
            position.x += fMoveSpeed;
        }
        else if ((Input.GetKey("right") && Input.GetKey("up")))//斜め左上
        {
            position.x += fMoveSpeed;
            position.y += fMoveSpeed+1;
        }
        else if ((Input.GetKey("right") && Input.GetKey("down")))//斜め左下
        {
            position.x += fMoveSpeed;
            position.y -= fMoveSpeed;
        }

        if (Input.GetKey("up") /*|| Input.GetAxis("Vertical") > 0*/)
        {
            position.y += fMoveSpeed;
            renderer.flipY = false;
            render = false;
            Skillrender = false;
        }
        if (Input.GetKey("down") /*|| Input.GetAxis("Vertical") < 0*/)
        {
            position.y -= fMoveSpeed;
            renderer.flipY = true;
            render = true;
            Skillrender = true;
        }
        transform.position = position;
        #endregion

        #region
        // 攻撃ボタンを押したとき
        if (Input.GetKeyDown(KeyCode.Space)/*|| Input.GetButtonDown("Attack")*/)
        {
            if (renderer.flipY == false)
            {
                // 弾の生成
                Instantiate(BulletObj, transform.position + bulletPoint, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (renderer.flipY == true)
            {
                // 弾の生成
                Instantiate(BulletObj, transform.position - bulletPoint, Quaternion.identity);
            }
        }
        #endregion
        // スペシャルアタックボタンを押したとき
        if (Input.GetKeyDown(KeyCode.A) && intervalFlag == 0) 
        {
            //上を向いているとき
            if (renderer.flipY == false)
            {
                // 弾の生成
                Instantiate(SkillObj, transform.position + bulletPoint, Quaternion.identity);
                intervalFlag = 1;
            }
            //下を向いているとき
            if (renderer.flipY == true)
            {
                // 弾の生成
                Instantiate(SkillObj, transform.position - bulletPoint, Quaternion.identity);
                intervalFlag = 1;
            }
        }

        if (intervalFlag == 1)
        {
            SkillintervalTimer++;

            if (SkillintervalTimer >= 60) 
            {
                skillFlag++;
                SkillintervalTimer = 0;
            }
            if (skillFlag == 5)
            {
                intervalFlag = 0;
                skillFlag = 0;
                SkillintervalTimer = 0;
            }
        }
        AddScore(TimerValue);

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * fMoveSpeed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * fMoveSpeed;

        transform.position = new Vector2(
            //エリア指定して移動する
            Mathf.Clamp(transform.position.x + moveX, -18.0f, 9.0f),
            Mathf.Clamp(transform.position.y + moveY, -27.0f, 23.0f)
            );
    }

    public static int GetFlag()
    {
        return intervalFlag;
    }

    public static int GetIntervalTimer()
    {
        return SkillintervalTimer;
    }

}



