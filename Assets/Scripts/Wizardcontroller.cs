using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizardcontroller : MonoBehaviour
{
    float timeToNextBlock = 0.1f; //speed of pass through each block
    float currentTime, moveDirectionX, moveDirectionY = 0;
    int distanceBlocks;
    Vector3 startPosition;
    Animator wizardAnimator;
    public AudioSource ememySound;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(-3.84f, 1.6f, 0f);    //start position
        ememySound = ememySound.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //check gameobject position and give direction to make it clockwise
        //start when play ememysound
        if (ememySound.isPlaying)
        {
            wizardAnimator = GetComponent<Animator>();
            wizardAnimator.SetBool("Gaming", true);
            wizardAnimator.SetBool("Moving", true);

            float testX, testY;
            testX = transform.localPosition.x - 0;
            testY = transform.localPosition.y - 0;

            //hardcode to walk clockwise
            if (testX == -3.84f && testY == 1.6f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 7;
                ControlDirection("up");
                currentTime = 0;
            }
            else if (testX == -3.84f && testY == 3.84f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 11;
                ControlDirection("right");
                currentTime = 0;
            }
            else if (testX == -0.32f && testY == 3.84f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 4;
                ControlDirection("down");
                currentTime = 0;
            }
            else if (testX == -0.32f && testY == 2.56f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 11;
                ControlDirection("left");
                currentTime = 0;
            }
            else if (testX == -0.32f && testY == 2.56f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 11;
                ControlDirection("left");
                currentTime = 0;
            }
            else if (testX == -3.84f && testY == 2.56f)
            {
                startPosition = transform.localPosition;
                distanceBlocks = 4;
                ControlDirection("up");
                currentTime = 0;
            }

            currentTime += Time.deltaTime;
            MoveDirection(moveDirectionX, moveDirectionY);
        }
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
        float moveTime = currentTime / timeToNextBlock / distanceBlocks;
        Vector3 movement = new Vector2(startPosition.x + x* distanceBlocks, startPosition.y + y* distanceBlocks);
        transform.localPosition = Vector3.Lerp(startPosition, movement, moveTime);
    }

    private void ControlDirection(string wizardDirection)
    {

        if (wizardDirection=="up")
        {
            Turn(-90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = 0.32f;
        }
        else if (wizardDirection == "down")
        {
            Turn(90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = -0.32f;
        }
        else if (wizardDirection == "left")
        {
            Turn(0f, 1f);
            moveDirectionX = -0.32f;
            moveDirectionY = 0;
        }
        else if (wizardDirection == "right")
        {
            Turn(0f, -1f);
            moveDirectionX = 0.32f;
            moveDirectionY = 0;
        }


        /*
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
            moveDirectionX = -1;
            moveDirectionY = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
        {
            Turn(0f, -1f);
            moveDirectionX = 1;
            moveDirectionY = 0;
        }
        */

    }
    
}
