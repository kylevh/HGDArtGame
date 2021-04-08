using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    public bool useStaticBillboard;
    public bool isDialogPrompter;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(cam.transform);
        }
        else
        {
            transform.rotation = cam.transform.rotation;
        }

        if (!isDialogPrompter)
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(-cam.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -cam.transform.rotation.eulerAngles.z);
        }
    }
}
