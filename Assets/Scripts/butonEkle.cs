using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butonEkle : MonoBehaviour {

    
    [SerializeField]        //SERİLEŞTİRME
    private Transform PuzzleAlan;

    [SerializeField]
    private GameObject btn;

    
     void Awake()
     {
        
        for (int i = 0; i < 4; i++)
        {
            GameObject button = Instantiate(btn);   //instantiate ile obje klonlandı.
            button.name = "" + i;
            button.transform.SetParent(PuzzleAlan, false);
        }

        /*int ikinciSahneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings < ikinciSahneIndex)
        {
            SceneManager.LoadScene(ikinciSahneIndex);
            for (int i = 0; i < 6; i++)
            {
                GameObject button = Instantiate(btn);   //instantiate ile obje klonlandı.
                button.name = "" + i;
                button.transform.SetParent(PuzzleAlan, false);
            }
        
        }*/



    }
}
