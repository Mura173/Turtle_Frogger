using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float targetTime = 60.0f;

    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        timerText.text = "" + targetTime;

        if (targetTime <= 0.0f)
        {

        }
    }

    void TimeEnd()
    {

    }
}
