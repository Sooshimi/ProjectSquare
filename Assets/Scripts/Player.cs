using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 bulletDirection;
    Vector3 cursorPos;
    [SerializeField] float knockBackAmount = 200f;

    [Header("Player Settings")]
    [SerializeField] float moveSpeed = 10f;
    private Vector2 moveInput;

    [Header("Guns")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletDirection.z = 0;
    }
    
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bulletDirection = cursorPos - transform.position;
        bulletDirection.Normalize();

        Move();
        if (Input.GetKey("z"))
        {
            rb.velocity = -bulletDirection * knockBackAmount;
        }
        
    }

    public void Knockback(float value)
    {
        rb.AddForce(-bulletDirection * value);
    }

    void Move()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, gun.position, transform.rotation);
        Knockback(knockBackAmount);
    }
}
