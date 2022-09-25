using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public AudioSource backgroundMusic, ememySound;
    bool gameStarted = false;

    float time;
    // Start is called before the first frame update
    void Start()
    {

        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();
        ememySound = ememySound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            time += Time.deltaTime;
        }
        if (time >= backgroundMusic.clip.length)
        {
            ememySound.Play();
        }

    }

    public void StartMusic()
    {

        backgroundMusic.Play();
        time = Time.deltaTime;//refresh the value
        gameStarted = true;//game started
        Debug.Log("GameStart!");


    }

}
