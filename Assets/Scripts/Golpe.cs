using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Golpe : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float health;
    private SpriteRenderer spr;

    private void Start()
    {
        health = maxHealth;
        spr = GetComponent<SpriteRenderer>();
        healthBar.UpdateHealthBar(maxHealth, health);
    }
    private void OnMouseDown()
    {
        StartCoroutine(GetDamage());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo"))
        {
            StartCoroutine(GetDamage());
        }

    }

    IEnumerator GetDamage()
    {
        float damageDuration = 0.1f;
        float damage = 1f;
        health -= damage;
        healthBar.UpdateHealthBar(maxHealth, health);
        if (health > 0)
        {
            spr.color = Color.red;
            yield return new WaitForSeconds(damageDuration);
            spr.color = Color.white;
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

}
