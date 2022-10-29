using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public AudioSource backgroundMusic, ememySound;
    public static bool gameStarted = false;
    public GridController gridContro;
    public GameObject gridManually;

    float time;
    // Start is called before the first frame update
    void Start()
    {

        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();
        ememySound = ememySound.GetComponent<AudioSource>();
        gridContro = gridContro.GetComponent<GridController>();
        
    }


    IEnumerator GameStart()
    {

        backgroundMusic.Play();
        //close the manually one
        gridManually.SetActive(false);
        //generate the map
        gridContro.GenerateGrid();
        yield return new WaitForSecondsRealtime(backgroundMusic.clip.length);
        Debug.Log("GameStart!");
        //play ememy walk sound
        ememySound.Play();
        //change game stats
        gameStarted = true;
    }
    public void StartGameButton()
    {

        StartCoroutine(GameStart());

    }

}
