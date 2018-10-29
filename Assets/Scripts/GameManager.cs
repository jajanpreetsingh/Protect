using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject Astroid;
    public GameObject[] PowerUp;
    GameObject earth;

    float _astroidSpawnDistance = 15;
    float _spawnDistanceSquare;

    float _delayInSpawningAstroid;
    float _delayInSpawingPowerUp;
    float _timeElapsedForAstroidSpawn;
    float _timeElapsedForPowerUp;

    const float levelTimer = 100;

    int zComponent = 1;

    public Text LevelTimer;
    public RectTransform NextLevl;
    public RectTransform ReloadPanel;

    private void Start()
    {
        _spawnDistanceSquare = Mathf.Pow(_astroidSpawnDistance, 2.0f);
        _delayInSpawningAstroid = 1.0f;
        _delayInSpawingPowerUp = 5.0f;

        earth = Earth.Instance.gameObject;

        StartCoroutine(StartSpawningAstroids());
        StartCoroutine(StartSpawningPowerUps());

        StartCoroutine(StartLevelTimer());
    }

    private IEnumerator StartLevelTimer()
    {
        float temp = levelTimer;

        while (temp >= 0 && earth != null)
        {
            temp -= Time.deltaTime;
            yield return new WaitForEndOfFrame();

            if (LevelTimer != null)
                LevelTimer.text = string.Format("Time : {0}", (int)temp);

            if (temp <= 0)
            {
                StopCoroutine(StartSpawningAstroids());
                StopCoroutine(StartSpawningPowerUps());

                NextLevl.gameObject.SetActive(true);
            }
        }

        StopCoroutine(StartLevelTimer());
    }

    private void SpawnAstroid()
    {
        float random = UnityEngine.Random.Range(-_astroidSpawnDistance, _astroidSpawnDistance);
        zComponent = (int)random % 2 == 0 ? -1 : 1;

        //the circle x^2 + z^2 = 20^2 = 400 is my astroid belt
        Vector3 randomPosition = new Vector3
        {
            x = random,
            y = 1,
            z = Mathf.Pow(_spawnDistanceSquare - Mathf.Pow(random, 2.0f), 0.5f) * zComponent
        };

        GameObject.Instantiate(Astroid, randomPosition, Quaternion.identity);
    }

    private void SpawnPowerUp()
    {
        if (PowerUp == null || PowerUp.Length <= 0) return;

        int randomPowerUp = UnityEngine.Random.Range(0, PowerUp.Length);

        float random = UnityEngine.Random.Range(-10, 10);
        zComponent = (int)random % 2 == 0 ? -1 : 1;

        Vector3 randomPosition = new Vector3
        {
            x = random,
            y = 1,
            z = Mathf.Pow(100 - Mathf.Pow(random, 2.0f), 0.5f) * zComponent
        };

        GameObject.Instantiate(PowerUp[randomPowerUp], randomPosition, Quaternion.identity);
    }

    public IEnumerator StartSpawningAstroids()
    {
        float temp = 0;

        while (temp <= _delayInSpawningAstroid && earth != null)
        {
            temp += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            if (temp > _delayInSpawningAstroid)
            {
                temp = 0;
                SpawnAstroid();
            }
        }
    }

    public IEnumerator StartSpawningPowerUps()
    {
        float temp = 0;

        while (temp <= _delayInSpawingPowerUp && earth != null)
        {
            temp += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            if (temp > _delayInSpawingPowerUp)
            {
                temp = 0;
                SpawnPowerUp();
            }
        }
    }

    public void LoadNextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}