using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject obj;
    public float speed = 3.5f;
    float sensitivity = 15f;

    float minFov = 50;
    float maxFov = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(obj.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            transform.RotateAround(obj.transform.position, transform.right, Input.GetAxis("Mouse Y") * speed);
            obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, Camera.main.transform.rotation, 10 * Time.deltaTime);
        }

        // Zooming
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
