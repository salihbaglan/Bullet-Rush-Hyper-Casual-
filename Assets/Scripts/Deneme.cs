using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public int health;

    public bool isCanJump;
    public int jumpForce = 15;
    public void OnEnemyInRange(Collider other)
    {
        Debug.Log("Enemy in the range");
    }

    public void DestroyEnemy(Collider other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(other.gameObject);
    }

    public void Dead()
    {
        Debug.Log("Player is dead");
    }
}
