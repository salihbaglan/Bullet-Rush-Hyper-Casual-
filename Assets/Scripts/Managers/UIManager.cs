using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance { get; private set; }

    public string enemyTag = "Enemy";
    public Slider progressBar;
    public Text percentageText; // Text bile�eni eklendi
    public Text EnemycountText; // Text bile�eni eklendi

    public GameObject GameOverPanel;
    public GameObject NextLevelPanel;
    public GameObject UIPanel;
    public GameObject HomeButton;



    public bool isPlay = false;

    private int destroyedEnemyCount = 0; // Yok edilen d��man say�s�n� saklamak i�in de�i�ken
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
            Destroy(gameObject); // Birden fazla UIManager �rne�ini �nlemek i�in bu �rne�i yok ediyoruz.
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
        destroyedEnemyCount++; // D��man yok edildi�inde sayac� art�r
        UpdateProgressBar();
        UpdateEnemyCountText(); // D��man say�s� metnini g�ncelle
    }

    private void UpdateProgressBar()
    {
        float fillAmount = 1f - (float)currentEnemyCount / initialEnemyCount;
        progressBar.value = fillAmount;
        UpdatePercentageText(fillAmount); // Y�zde de�erini g�ncelle
    }

    private void UpdatePercentageText(float fillAmount)
    {
        int percentage = Mathf.RoundToInt(fillAmount * 100); // Y�zdeyi hesapla
        percentageText.text = percentage + "%"; // Text bile�enini g�ncelle
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
