using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    int HP = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy_"))
        {
            HP--;
            if(HP == 0)
            {
                Debug.Log("“–‚½‚Á‚Ä‚é‚ª");
                //Destroy(gameObject);
            }
        }
    }
}
