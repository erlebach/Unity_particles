using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TE_TriggerExplosion : MonoBehaviour {
    public ParticleSystem triggerExplosion;

    // Start is called before the first frame update
    void Start () {
        triggerExplosion.gameObject.SetActive (true);
    }

    void explode () {
        var em = triggerExplosion.emission;
        em.enabled = true;
        triggerExplosion.Emit (1000); // NOT SHOWING IN GAME
    }

    void OnTriggerEnter2D (Collider2D other) {
        // Light up the trigger object
        explode ();
    }

    void OnTriggerExit2D (Collider2D other) {
        // disable trigger object, not used
    }
}