using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input : MonoBehaviour
{
    public Vector2 moveDirection {get; private set;}
    public bool isJump {get; private set;}
    public bool isSplit {get; private set;}


    private void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        SetJumpInput(value.isPressed);
    }

    private void OnSplit(InputValue value)
    {
        SetSplitInput(value.isPressed);
    }

    public void SetJumpInput(bool jumpPressed)
    {
        isJump = jumpPressed;
    }

    public void SetSplitInput(bool splitPressed)
    {
        isSplit = splitPressed;
    }
}
