using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 movement;

    [SerializeField]
    private float speed = 5f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(
            movement.x,
            0f,
            movement.y
        );

        controller.Move(direction * speed * Time.deltaTime);
    }
}