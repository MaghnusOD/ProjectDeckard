using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_look : MonoBehaviour
{

    #region variables

    public Transform body;

    // reference to active weapon
    public Transform weapon;

    public int mouse_sen = 10;
    float mouseX, mouseY, xRotation = 0f;


    #endregion

    // Start is called before the first frame update
    void Start()
    {
        

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouse_sen * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouse_sen * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
        

        // for rotating weapon with camera
        weapon.localRotation = transform.localRotation;
    }
}
