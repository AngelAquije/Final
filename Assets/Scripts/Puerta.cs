using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public GameObject nokey;
    public GameObject key;
    public GameObject btnPuerta;

    private void Start()
    {
        key.SetActive(false);
        nokey.SetActive(false);
        btnPuerta.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Key")) 
        {
            AbrirPuerta.llave += 1;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("door") && AbrirPuerta.llave == 0) 
        {
            nokey.SetActive(true);
        }
        if (collision.tag.Equals("door") && AbrirPuerta.llave == 1)
        {
            key.SetActive(true);
            btnPuerta.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("door") && AbrirPuerta.llave == 0)
        {
            nokey.SetActive(false);
        }
        if (collision.tag.Equals("door") && AbrirPuerta.llave == 1)
        {
            key.SetActive(false);
            btnPuerta.SetActive(false);
        }
    }
    public void botonabrirP() 
    {
        SceneManager.LoadScene(0);
    }
}
