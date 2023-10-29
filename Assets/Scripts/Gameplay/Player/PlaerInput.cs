using UnityEngine;
using GameConstants;

public class PlaerInput : MonoBehaviour
{
    [SerializeField, Range(0f, 0.1f)] private float movmentSpeed;

    private Vector3 move;
    private bool isActivation;
    public Vector3 Move { get => move; }
    public bool IsActivation { get => isActivation; }

    private void Update()
    {
        move = TrackMovment();
        isActivation = CheckPressKeyActivation();
    }

    private Vector3 TrackMovment()
    {
        float x = Input.GetAxis(Axis.horizontal) * -movmentSpeed;
        float z = Input.GetAxis(Axis.vertical) * -movmentSpeed;
        Vector3 movment = new Vector3(x, 0, z);
        return movment;
    }

    private bool CheckPressKeyActivation()
    {
        return Input.GetKey(KeyCode.E);
    }
}
