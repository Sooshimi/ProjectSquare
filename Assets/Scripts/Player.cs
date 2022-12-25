using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 bulletDirection;
    Vector3 cursorPos;
    Vector3 initial;

    [Header("Guns")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gunPoint;
    [SerializeField] Weapon weapon;
    
    void Start()
    {
        initial = transform.position;
        
        rb = GetComponent<Rigidbody2D>();
        bulletDirection.z = 0;
        weapon = FindObjectOfType<Weapon>();
    }
    
    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bulletDirection = cursorPos - transform.position;
        bulletDirection.Normalize();

        if (Input.GetKey("space"))
        {
            transform.position = initial;
        }
    }

    public void Knockback(float value)
    {
        rb.AddForce(-bulletDirection * value);
    }

    void OnFire(InputValue value)
    {
        Instantiate(bullet, gunPoint.position, transform.rotation);
        weapon.Shoot();
    }
}
