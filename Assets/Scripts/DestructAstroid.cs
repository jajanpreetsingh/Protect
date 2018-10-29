using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DestructAstroid : MonoBehaviour, IDestroyable
{
    public GameObject _explosion;

    private List<string> immuneTo;

    private void Start()
    {
        immuneTo = new List<string> { Tags.PowerUp, Tags.Environment, Tags.GravityField };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (immuneTo.Any(x => string.Compare(x, other.tag, true) == 0))
            return;

        DestroyMe(other);
    }

    public void DestroyMe(Collider2D other = null)
    {
        bool isMoon = other != null && other.tag == Tags.Moon;
        Vector3 pos = gameObject.transform.position;

        Destroy(gameObject);

        if (_explosion != null)
        {
            GameObject exploded = Instantiate(_explosion, pos, Quaternion.identity);
            Destroy(exploded, 1.5f);
        }

        if (isMoon)
            ScoreManager.Instance.AddScore(1);
    }
}