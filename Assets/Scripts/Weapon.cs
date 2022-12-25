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

    public void Shoot()
    {
        player.Knockback(knockBackAmount);
    }
}
