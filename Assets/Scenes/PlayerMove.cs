using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float fMoveSpeed = 0.05f;     // �ړ��l
    //---------------------------
    //          �ǉ�
    public GameObject BulletObj;        // �e�̃Q�[���I�u�W�F�N�g
    public GameObject SkillObj;
    public SpriteRenderer renderer;
    //public GameObject ParticleEffect;   //�p�[�e�B�N��
    //---------------------------

    Vector3 bulletPoint;                // �e�̈ʒu

    /// ---------------
    /// �X�y�V�����A�^�b�N�̃^�C�}�[
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

        //---��������ǉ�----
        renderer = GetComponent<SpriteRenderer>();
        //---�����܂Œǉ�----

        skillFlag = 0;
        CoolTimer = GameObject.Find("CoolTimer").GetComponent<Text>();
        CoolTimer.text = "COOLTIMER:" + skillFlag;
    }
    // �X�R�A�𑝉������郁�\�b�h
    // �O������A�N�Z�X���邽��public�Œ�`����
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
        //���@�ړ�
        if (Input.GetKey("left") /*|| Input.GetAxis("Horizontal") < 0*/)
        {
            position.x -= fMoveSpeed;
        }
        else if((Input.GetKey("left")&&Input.GetKey("up")))//�΂ߍ���
        {
            position.x -= fMoveSpeed ;
            position.y += fMoveSpeed ;
        }
        else if ((Input.GetKey("left") && Input.GetKey("down")))//�΂ߍ���
        {
            position.x -= fMoveSpeed ;
            position.y -= fMoveSpeed;
        }

        if (Input.GetKey("right") /*|| Input.GetAxis("Horizontal") > 0*/)
        {
            position.x += fMoveSpeed;
        }
        else if ((Input.GetKey("right") && Input.GetKey("up")))//�΂ߍ���
        {
            position.x += fMoveSpeed;
            position.y += fMoveSpeed+1;
        }
        else if ((Input.GetKey("right") && Input.GetKey("down")))//�΂ߍ���
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
        // �U���{�^�����������Ƃ�
        if (Input.GetKeyDown(KeyCode.Space)/*|| Input.GetButtonDown("Attack")*/)
        {
            if (renderer.flipY == false)
            {
                // �e�̐���
                Instantiate(BulletObj, transform.position + bulletPoint, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (renderer.flipY == true)
            {
                // �e�̐���
                Instantiate(BulletObj, transform.position - bulletPoint, Quaternion.identity);
            }
        }
        #endregion
        // �X�y�V�����A�^�b�N�{�^�����������Ƃ�
        if (Input.GetKeyDown(KeyCode.A) && intervalFlag == 0) 
        {
            //��������Ă���Ƃ�
            if (renderer.flipY == false)
            {
                // �e�̐���
                Instantiate(SkillObj, transform.position + bulletPoint, Quaternion.identity);
                intervalFlag = 1;
            }
            //���������Ă���Ƃ�
            if (renderer.flipY == true)
            {
                // �e�̐���
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
            //�G���A�w�肵�Ĉړ�����
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



