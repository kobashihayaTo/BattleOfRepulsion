using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    GameObject hp;
    int HpFlag = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy_"))
        {
            HpFlag--;
            if (HpFlag == 0)
            {
                Debug.Log("“–‚½‚Á‚Ä‚é‚ª");
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
