using UnityEngine;

public class MoonController : Singleton<MoonController>
{
    private Transform target;
    private int _speedOnPlayerInput; // the speed of rotation
    private int _speedWithoutInput;

    private int _directionOfMovement;

    private Rigidbody2D body;

    private void Start()
    {
        _speedOnPlayerInput = 300;
        _directionOfMovement = 1;
        _speedWithoutInput = 30;

        body = GetComponent<Rigidbody2D>();

        target = Earth.Instance.gameObject.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
            return;

        KeyCode code = InputControllor.GetPressedKey();

        if (code == KeyCode.Mouse0 || code == KeyCode.Return)
            _directionOfMovement = -1 * _directionOfMovement;

        transform.RotateAround(target.position, target.forward, _directionOfMovement * _speedWithoutInput * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        KeyCode code = InputControllor.GetHeldKey();

        if (code == KeyCode.Mouse0 || code == KeyCode.Return)
        {
            transform.RotateAround(target.position, target.forward, _directionOfMovement * _speedOnPlayerInput * Time.deltaTime);
        }
    }

    private Vector3 GetTorqueAmount()
    {
        Vector3 avoidDirection = target.position - transform.position;

        // Create a quaternion (rotation) based on looking down the vector from the player avoid dir
        Quaternion newRotation = Quaternion.LookRotation(avoidDirection * Time.deltaTime);

        //get the angle between transform.forward and target delta
        float angleDiff = Vector3.Angle(transform.forward, avoidDirection);

        // get its cross product, which is the axis of rotation to
        // get from one vector to the other
        Vector3 cross = Vector3.Cross(transform.forward, avoidDirection);

        return cross * angleDiff * _speedWithoutInput;
    }
}