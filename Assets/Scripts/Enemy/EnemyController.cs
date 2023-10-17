using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform target; // Hedef pozisyonun Transform bileþeni
    public float speed = 5f; // Hareket hýzý
    public GameObject DeadParticle;
    public float rotationSpeed = 5f;
  


    private void Update()
    {
        //if (UIManager.Instance.isPlay)
        //{
        //    if (target != null)
        //    {
        //        Vector3 direction = (target.position - transform.position).normalized;
        //        transform.Translate(direction * speed * Time.deltaTime);
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            UIManager.Instance.DecreaseEnemyCount();
            collision.gameObject.SetActive(false);
            DeadParticle.SetActive(true);
            DeadParticle.transform.SetParent(null);
        }


       
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"FllowArea"))
        {
            if (target != null)
            {
                // Hedefe doðru bir yön vektörü hesaplayýn.
                Vector3 direction = target.position - transform.position;
                //        // Yön vektörünü normalize edin, böylece nesne sabit bir hýzda hareket eder.
                direction.Normalize();

                //        // Hedefe doðru hareket edin.
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }




}





