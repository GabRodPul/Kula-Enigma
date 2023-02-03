using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetExit(false);
    }

    void SetExit(bool value)
    {
        var box = GetComponent<BoxCollider>();
        box.isTrigger = value;
        box.enabled   = value;
        
        GetComponent<MeshRenderer>().enabled  = value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Globals.PickupsLeft == 0) SetExit(true);
    }
}
