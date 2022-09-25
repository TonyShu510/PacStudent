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
        yield return new WaitForSecondsRealtime(backgroundMusic.clip.length);
        Debug.Log("GameStart!");
        //close the manually one
        gridManually.SetActive(false);
        //play ememy walk sound
        ememySound.Play();
        //generate the map
        gridContro.GenerateGrid();
        //change game stats
        gameStarted = true;
    }
    public void StartGameButton()
    {

        StartCoroutine(GameStart());

    }

}
