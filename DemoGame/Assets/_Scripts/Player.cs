using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private string horizontalAxis = "Horizontal";

    [SerializeField] private string verticalAxis = "Vertical";

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private float speed = 4f;

    private Vector2 _movement;

    private void FixedUpdate()
    {
        rb2d.velocity = _movement * speed;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis(horizontalAxis); // left and right movement
        var verticalInput = Input.GetAxis(verticalAxis); // up and down movement

        _movement = new Vector2(horizontalInput, verticalInput);
        _movement.Normalize(); // normalize movement vector so it has a length of 1
    }
}