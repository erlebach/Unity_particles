using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserbeam : MonoBehaviour {
    public ParticleSystem myParticleSystem;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start () {;
        ps = myParticleSystem;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton ("Fire1")) {
            print ("Fire1");
            ps.Emit (1);
        }
    }
}