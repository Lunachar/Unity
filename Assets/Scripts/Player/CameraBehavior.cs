using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] Transform PlayerBody;
    [SerializeField] float MouseSensetivity = 1;
    [SerializeField] int cameraClampX = 75;

    Vector3 Vector3_Mouse_Direction = new Vector3();

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        Vector3_Mouse_Direction.x -= Input.GetAxis("Mouse Y") * 100 * MouseSensetivity * Time.deltaTime;
        Vector3_Mouse_Direction.y += Input.GetAxis("Mouse X") * 100 * MouseSensetivity * Time.deltaTime;

        Vector3_Mouse_Direction.x = Mathf.Clamp(Vector3_Mouse_Direction.x, -cameraClampX, cameraClampX);

        PlayerBody.rotation = Quaternion.Euler(0, Vector3_Mouse_Direction.y, 0);
        transform.rotation = Quaternion.Euler(Vector3_Mouse_Direction);
    }
}
