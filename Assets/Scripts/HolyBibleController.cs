using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBibleController : MonoBehaviour
{
    BackgroundControl gameControl;
    float time;
    private void Start()
    {
        gameControl = GameObject.FindGameObjectWithTag("Controller").GetComponent<BackgroundControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BackgroundControl.gameStarted)
        {
            //game start and start count
            time += Time.deltaTime;

            //flash speed
            float speed = 0.4f;
            if (time > speed)
                {
                    time -= speed;

                Vector3 holyBibleScale = transform.localScale;
                //change size to make it flash
                if (holyBibleScale.x > 0.5)
                {
                    holyBibleScale.x--;
                    holyBibleScale.y--;
                    transform.localScale = holyBibleScale;
                }
                else
                {

                    holyBibleScale.x++;
                    holyBibleScale.y++;
                    transform.localScale = holyBibleScale;
                    }
            }
        }
    }
}
