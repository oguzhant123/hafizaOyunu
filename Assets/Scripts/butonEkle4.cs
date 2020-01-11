using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butonEkle4 : MonoBehaviour
{


    [SerializeField]        //SERİLEŞTİRME
    private Transform PuzzleAlan;

    [SerializeField]
    private GameObject btn;


    void Awake()
    {

        for (int i = 0; i < 12; i++)
        {
            GameObject button = Instantiate(btn);   //instantiate ile obje klonlandı.
            button.name = "" + i;
            button.transform.SetParent(PuzzleAlan, false);
        }
    }
}
