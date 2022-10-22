using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Joystick movementStick;
    [SerializeField] Joystick cameraStick;

    [SerializeField] float moveSpeed;

    [SerializeField] Transform cameraPivot;
    Camera camera;
    [SerializeField] float panUpLimit = -26;
    [SerializeField] float panDownLimit = 30;
    public float xRot;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        switch (movementStick.Direction)
        {
            case Joystick.DIRECTION.UP:
                rigidbody.velocity = camera.transform.forward * moveSpeed;
                break;
            case Joystick.DIRECTION.RIGHT:
                rigidbody.velocity = camera.transform.right * moveSpeed;
                break;
            case Joystick.DIRECTION.DOWN:
                rigidbody.velocity = camera.transform.forward * -1 * moveSpeed;
                break;
            case Joystick.DIRECTION.LEFT:
                rigidbody.velocity = camera.transform.right * -1 * moveSpeed;
                break;
            case Joystick.DIRECTION.NONE:
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
                break;
        }


        float yRot;
        switch (cameraStick.Direction)
        {
            case Joystick.DIRECTION.UP:
                xRot = camera.transform.eulerAngles.x - 1;
                if(xRot > 180)
                {
                    xRot = xRot - 360;
                }
                if(xRot < panUpLimit)
                {
                    xRot = panUpLimit;
                }

                camera.transform.rotation = Quaternion.Euler(xRot, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
                break;
            case Joystick.DIRECTION.RIGHT:
                yRot = cameraPivot.eulerAngles.y + 1;
                if(yRot > 360)
                {
                    yRot = 0;
                }
                cameraPivot.rotation = Quaternion.Euler(0, yRot, 0);
                break;
            case Joystick.DIRECTION.DOWN:
                xRot = camera.transform.eulerAngles.x + 1;
                if (xRot > 180)
                {
                    xRot = xRot - 360;
                }
                if (xRot > panDownLimit)
                {
                    xRot = panDownLimit;
                }

                camera.transform.rotation = Quaternion.Euler(xRot, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);
                break;
            case Joystick.DIRECTION.LEFT:
                yRot = cameraPivot.eulerAngles.y - 1;
                if (yRot < -180)
                {
                    yRot = 0;
                }
                cameraPivot.rotation = Quaternion.Euler(0, yRot, 0);
                break;
            case Joystick.DIRECTION.NONE:
                
                break;
        }


    }
}
