using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text pointsText;
    public int points = 0;

    private PlayerMovement playerMovement;
    public Timer timer;

    public Animator youWinAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "" + points;

        EndGame();
    }

    void EndGame()
    {
        if (points >= 500)
        {
            youWinAnim.SetBool("Win", true);
            timer.targetTime = 0.1f;
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chegada"))
        {
            points += 100;
            transform.position = playerMovement.startPos.transform.position;
        }
    } 
}
