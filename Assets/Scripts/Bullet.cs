using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 20f;
    Player player;
    Vector3 bulletDirection;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse pointer direction
        
        bulletDirection = cursorPos - transform.position; // find direction of mouse based on bullet's initial position on instantiation
        bulletDirection.z = 0;
        bulletDirection.Normalize(); // magnitude 1

        StartCoroutine(destroyAfterTime());
    }

    void Update()
    {
        myRigidbody.velocity = bulletDirection * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy(this.gameObject);
    }

    IEnumerator destroyAfterTime()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
