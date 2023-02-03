using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSwapping : MonoBehaviour
{
    public Camera camera1, camera2, camera3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // OnCameraChange();
    }

    void OnChangeCamera(InputValue input)
    {
        var (tempRect, tempDepth) = (camera1.rect, camera1.depth);

        camera1.rect   = camera2.rect;
        camera1.depth  = camera2.depth;

        camera2.rect    = camera3.rect;
        camera2.depth   = camera3.depth;

        camera3.rect  = tempRect;
        camera3.depth = tempDepth;
    }
}
