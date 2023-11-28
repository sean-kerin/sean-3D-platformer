using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

public class cameramovement : MonoBehaviour
{
    public PlayerMovement player;
    private float sensitivity = 500f;
    private float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;

    private void Start()
    {
        this.verticalRotation = this.transform.localEulerAngles.x;
        this.horizontalRotation = this.transform.eulerAngles.y;
    }

    private void Update()
    {
        Look();
        Debug.DrawRay(this.transform.position, this.transform.forward * 2, Color.red);
    }

    private void Look()
    {
        float mouseVertical = -Input.GetAxis("Mouse Y");
        float mouseHorizontal = Input.GetAxis("Mouse X");

        this.verticalRotation += mouseVertical * sensitivity * Time.deltaTime;
        this.horizontalRotation += mouseHorizontal * sensitivity * Time.deltaTime;

        this.verticalRotation += Mathf.Clamp(this.verticalRotation, -this.clampAngle, clampAngle);

        this.transform.localRotation = Quaternion.Euler(this.verticalRotation, 0f, 0f);
        this.player.transform.rotation = Quaternion.Euler()
    }
}