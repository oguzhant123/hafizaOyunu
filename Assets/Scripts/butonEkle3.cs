using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class butonEkle3 : MonoBehaviour
{


    [SerializeField]        //SERİLEŞTİRME
    private Transform PuzzleAlan;

    [SerializeField]
    private GameObject btn;

    void Awake()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject button = Instantiate(btn);   //instantiate ile obje klonlandı.
            button.name = "" + i;
            button.transform.SetParent(PuzzleAlan, false);
        }

    }
}

