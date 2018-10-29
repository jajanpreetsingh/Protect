using UnityEngine;

public class DestroyOnExitScene : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
            Destroy(other.gameObject);
    }
}