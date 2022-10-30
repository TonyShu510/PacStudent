using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    public AudioSource backgroundMusic, ememySound, pacStudentStepSound;
    public static bool gameStarted = false;
    public GridController gridContro;
    PacStudentController pacStudent;

    float time;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();
        ememySound = ememySound.GetComponent<AudioSource>();
        gridContro = gridContro.GetComponent<GridController>();
        pacStudentStepSound = pacStudentStepSound.GetComponent<AudioSource>();
        pacStudent = GameObject.FindGameObjectWithTag("Player").GetComponent<PacStudentController>();
        
        
    }
    void LateUpdate(){
        Debug.Log(pacStudent.movingBool);
        if(pacStudent.movingBool){
            pacStudentStepSound.Play();
        }else{
            pacStudentStepSound.Pause();
        }
    }

    IEnumerator GameStart()
    {

        backgroundMusic.Play();
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
