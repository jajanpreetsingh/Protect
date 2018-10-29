using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public BlackHole sibling;
    Vector3 currentScale;

    private void Start()
    {
        currentScale = gameObject.transform.localScale;

        StartCoroutine(Scaling());
    }

    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, 30 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AstroidController astroid = other.gameObject.GetComponent<AstroidController>();

        if (astroid == null || astroid.Tunneled)
        {
            PowerUpController power = other.gameObject.GetComponent<PowerUpController>();

            if (power == null || power.Tunneled)
            {
                return;
            }

            power.GoThroughBlackHole(sibling.gameObject.transform.position);
        }

        astroid.GoThroughBlackHole(sibling.gameObject.transform.position);
    }

    IEnumerator Scaling()
    {
        float timer = 2;

        float temp = 0;

        int sign = -1;

        while (true)
        {
            temp = temp + (sign * Time.deltaTime);
            yield return new WaitForEndOfFrame();

            if (temp > timer || temp < 0)
                sign *= -1;

            gameObject.transform.localScale = Utility.GetScalarMultiplied(currentScale, 1 + (temp / timer));
        }
    }
}
