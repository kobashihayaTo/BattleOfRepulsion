using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageReplace : MonoBehaviour
{
    // �f�t�H���g�̉摜(������̉摜)
    public Sprite explodeImage;
    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    void Start()
    {
        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Player�^�O�������I�u�W�F�N�g�ƏՓ˂������ɏ���
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Enemy_")
        {
            // �f�t�H���g�̉摜�𔚔���̉摜�ɐ؂�ւ���
            sr.sprite = explodeImage;
        }
    }
}
