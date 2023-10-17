using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Oluþturduðunuz Audio Mixer'ý buraya sürükleyin.

    private const string MasterVolumeParameter = "Master";
    private bool soundOn = true;

    public Text buttonText; // Buton metnix

    private void Start()
    {
        // Baþlangýçta kaydedilen ses durumunu al
        soundOn = PlayerPrefs.GetInt("SoundOn", 1) == 1;
        SetSoundState(soundOn);
        UpdateButtonText(); // Buton metnini güncelle
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        SetSoundState(soundOn);

        // Ses durumunu kaydet
        PlayerPrefs.SetInt("SoundOn", soundOn ? 1 : 0);
    }

    private void SetSoundState(bool state)
    {
        float volume = state ? 0 : -80; // Ses açýksa 0, kapalýysa -80 dB.
        UpdateButtonText();
        audioMixer.SetFloat(MasterVolumeParameter, volume);
    }

    void UpdateButtonText()
    {
        buttonText.text = soundOn ? "Volume On" : "Volume Off"; // Buton metnini güncelle
    }

}
