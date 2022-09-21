using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundControl : MonoBehaviour
{

    public AudioSource backgroundMusic, ememySound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnClickUp()
    {
        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();

        ememySound = ememySound.GetComponent<AudioSource>();
        ememySound.PlayDelayed(backgroundMusic.clip.length);

        Debug.Log("GameStart!");
        backgroundMusic.Play();
    }
}
