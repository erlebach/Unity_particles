using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control emission rate using a coroutine

public class ColorCoroutineMultiColorEmission : MonoBehaviour {
    public ParticleSystem simpleEmission;
    Gradient colorGradient; // = new Gradient ();
    GradientColorKey[] colorKeys; //= new GradientColorKey[4];
    GradientAlphaKey[] alphaKeys; //= new GradientAlphaKey[2];

    // [SerializeField] allows variable to remain private
    [SerializeField][Range (1, 200)] float emitRate;
    [SerializeField][Range (1, 200)] int nbEmissions;

    private ParticleSystem.Particle[] particles;
    int particleCount;
    IEnumerator coroutine;

    // Start is called before the first frame update
    void Start () {
        // Read max_particles, and use that <<<< TODO
        particles = new ParticleSystem.Particle[10000]; // 10000 is higher than max nb particles used
        setupColorGradient ();

        // STtrt the code each time nbEmissions changes in the inspector
        coroutine = changeColor ();
        StartCoroutine (coroutine);
    }

    void setupColorGradient () {
        colorGradient = new Gradient ();
        colorKeys = new GradientColorKey[4];
        alphaKeys = new GradientAlphaKey[2];
        //setup color Gradient
        colorKeys[0].color = Color.red;
        colorKeys[1].color = Color.blue;
        colorKeys[2].color = Color.green;
        colorKeys[3].color = Color.yellow;
        colorKeys[0].time = .5f;
        colorKeys[1].time = 0.0f;
        colorKeys[2].time = .75f;
        colorKeys[3].time = 1.0f;
        alphaKeys[0].alpha = 0f;
        alphaKeys[1].alpha = 1f;
        alphaKeys[0].time = 0f;
        alphaKeys[1].time = 1f;
        colorGradient.SetKeys (colorKeys, alphaKeys);
    }

    // independent of the framerate
    // All particles emitted have the same color, but the color changes at each emission
    IEnumerator changeColor () {
        while (true) { // run forever
            var main = simpleEmission.main;
            var em = simpleEmission.emission;
            em.enabled = true; // enable emission module

            main.startColor = colorGradient.Evaluate (Random.Range (0f, 1f));
            simpleEmission.Emit (nbEmissions);

            em.enabled = false; // enable emission module

            yield return new WaitForSeconds (1f / emitRate);
        }
    }

}