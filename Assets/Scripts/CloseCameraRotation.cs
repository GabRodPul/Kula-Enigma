using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This script sets the camera rotation to match its initial one
/// every frame.
/// This makes it so the camera will follow the GameObject it was
/// assigned to, but won't match its' rotation. Perfect to follow
/// a ball around.
/// </summary>
public class CloseCameraRotation : MonoBehaviour
{
    public GameObject target;
    public float rotX, rotY;

    [SerializeField]
    public Vector3 offsetPos, offsetRot;

    // Start is called before the first frame update
    void Start()
    {
        // offsetPos = new Vector3(0, -3f, 4);        
        // offsetPos = transform.position;
        // offsetRot = new Vector3(20, 0, 0);        
        transform.position = target.transform.position - offsetPos;
        transform.eulerAngles = offsetRot;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(target.transform.position - offsetPos);
    }

    void OnLook(InputValue input)
    {
        var rotation = input.Get<Vector2>();
        rotX = rotation.x;
        rotY = rotation.y;
    }

    void FixedUpdate()
    {
        transform.position = target.transform.position - offsetPos;
        transform.eulerAngles = offsetRot;        
        // transform.RotateAround(
        //     target.transform.position, 
        //     // new Vector3(rotX, 0, rotY),
        //     Vector3.up,
        //     Time.deltaTime * 5
        // );
    }
}
