using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class PlayerBullet : MonoBehaviour
{
    bool render = PlayerMove.render;
    public float MoveSpeed = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (render == false)
        {
            // ˆÚ“®‚·‚é
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
        }
        if (render == true)
        {
            // ˆÚ“®‚·‚é
            transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
        }
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
