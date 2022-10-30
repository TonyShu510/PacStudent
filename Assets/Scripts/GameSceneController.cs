using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevel(string lv){
        string sceneName;
        sceneName = "Spirit Elimination_Level"+lv; 
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
