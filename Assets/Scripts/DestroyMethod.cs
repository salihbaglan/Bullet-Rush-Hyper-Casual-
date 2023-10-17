using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMethod : MonoBehaviour
{
    public float destructionDelay = 1f; // Yok etme gecikmesi s�resi

    private void Start()
    {
        Invoke("DestroySelf", destructionDelay); // Belirtilen s�re sonra "DestroySelf" fonksiyonunu �a��r
    }

    private void DestroySelf()
    {
        Destroy(gameObject); // Nesneyi yok et
    }
}
