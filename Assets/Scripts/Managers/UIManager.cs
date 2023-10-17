using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public string enemyTag = "Enemy";
    public Slider progressBar;
    public Text percentageText; // Text bileþeni eklendi
    public Text EnemycountText; // Text bileþeni eklendi

    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;
    public GameObject UIPanel;
    public GameObject HomeButton;



    public bool isPlay = false;

    private int destroyedEnemyCount = 0; // Yok edilen düþman sayýsýný saklamak için deðiþken
    public int initialEnemyCount;
    public int currentEnemyCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Birden fazla UIManager örneðini önlemek için bu örneði yok ediyoruz.
        }
    }
    private void Start()
    {
        EnemyCount();
        Time.timeScale = 1;
        progressBar.interactable = false;
    }

    private void EnemyCount()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        initialEnemyCount = enemies.Length;
        currentEnemyCount = initialEnemyCount;
    } 

    public void DecreaseEnemyCount()
    {
        currentEnemyCount--;
        destroyedEnemyCount++; // Düþman yok edildiðinde sayacý artýr
        UpdateProgressBar();
        UpdateEnemyCountText(); // Düþman sayýsý metnini güncelle
    }

    private void UpdateProgressBar()
    {
        float fillAmount = 1f - (float)currentEnemyCount / initialEnemyCount;
        progressBar.value = fillAmount;
        UpdatePercentageText(fillAmount); // Yüzde deðerini güncelle
    }

    private void UpdatePercentageText(float fillAmount)
    {
        int percentage = Mathf.RoundToInt(fillAmount * 100); // Yüzdeyi hesapla
        percentageText.text = percentage + "%"; // Text bileþenini güncelle
    }

    private void UpdateEnemyCountText()
    {
        EnemycountText.text = "" + (currentEnemyCount + destroyedEnemyCount) + "/" + initialEnemyCount;
    }
    public void PlayButton()
    {
        isPlay = true;
        HomeButton.SetActive(true);
    }

  
}
