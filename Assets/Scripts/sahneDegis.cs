using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneDegis : MonoBehaviour
{
    public void gecisYap(int sahneNo)
    {
        SceneManager.LoadScene(sahneNo);
    }
}
