using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 1f;

    public float minSpeed;
    public float maxSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        StartCoroutine(DestroyGarbage());
    }

    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }

    IEnumerator DestroyGarbage()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
