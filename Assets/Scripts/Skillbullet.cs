using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skillbullet : MonoBehaviour
{
    // �f�t�H���g�̉摜(���e�̉摜)
    public Sprite defaultImage;
    // �f�t�H���g�̉摜(������̉摜)
    public Sprite explodeImage;
    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    bool Skillrender = PlayerMove.Skillrender;

    int timer = 0;
    int flag = 0;

    public float MoveSpeed = 20.0f;         // �ړ��l

    // Start is called before the first frame update
    void Start()
    {
        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Skillrender == false){
            // �ʒu�̍X�V
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        }
        if (Skillrender == true)
        {
            // �ʒu�̍X�V
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
