using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    InputManager inputM;
    private Rigidbody rb;
    private Animator anim;

    public GameObject Body;


    public Transform myTransform;
    public bool IlookEnemy = false;
  
    public int NormalSpeed = 10;
    public int moveSpeed = 10;
    public int stopSpeed = 0;
    public float minMoveSpeedThreshold = 0.1f; // Hareket algýlamasý için minimum hýz eþiði


    public LayerMask enemyLayer;
  
  

    [SerializeField] private ShootController shootController;



    public List<Transform> enemies = new List<Transform>();
    private bool isShoting;



    private float updateInterval = 0.1f; // Güncelleme aralýðý
    private float timeSinceLastUpdate = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        inputM = FindObjectOfType<InputManager>();

    }


    private void FixedUpdate()
    {
     
        var direction = new Vector3(inputM.moveJoystick.Direction.x, 0, inputM.moveJoystick.Direction.y);
        if(moveSpeed == stopSpeed)
        Move(direction);
        if (moveSpeed <= 0.1)
            Wait();



    }




    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"EnemyOwn"))
        {
            if (!enemies.Contains(other.transform))
                enemies.Add(other.transform);
           

        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag($"Enemy"))
        {
            Dead();
        }

        if (collision.transform.CompareTag($"Finishh"))
        {
            Win();
        }
    }
  
   
    protected void Move(Vector3 direction)
    {
        if (inputM.moveJoystick.Direction == Vector2.zero)
        {
            moveSpeed = stopSpeed;
            return;

        }
        rb.velocity = direction * moveSpeed * Time.deltaTime;
        anim.Play("Run");
        moveSpeed = NormalSpeed;
        // Hareket durumunu kontrol et ve animasyonlarý deðiþtir
        if (direction.magnitude > minMoveSpeedThreshold)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    private void Wait()
    {
        anim.CrossFade("Idle",0.1f);
    }

    public void AutoShoot()
    {
        if (!isShoting)
        {
            isShoting = true;
            StartCoroutine(StartShoot());
        }
    }

    private IEnumerator StartShoot()
    {
        while (enemies.Count > 0)
        {
            var enemy = enemies[0];
            var direction = enemy.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;

            // Hedefe doðru dönerek ateþ et
           Body.transform.LookAt(enemy.transform);
           shootController.Shot(direction, transform.position);

            // Bekleme süresi ateþ hýzýna uygun þekilde ayarlanmalý
            yield return new WaitForSeconds(shootController.Delay);

            // Düþmaný listeden çýkar
            enemies.RemoveAt(0);
        }

        // Tüm düþmanlar ateþlendiyse ateþleme bitmiþ demektir
        isShoting = false;
  
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Input.GetMouseButtonUp(0))
            {
                Destroy(gameObject);
            }
        }
       

    }
    public void Dead()
    {
        Time.timeScale = 0;
        UIManager.Instance.GameOverPanel.SetActive(true);
        UIManager.Instance.UIPanel.SetActive(false);
        UIManager.Instance.HomeButton.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Win()
    {
        Time.timeScale = 0;
        UIManager.Instance.NextLevelPanel.SetActive(true);
        UIManager.Instance.UIPanel.SetActive(false);
        UIManager.Instance.HomeButton.SetActive(false);

    }

}
