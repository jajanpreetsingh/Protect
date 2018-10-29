using UnityEngine;

public class AstroidController : MonoBehaviour
{
    Transform target;

    public bool Tunneled { get; private set; }

    public float AstroidSpeed { get; private set; }

    public GameObject IceCoat;

    const float normalSpeed = 1.5f;
    const float gravitySpeed = 2;
    const float frozenSpeed = 0.5f;

    // Use this for initialization
    private void Start()
    {
        Tunneled = false;

        if (target == null)
            target = Earth.Instance.gameObject.transform;

        SetAstroidSpeed();
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, AstroidSpeed * Time.deltaTime);
    }

    private void SetAstroidSpeed()
    {
        AstroidSpeed = normalSpeed;
    }

    public void SetGravitySpeed()
    {
        AstroidSpeed = gravitySpeed;
    }

    public void SetAstroidSpeed(float speed)
    {
        AstroidSpeed = speed;
    }

    public void GoThroughBlackHole(Vector3 position)
    {
        if (!Tunneled)
            gameObject.transform.position = position;

        Tunneled = true;
    }

    public void ApplyFreeze()
    {
        IceCoat.SetActive(true);
        SetAstroidSpeed(frozenSpeed);
    }
}