using UnityEngine;

public class LightFollow : MonoBehaviour
{
    [Header("Main Camera:")]
    public Camera m_camera;

    [Header("Transform Ref:")]
    public Transform lightHolder;
    public Transform lightPivot;

    [Header("Physics Ref:")]
    public Rigidbody2D m_rigidbody;

    [Header("Rotation:")]
    [SerializeField] private bool rotateOverTime = true;
    [Range(0, 60)] [SerializeField] private float rotationSpeed = 30;

    private void Start()
    {

    }

    private void Update()
    {
        //sets variable for mouse position on screen
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        RotateLight(mousePos, true);
    }

    void RotateLight(Vector3 lookPoint, bool allowRotationOverTime)
    {
        Vector3 distanceVector = lookPoint - lightPivot.position;

        //sets the angle from object to mouse position
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        if (rotateOverTime && allowRotationOverTime)
        {
            //lower the rotation speed, slower the light catches up to your mouse
            lightPivot.rotation = Quaternion.Lerp(lightPivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        else
        {
            //rotates the light with cursor
            lightPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

