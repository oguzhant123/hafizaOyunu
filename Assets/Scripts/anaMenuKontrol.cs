using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class anaMenuKontrol : MonoBehaviour
{
    public void oyna()
    {
        // Bir Sonraki Sahneye Geçecek Yani Seviye Seçim Ekranı
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void cikis()
    {
        Application.Quit();
    }
}
