using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpriteScripts : MonoBehaviour
{

    public SpriteRenderer renderer;
    public static bool render = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") /*|| Input.GetAxis("Vertical") > 0*/)
        {
            renderer.flipY = false;
            render = false;
        }
        if (Input.GetKey("down") /*|| Input.GetAxis("Vertical") < 0*/)
        {
            renderer.flipY = true;
            render = true;
        }
    }
}
