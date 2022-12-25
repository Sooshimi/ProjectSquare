using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float knockBackAmount = 150f;
    [SerializeField] private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        // Rotate weapon to point towards mouse direction
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        // Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        // float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; 
        // transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
    }

    public void Shoot()
    {
        player.Knockback(knockBackAmount);
    }
}
