using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TE_movement : MonoBehaviour {
    float x, y;
    public ParticleSystem explosion;
    Vector3 craftPos;
    float xtrigger;
    public float speed;
    private IEnumerator explode_coroutine;

    // Start is called before the first frame update
    void Start () {
        craftPos = transform.position;
        xtrigger = craftPos.x + 5;
        //var em = explosion.emission; // the only way is through this variable
        //em.enabled = false; // to be safe
        explode_coroutine = explode ();
    }

    // Update is called once per frame
    void Update () {
        x = Input.GetAxis ("Horizontal");
        y = Input.GetAxis ("Vertical");
        transform.Translate (Vector2.right * speed * Time.deltaTime);
    }
    // Use of coroutine: 
    //    https://docs.unity3d.com/ScriptReference/Coroutine.html
    // Start explosion after two seconds
    IEnumerator explode () {
        yield return new WaitForSeconds (2);
        var em = explosion.emission;
        em.enabled = true;
        var main = explosion.main;
        main.loop = true;
        explosion.transform.position = transform.position;
        // Emission rate: 10 particles/sec
        explosion.Emit (10);
        // Return and 2 seconds later, call coroutine again
        yield return new WaitForSeconds (2);
        em.enabled = false; // the explosion lasts for two seconds
        main.loop = false;
        // exit coroutine for good
    }

    private void OnTriggerEnter2D (Collider2D other) {
        // Call coroutine, exit, wait two seconds 
        // and call again, then explode
        StartCoroutine (explode_coroutine);
    }
}