using System;
using System.Linq;
using UnityEngine;

public class PowerUpController : MonoBehaviour, IDestroyable
{
    public GameObject Explosion;
    GameObject target;

    public bool Tunneled { get; private set; }

    Vector3 _targetPosition;
    float _speed;
    const int powerUpScore = 5;

    private void Start()
    {
        Tunneled = false;

        target = Earth.Instance.gameObject;

        if (target == null)
        {
            Destroy(this);
            return;
        }
        _speed = 2;

        //Ray rayTowardsEarth = new Ray(transform.position, Earth.transform.position);

        //int environmentLayer = LayerMask.GetMask(LayerMasks.Environment);

        //RaycastHit environmentHit;

        //if (Physics.Raycast(rayTowardsEarth, out environmentHit, 9000, environmentLayer))
        //{
        //    _targetPosition = environmentHit.point;
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tags.Earth)
            DestroyMe(other);

        if (other.tag == Tags.Moon)
        {
            ApplyFreezeToAll();
            ScoreManager.Instance.AddScore(powerUpScore);
            DestroyMe();
        }

        if (other.tag == Tags.Astroid)
        {
            AstroidController a = other.GetComponent<AstroidController>();
            a.ApplyFreeze();
            DestroyMe();
        }
    }

    private void ApplyFreezeToAll()
    {
        AstroidController[] astroids = FindObjectsOfType<AstroidController>();

        astroids.ToList().ForEach(x => x.ApplyFreeze());

        DestroyMe();
    }

    private void Update()
    {
        if (_targetPosition != null)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
    }

    public void GoThroughBlackHole(Vector3 position)
    {
        if (!Tunneled)
            gameObject.transform.position = position;

        Tunneled = true;

    }

    public void DestroyMe(Collider2D other = null)
    {
        Vector3 pos = gameObject.transform.position;

        Destroy(gameObject);
        if (Explosion != null)
        {
            GameObject exploded = Instantiate(Explosion, pos, Quaternion.identity);
            Destroy(exploded, 1.5f);
        }
    }
}