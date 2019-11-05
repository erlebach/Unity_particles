using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// other ideas: a tractor beam (Startrek)

public class CollisionAction : MonoBehaviour {
    [SerializeField][Range (0, 10)] float force; // force particle applies to object upon Collision
    public ParticleSystem myParticleSystem;
    public float colliderForce;

    // Start is called before the first frame update
    void Start () {
        var collision = myParticleSystem.collision;
        collision.colliderForce = colliderForce;
    }

    // Update is called once per frame
    // seems like a waste of computer time. Best to 
    // check whether the inspector window changed or use coroutine every .1 sec
    void Update () {
        // Update collisions 30 or 60 times a second
        //var collision = particleSystem.collision;
        //collision.colliderForce = colliderForce;
    }

    void OnValidate () {
        // Update collisions only when value changes in the inspector
        var collision = myParticleSystem.collision;
        collision.colliderForce = colliderForce;
    }
}