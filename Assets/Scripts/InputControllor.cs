using UnityEngine;

public class InputControllor
{
    public static KeyCode GetPressedKey()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            return KeyCode.UpArrow;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            return KeyCode.DownArrow;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return KeyCode.LeftArrow;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            return KeyCode.RightArrow;

        if (Input.GetKeyDown(KeyCode.Space))
            return KeyCode.Space;

        if (Input.GetKeyDown(KeyCode.Return))
            return KeyCode.Return;

        if (Input.GetKeyDown(KeyCode.A))
            return KeyCode.A;

        if (Input.GetKeyDown(KeyCode.S))
            return KeyCode.S;

        if (Input.GetKeyDown(KeyCode.D))
            return KeyCode.D;

        if (Input.GetKeyDown(KeyCode.F))
            return KeyCode.F;

        if (Input.GetKeyDown(KeyCode.P))
            return KeyCode.P;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            return KeyCode.LeftShift;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            return KeyCode.Mouse0;

        if (Input.GetKeyDown(KeyCode.Mouse1))
            return KeyCode.Mouse1;

        if (Input.GetKeyDown(KeyCode.Mouse2))
            return KeyCode.Mouse2;

        if (Input.GetKeyDown(KeyCode.Mouse3))
            return KeyCode.Mouse3;

        if (Input.GetKeyDown(KeyCode.Mouse4))
            return KeyCode.Mouse4;

        if (Input.GetKeyDown(KeyCode.Mouse5))
            return KeyCode.Mouse5;

        if (Input.GetKeyDown(KeyCode.Mouse6))
            return KeyCode.Mouse6;

        return KeyCode.DoubleQuote;
    }

    public static KeyCode GetHeldKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            return KeyCode.UpArrow;

        if (Input.GetKey(KeyCode.DownArrow))
            return KeyCode.DownArrow;

        if (Input.GetKey(KeyCode.LeftArrow))
            return KeyCode.LeftArrow;

        if (Input.GetKey(KeyCode.RightArrow))
            return KeyCode.RightArrow;

        if (Input.GetKey(KeyCode.Space))
            return KeyCode.Space;

        if (Input.GetKey(KeyCode.Return))
            return KeyCode.Return;

        if (Input.GetKey(KeyCode.A))
            return KeyCode.A;

        if (Input.GetKey(KeyCode.S))
            return KeyCode.S;

        if (Input.GetKey(KeyCode.D))
            return KeyCode.D;

        if (Input.GetKey(KeyCode.F))
            return KeyCode.F;

        if (Input.GetKey(KeyCode.P))
            return KeyCode.P;

        if (Input.GetKey(KeyCode.LeftShift))
            return KeyCode.LeftShift;

        if (Input.GetKey(KeyCode.Mouse0))
            return KeyCode.Mouse0;

        if (Input.GetKey(KeyCode.Mouse1))
            return KeyCode.Mouse1;

        if (Input.GetKey(KeyCode.Mouse2))
            return KeyCode.Mouse2;

        if (Input.GetKey(KeyCode.Mouse3))
            return KeyCode.Mouse3;

        if (Input.GetKey(KeyCode.Mouse4))
            return KeyCode.Mouse4;

        if (Input.GetKey(KeyCode.Mouse5))
            return KeyCode.Mouse5;

        if (Input.GetKey(KeyCode.Mouse6))
            return KeyCode.Mouse6;

        return KeyCode.DoubleQuote;
    }
}