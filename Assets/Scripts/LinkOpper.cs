using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpper : MonoBehaviour
{
    private string AbioGame = "https://play.google.com/store/apps/developer?id=Abio+Games&hl=tr&gl=US"; // Açýlacak URL



    public void OpenLink()
    {
        Application.OpenURL(AbioGame); // Belirtilen URL'yi aç
    }
}
