using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkullController : MonoBehaviour
{
    float timeToNextBlock = 0.1f; //speed of pass through each block
    float currentTime, moveDirectionX, moveDirectionY, distanceBlocks = 0;
    Vector3 startPosition;
    Animator skullAnimator;
    Vector2 borderSize= new Vector2(4.8f, 7.36f);

    // Start is called before the first frame update
    void Start()
    {        
        startPosition = transform.localPosition;
        distanceBlocks = (borderSize.x-startPosition.x)/0.32f;
        ControlDirection("right");
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.scene.name == "Start Scene"){
            StartScreenRouta();
        }
    }


    private void StartScreenRouta()
    {
        
            skullAnimator = GetComponent<Animator>();
            skullAnimator.SetBool("Scared", true);
            skullAnimator.SetBool("startMode", true);

            //hardcode to walk clockwise
            if (Vector2.Distance(transform.localPosition, new Vector2(-borderSize.x,-borderSize.y))<0.0001)
            {
                startPosition = transform.localPosition;
                distanceBlocks = (borderSize.y * 2f)/0.32f;
                ControlDirection("up");
                currentTime = 0;
            }
            else if (Vector2.Distance(transform.localPosition, new Vector2(-borderSize.x,borderSize.y))<0.0001)
            {
                startPosition = transform.localPosition;
                distanceBlocks = (borderSize.x * 2f)/0.32f;
                ControlDirection("right");
                currentTime = 0;
            }
            else if (Vector2.Distance(transform.localPosition, new Vector2(borderSize.x,borderSize.y))<0.0001)
            {
                startPosition = transform.localPosition;
                distanceBlocks = (borderSize.y * 2f)/0.32f;
                ControlDirection("down");
                currentTime = 0;
            }
            else if (Vector2.Distance(transform.localPosition, new Vector2(borderSize.x,-borderSize.y))<0.0001)
            {
                startPosition = transform.localPosition;
                distanceBlocks = (borderSize.x * 2f)/0.32f;
                ControlDirection("left");
                currentTime = 0;
            }

            currentTime += Time.deltaTime;
            MoveDirection(moveDirectionX, moveDirectionY);
    }

    private void Turn(float rotZ, float ScaleX)
    {
        transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
       
        //face to left
        Vector3 theScale = transform.localScale;
        if(ScaleX<0){
        theScale.x = -theScale.x;
        }else{
        theScale.x = Mathf.Abs(theScale.x);
        }

        transform.localScale = theScale;
    }
    
    private void MoveDirection(float x, float y)
    {
        float moveTime = currentTime / timeToNextBlock / distanceBlocks;
        Vector3 movement = new Vector2(startPosition.x + x* distanceBlocks, startPosition.y + y* distanceBlocks);
        transform.localPosition = Vector3.Lerp(startPosition, movement, moveTime);
        
        if (Vector2.Distance(transform.localPosition, new Vector2(borderSize.x,-borderSize.y))<0.001){
            transform.localPosition = movement;
        }
    }

    private void ControlDirection(string skullDirection)
    {

        if (skullDirection=="up")
        {
            Turn(-90f, -1f);
            moveDirectionX = 0;
            moveDirectionY = 0.32f;
        }
        else if (skullDirection == "down")
        {
            Turn(90f, -1f);
            moveDirectionX = 0;
            moveDirectionY = -0.32f;
        }
        else if (skullDirection == "left")
        {
            Turn(0f, -1f);
            moveDirectionX = -0.32f;
            moveDirectionY = 0;
        }
        else if (skullDirection == "right")
        {
            Turn(0f, 1f);
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