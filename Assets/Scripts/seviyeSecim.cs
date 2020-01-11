using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seviyeSecim : MonoBehaviour
{
    public void seviyeAc(string seviyeAdi)
    {
        SceneManager.LoadScene(seviyeAdi);
    }
}
