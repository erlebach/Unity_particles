using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_AircraftController : MonoBehaviour {
    Camera myCamera;
    Vector3 mousePos, p, q;
    public float speed;

    // Start is called before the first frame update
    void Start () {
        // Find a GameObject in the Hierarchy. Since there is only one camera ...
        myCamera = FindObjectOfType<Camera> ();
    }

    // Update is called once per frame
    void Update () {
        // left mouse button
        if (Input.GetMouseButton (0)) {
            Vector3 pos = GetPositionInWorldCoordinates ();
            pos.z = 0f;
            // rotate aircraft towards pos
            // How to handle a 2D lookat function. 
            // https://answers.unity.com/questions/585035/lookat-2d-equivalent-.html
            // transform.right is the red axis in world coordinates
            transform.position = Vector3.MoveTowards (transform.position, pos, speed * Time.deltaTime);
            transform.right = pos - transform.position;
            print (transform.position);
        }
    }

    Vector3 GetPositionInWorldCoordinates () {
        mousePos = Input.mousePosition;
        // transform from mouse coordinates to viewport coordinates [0,1] in both directions
        p = myCamera.ScreenToViewportPoint (mousePos);
        // transoform from viewport coordinates tow world cordinates
        return myCamera.ViewportToWorldPoint (p);
    }
}