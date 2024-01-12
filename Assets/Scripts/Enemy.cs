using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public int scoreValue;  // ���ꂪ�G��|���Ɠ�����_���ɂȂ�
    private ScoreManager sm;
    //GameObject�^��ϐ�target�Ő錾���܂��B
    public GameObject target;

    [SerializeField] GameObject deathEffect;

    public Sprite skillbullet;
    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    int flag = 0;
    int time = 0;
    int HP = 2;

    //�ړ����x
    float moveSpeed = 1.0f;

    void Start()
    {
        // �uScoreManager�I�u�W�F�N�g�v�ɕt���Ă���uScoreManager�X�N���v�g�v�̏����擾���āusm�v�̔��ɓ����B
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
                // ���g������
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
            // �e������
            Destroy(other.gameObject);
        }

        if (HP <= 0)
        {

            // ���������̂��v���C���[�̒e
            if (other.gameObject.CompareTag("bullet"))
            {
                Instantiate(deathEffect, this.transform.position, this.transform.rotation);

                // ���g������
                Destroy(gameObject);

                // �e������
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("skill"))
            {
                Instantiate(deathEffect, this.transform.position, this.transform.rotation);
                sr.sprite = skillbullet;

                flag = 1;
            }
            // ���ǉ�
            sm.AddScore(scoreValue);
        }
    }


}