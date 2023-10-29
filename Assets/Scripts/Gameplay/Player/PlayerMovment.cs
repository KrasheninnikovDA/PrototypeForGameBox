
using UnityEngine;

[RequireComponent(typeof(PlaerInput))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField, Range(0, 10f)] private float forceGravity;
    private PlaerInput input;
    private CharacterController characterController;
    private Vector3 gravity;

    private void Start()
    {
        input = GetComponent<PlaerInput>();
        characterController = GetComponent<CharacterController>();
        gravity = new Vector3(0,-forceGravity,0);
    }

    private void Update()
    {
        characterController.Move(input.Move);
        characterController.Move(gravity);
    }
}
