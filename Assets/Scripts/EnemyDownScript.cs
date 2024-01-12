using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDownScript : MonoBehaviour
{
   [SerializeField] List<GameObject> enemyList;    // 生成オブジェクト
    [SerializeField] Transform pos;                 // 生成位置
    [SerializeField] Transform pos2;                // 生成位置
    float minX, maxX, minY, maxY;                   // 生成範囲

    int frame = 0;
    [SerializeField] int generateFrame = 100;        // 生成する間隔

    int time = 0;

    void Start()
    {
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);
    }

    void Update()
    {
        ++frame;

        if (frame > generateFrame)
        {
            frame = 0;

            // ランダムで種類と位置を決める
            int index = Random.Range(0, enemyList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);

            Instantiate(enemyList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }
        ++time;
        if (time > 900)
        {
            generateFrame = 100;
        }
        if (time > 1200)
        {
            generateFrame = 90;
        }
        if (time > 1500)
        {
            generateFrame = 80;
        }
        if (time > 1800)
        {
            generateFrame = 70;
        }
        if (time > 2100)
        {
            generateFrame = 60;
        }
        if (time > 2400)
        {
            generateFrame = 30;
        }
    }

    
}
