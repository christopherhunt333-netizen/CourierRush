using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip pickUpClip;
    public AudioClip deliveryClip;

    float acceleration = 5f;
    float deceleration = 5f;
    float maxSpeed = 6f;
    float turnSpeed = 200f;
    float currentSpeed = 0f;

    Rigidbody2D rb;
    Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        float moveAmount = moveInput.y;
        if (moveAmount != 0f)
        {
            currentSpeed += moveAmount * acceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }

        float turnAmount = -moveInput.x * turnSpeed * Time.fixedDeltaTime;

        rb.MoveRotation(rb.rotation + turnAmount);
        rb.linearVelocity = transform.up * currentSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Delivery") || !other.CompareTag("Package"))
        {
            return;
        }



        if (other.CompareTag("Delivery"))
        {
            FindFirstObjectByType<GameManager>().UpdateDeliveryScore();
            audioSource.PlayOneShot(deliveryClip);
            return;
        }

        if (other.CompareTag("Package"))
        {
            audioSource.PlayOneShot(pickUpClip);
            return;
        }
    }
}
