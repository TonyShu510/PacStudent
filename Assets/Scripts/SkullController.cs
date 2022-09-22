using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    public float walkSpeed = 1;
    float moveDirectionX, moveDirectionY = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
        {
            Turn(-90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
        {
            Turn(90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = -1;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
        {
            Turn(0f, 1f);
            moveDirectionX = 1;
            moveDirectionY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
        {
            Turn(0f, -1f);
            moveDirectionX = -1;
            moveDirectionY = 0;
        }
    }


    private void Turn(float rotZ, float ScaleX)
    {
        transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
        Vector3 theScale = transform.localScale;
        theScale.x = ScaleX;
        transform.localScale = theScale;
    }
}
