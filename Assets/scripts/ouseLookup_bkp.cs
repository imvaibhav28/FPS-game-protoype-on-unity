using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook1 : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform CamAxis;

    public Transform PlayerBodyParent;

    public float playerSpeed = 12f;
    float xRotation = 0f;
    // Start is called before the first frame update

    //public Transform PMove;

    void Start()
    {
        //cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 45f);




        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        //float offset = PlayerBodyParent.rotation.y - CamAxis.rotation.y;

        if (Input.GetButton("Vertical"))
        {
            //CamAxis.Rotate(Vector3.up * PlayerBodyParent.transform.rotation.y);
            CamAxis.rotation = PlayerBodyParent.rotation; ///for now this is working let it be(will work on rotation later)
            //Vector3 rotangle=new Vector3(0f, offset, 0f);
            //CamAxis.Rotate(rotangle);
            PlayerBodyParent.Rotate(Vector3.up * mouseX); //only dependency here for toonsoldier
            //CamAxis.Rotate(Vector3.right * PlayerBodyParent.position.x);

        }

        else if (Input.GetButton("Vertical") && Input.GetButton("Horizontal"))
        {
            CamAxis.Rotate(Vector3.up * mouseX);
        }
        else
        {
            CamAxis.Rotate(Vector3.up * mouseX);
        }

        float xCord = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float zCord = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;




    }
}
