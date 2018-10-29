using UnityEngine;

internal interface IDestroyable
{
    void DestroyMe(Collider2D other = null);
}