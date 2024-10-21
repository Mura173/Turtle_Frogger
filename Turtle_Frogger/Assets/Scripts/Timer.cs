using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float targetTime = 40.0f;

    public Text timerText;

    public Points pointsScript;

    public Animator youLoseAnim;

    // Update is called once per frame
    void Update()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
        }       

        timerText.text = Mathf.FloorToInt(targetTime).ToString();

        if (targetTime <= 0)
        {
            targetTime = 0;
            TimeEnd();
        }
    }

    void TimeEnd()
    {
        pointsScript.points = 0;
        youLoseAnim.SetBool("Lose", true);       
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(1);
    }
}
