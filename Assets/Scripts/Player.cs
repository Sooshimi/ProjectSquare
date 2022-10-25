using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] float moveSpeed = 10f;
    Vector2 rawInput;

    [Header("Player movement restrictions")]
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;

    [Header("Guns")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun; // gun position
    
    void Update()
    {
        Move();
    }

    void InitBounds() // gets min and max bounds of camera viewport
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();

        // restrict player boundary to camera viewport
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        
        //newPos = (Vector2)transform.position + delta; // no camera restriction
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, gun.position, transform.rotation);
    }
}
