using UnityEngine;

public class DestroyDebrisOnContact : MonoBehaviour
{
    public GameObject _explosion;

    private void OnTriggerEnter(Collider other)
    {
        DestroyMe();
    }

    public void DestroyMe()
    {
        if (gameObject != null)
        {
            if (_explosion != null)
            {
                Destroy(gameObject);
                GameObject exploded = (GameObject)Instantiate(_explosion, gameObject.transform.position, Quaternion.identity);
                Destroy(exploded, 1.5f);
            }
        }
    }
}