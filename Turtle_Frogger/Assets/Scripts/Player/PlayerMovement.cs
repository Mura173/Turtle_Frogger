using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX, maxX, minY;

    // Piscar
    public float blinkInterval;
    public int blinkCount;
    public float minAlpha = 0.2f;

    private Rigidbody2D rb;
    public Transform startPos;

    private SpriteRenderer sR;
    private Animator anim;

    [SerializeField]
    private InputActionReference moveAction;

    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = GameObject.Find("StartPos").transform;
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
            CheckBounds();
        }
    }

    void Movement()
    {
        Vector2 moveDirection = moveAction.action.ReadValue<Vector2>();

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.x < minX)
        {
            temp.x = minX;
        }

        if (temp.y <= minY)
        {
            temp.y = minY;
        }

        transform.position = temp;
    }

    void ResetPlayerPosition()
    {
        rb.MovePosition(startPos.position);

        StartCoroutine(ResetAnimator());
    }

    IEnumerator ResetAnimator()
    {
        canMove = false;
        for (int i = 0; i < blinkCount; i++)
        {
            // Mudando alfa da imagem
            Color tempColor = sR.color;
            tempColor.a = minAlpha;
            sR.color = tempColor;

            yield return new WaitForSeconds(blinkInterval);

            // Restaura o alfa
            tempColor.a = 1f;
            sR.color = tempColor;

            yield return new WaitForSeconds(blinkInterval);
        }

        // Garante que o sprite termine totalmente visível
        Color finalColor = sR.color;
        finalColor.a = 1f;
        sR.color = finalColor;

        canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Garbage"))
        {
            ResetPlayerPosition();
        }
    }

}
