using System;
using UnityEngine;
using UnityEngine.UI;

public class Earth : Singleton<Earth>, IDestroyable
{
    public GameObject Explosion;
    public Slider healthSlider;
    //public Animator GameOverAnimator;

    float health = 100;

    const float damage = 30;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);

        //if (other.tag == Tags.PowerUp)
        //{
        //    IDestroyable obj = other.gameObject ;

        //    if (obj != null)
        //        obj.DestroyMe();

        //    return;
        //}

        if (other.tag == Tags.Astroid)
            DecreaseHealth(other);
    }

    private void DecreaseHealth(Collider2D other)
    {
        health -= damage;

        healthSlider.value = health;

        if (health <= 0)
            DestroyMe(other);
    }

    public void DestroyMe(Collider2D other)
    {
        Vector3 pos = gameObject.transform.position;

        Destroy(gameObject);
        if (Explosion != null)
        {
            GameObject exploded = (GameObject)Instantiate(Explosion, pos, Quaternion.identity);
            Destroy(exploded, 1.5f);
        }

        ScoreManager.Instance.SaveGameData();
        DestroyRemainingAstroids();
        DestroyRemainingPowerUps();

        GravityField.Instance.gameObject.SetActive(false);

        GameManager.Instance.ReloadPanel.gameObject.SetActive(true);
    }

    private void DestroyRemainingPowerUps()
    {
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag(Tags.PowerUp);
        if (powerUps == null)
            return;

        foreach (var powerUp in powerUps)
        {
            PowerUpController selfDestructScript = powerUp.GetComponent<PowerUpController>();
            if (selfDestructScript == null)
                return;

            selfDestructScript.DestroyMe();
        }
    }

    private static void DestroyRemainingAstroids()
    {
        GameObject[] astroids = GameObject.FindGameObjectsWithTag(Tags.Astroid);
        if (astroids == null)
            return;

        foreach (var astroid in astroids)
        {
            DestructAstroid selfDestructScript = astroid.GetComponent<DestructAstroid>();
            if (selfDestructScript == null)
                return;

            selfDestructScript.DestroyMe();
        }
    }

    void Heal()
    {
        if (health >= 100)
            return;

        health += 10;

        if (health > 100)
            health = 100;

        healthSlider.value = health;
    }
}