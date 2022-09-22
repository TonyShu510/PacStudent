using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBibleController : MonoBehaviour
{
    bool gameStats = false;
    public AudioSource backgroundMusic, enemySound;
    float time;
    private void Start()
    {
        backgroundMusic = backgroundMusic.GetComponent<AudioSource>();
        enemySound = enemySound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundMusic.isPlaying && !gameStats)
        {
            StartCoroutine(GameStart());
        }

        if (time > 0.4f)
        {
            time -= 0.4f;
        }
        time += Time.deltaTime;
        if (gameStats == true&& time >0.4)
        {
            Vector3 holyBibleScale = transform.localScale;
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
    IEnumerator GameStart()
    {
        enemySound = enemySound.GetComponent<AudioSource>();
        yield return new WaitForSecondsRealtime(backgroundMusic.clip.length);
        enemySound.Play();
        gameStats = true;
    }
}
