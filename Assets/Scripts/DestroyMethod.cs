using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMethod : MonoBehaviour
{
    public float destructionDelay = 1f; // Yok etme gecikmesi süresi

    private void Start()
    {
        Invoke("DestroySelf", destructionDelay); // Belirtilen süre sonra "DestroySelf" fonksiyonunu çaðýr
    }

    private void DestroySelf()
    {
        Destroy(gameObject); // Nesneyi yok et
    }
}
