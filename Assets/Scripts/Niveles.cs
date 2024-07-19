using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Niveles : MonoBehaviour
{
    public bool NLevel;
    public int WLevel;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CLevel(WLevel);
        }

        if (NLevel)
        {
            CLevel(WLevel);
        }
    }

    public void CLevel(int W)
    {
        SceneManager.LoadScene(W);
    }
}
