using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Fungsi ini akan dipanggil saat button ditekan
    public void LoadLevel1()
    {
        // Nama scene harus sesuai dengan nama yang ada di Build Settings
        SceneManager.LoadScene("Lvl1");
    }
}