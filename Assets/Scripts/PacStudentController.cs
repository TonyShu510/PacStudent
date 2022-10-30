using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    string lastInput, currentInput = "right";       //start go right
    float oneGridWidth = 0.32f;     //change if Grid size changed
    Vector2 startPosition, nextGridPosition;   
    float pacSpeed = 0.5f;          //larger = slower
    float currentTime;
    float moveDirectionX, moveDirectionY = 0;
    int pacGridX, pacGridY;
    int[,] playingMap;
    Animator wizardAnimator;
    public bool movingBool = true;

    // Start is called before the first frame update
    void Start()
    {
        
        wizardAnimator = GetComponent<Animator>();
        wizardAnimator.SetBool("Gaming", true);
        //start at top left (1,1)
        pacGridX = 1;  
        pacGridY = 1;
        MoveOneGrid();
        if(gameObject.scene.name == "Spirit Elimination_Level01")
        {
            playingMap=LevelGenerator.levelMap01;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
        {
            lastInput="up";
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
        {
            lastInput="down";
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
        {
            lastInput="left";
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
        {
            lastInput="right";
        }

        currentTime += Time.deltaTime;

        //only call when fit in a grid
        if(Vector2.Distance(transform.localPosition, nextGridPosition)<0.0001){
            //check last Input
            if(lastInput!=null)
            {
                if(!WallDetect(lastInput))
                {
                    //next grid is not a wall
                    currentInput = lastInput;
                }
                lastInput = null;
            }
            
            if(!WallDetect(currentInput))
            {
                Debug.Log(nextGridPosition+", "+pacGridX+", "+pacGridY);
                MoveOneGrid();
                wizardAnimator.SetBool("Moving", true);
                movingBool = true;
             wizardAnimator.enabled = true;
            }else{
                
             wizardAnimator.enabled = false;
                movingBool = false;
            }
        }

        Debug.Log(nextGridPosition);
        //always call
        MoveDirection();


    }
    
    private bool WallDetect(string direction){
        int nextGridX, nextGridY, arrayHeight, arrayWidth;
        arrayHeight = playingMap.GetLength(0);  
        arrayWidth = playingMap.GetLength(1);   

            nextGridX=pacGridX;
            nextGridY=pacGridY;

        if (direction=="up")
        {
            nextGridY = pacGridY - 1;         

        }else if (direction == "down")
        {
            nextGridY = pacGridY + 1;
            
        }else if (direction == "left")
        {
            nextGridX = pacGridX - 1;
        }else if (direction == "right")
        {
            nextGridX = pacGridX + 1;
        }else{return true;}


        if(nextGridX>=arrayWidth){
            nextGridX = 2*arrayWidth -nextGridX-2;
        }

        if(nextGridY>=arrayHeight){
            nextGridY = 2*arrayHeight -nextGridY-2;
        }


        //handle tranfer to other side here
        if(nextGridY<arrayHeight && nextGridX<arrayWidth && nextGridY>=0 && nextGridX>=0){
            int x = playingMap[nextGridY,nextGridX];
            if(x==5||x==6||x==0)
                {
                    return false;
                }
        }
        return true;
    }
    private void Turn(float rotZ, float ScaleX)
    {
        transform.rotation = Quaternion.AngleAxis(rotZ, Vector3.forward);
       
        //face to left
        Vector3 theScale = transform.localScale;
        if(ScaleX<0){
        theScale.x = -(Mathf.Abs(theScale.x));
        }else{
        theScale.x = Mathf.Abs(theScale.x);
        }

        transform.localScale = theScale;
    }

    private void MoveDirection()
    {
        float moveTime = currentTime / pacSpeed;
        
        transform.localPosition = Vector3.Lerp(startPosition, nextGridPosition, moveTime);
        
        if (Vector2.Distance(transform.localPosition, nextGridPosition)<0.001){
            transform.localPosition = nextGridPosition;
        }
    }

    private void MoveOneGrid()
    {
        startPosition = transform.localPosition;
        moveDirectionX = 0;
        moveDirectionY = 0;
        if (currentInput=="up")
        {
            Turn(-90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = oneGridWidth;
            pacGridY -=1;
        }
        else if (currentInput == "down")
        {
            Turn(90f, 1f);
            moveDirectionX = 0;
            moveDirectionY = -oneGridWidth;
            pacGridY +=1;
            
        }
        else if (currentInput == "left")
        {
            Turn(0f, 1f);
            moveDirectionX = -oneGridWidth;
            moveDirectionY = 0;
            pacGridX -=1;
        }
        else if (currentInput == "right")
        {
            Turn(0f, -1f);
            moveDirectionX = oneGridWidth;
            moveDirectionY = 0;
            pacGridX +=1;
        }
        //next grid
        nextGridPosition = new Vector2(startPosition.x + moveDirectionX, startPosition.y + moveDirectionY);
        currentTime=0;
    }


}
