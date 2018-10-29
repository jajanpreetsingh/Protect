using System;
using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    public Material FreezeMaterial;
    public Material AstroidMaterial;

    public GameObject FreezePowerUp;
    public GameObject CoinsPowerUp;

    private float _timeElapsed;
    private float _powerUpTimeUp;

    private void Start()
    {
        _timeElapsed = 0.0f;
        _powerUpTimeUp = 5.0f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void Update()
    {
        if (_timeElapsed < _powerUpTimeUp)
        {
            _timeElapsed += Time.deltaTime;
            return;
        }

        GameObject[] astroids = GameObject.FindGameObjectsWithTag(Tags.Astroid);
        if (astroids == null)
            return;

        foreach (var astroid in astroids)
        {
            astroid.GetComponent<Renderer>().material = AstroidMaterial;
            astroid.GetComponent<AstroidController>().SetAstroidSpeed(1.5f);
        }
    }

    public void DestroyMe()
    {
        throw new NotImplementedException();
    }
}