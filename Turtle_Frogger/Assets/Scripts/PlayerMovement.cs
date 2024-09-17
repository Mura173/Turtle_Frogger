using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float minX, maxX, minY;

    private Rigidbody2D rb;

    [SerializeField]
    private InputActionReference moveAction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBounds();
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
}
