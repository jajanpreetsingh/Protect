using System.Collections;
using UnityEngine;

public class GravityField : Singleton<GravityField>
{
    private int count;

    private void Start()
    {
        StartCoroutine(FieldTimer());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        AstroidController astroid = other.gameObject.GetComponent<AstroidController>();

        if (astroid == null) return;

        astroid.SetGravitySpeed();
    }

    private IEnumerator FieldTimer()
    {
        float timer = 10;

        float temp = 0;

        while (temp <= timer)
        {
            temp += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(IncreaseField());
        ++count;
    }

    private IEnumerator IncreaseField()
    {
        float incTimer = 2;
        Vector3 currentScale = gameObject.transform.localScale;

        float temp2 = 0;

        while (temp2 <= incTimer)
        {
            temp2 += Time.deltaTime;
            yield return new WaitForEndOfFrame();

            float factor = ((temp2 / incTimer) * .5f) + 1f;
            gameObject.transform.localScale = Utility.GetScalarMultiplied(currentScale, factor);
        }

        StartCoroutine(FieldTimer());
    }
}