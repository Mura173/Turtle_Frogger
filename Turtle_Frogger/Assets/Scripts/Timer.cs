using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float targetTime = 40.0f;

    public Text timerText;

    public Animator youLoseAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        youLoseAnim.SetBool("Lose", true);
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene(1);
    }
}
