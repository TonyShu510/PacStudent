using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizardcontroller : MonoBehaviour
{
    public float walkSpeed = 0.1;
    float moveDirectionX, moveDirectionY = 0;
    Animator wizardAnimator;

    // Start is called before the first frame update
    void Start()
    {
        wizardAnimator = GetComponent<Animator>();
        wizardAnimator.SetBool("Gaming", true);
        moveDirectionX = -1;   //start move to left
        wizardAnimator.SetBool("Moving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown("w"))
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
        }else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
        {
            Turn(0f, 1f);
            moveDirectionX = -1;
            moveDirectionY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
        {
            Turn(0f, -1f);
            moveDirectionX = 1;
            moveDirectionY = 0;
        }

        MoveDirection(moveDirectionX, moveDirectionY);

    }


    private void Turn(float rotZ, float ScaleX)
    {
        transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
        Vector3 theScale = transform.localScale;
        theScale.x = ScaleX;
        transform.localScale = theScale;
    }
    
    private void MoveDirection(float x, float y)
    {
        Vector3 movement = new Vector2(x, y);
        transform.Translate(movement * Time.deltaTime * walkSpeed, Space.World);
    }
}
