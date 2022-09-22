using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pointTo= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(pointTo);
            if((pointTo.x>-0.80f && pointTo.x < 0.8f) && (pointTo.y>-0.30f && pointTo.y < 0.3f))
            {
                StartMusic();
            }
        }
    }

    public void StartMusic()
    {
        gameObject.SetActive(false);

        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();
        backgroundMusic.Play();



        Debug.Log("GameStart!");


    }

}
