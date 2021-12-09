using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float MoveInput;
    public static bool JumpInput;
    private void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");
        JumpInput = Input.GetButtonDown("Jump");
    }

}