using UnityEngine;

public class TruckController : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            move = -1f;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            move = 1f;

        rb.linearVelocity = new Vector2(move * moveSpeed, 0f);
    }
}