using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Control emission rate using a coroutine

public class ColorCoroutine : MonoBehaviour {
    public ParticleSystem simpleEmission;
    Gradient colorGradient; // = new Gradient ();
    GradientColorKey[] colorKeys; //= new GradientColorKey[4];
    GradientAlphaKey[] alphaKeys; //= new GradientAlphaKey[2];
    public int nbEmissions;

    // Start is called before the first frame update
    void Start () {
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
        // STart the code each time nbEmissions changes in the inspector
        IEnumerator coroutine = changeColor (nbEmissions);
        StartCoroutine (coroutine);
    }

    // Coroutine: notice: not called in update(). I can control the frequency of calls
    // independent of the framerate
    // repeats 10 times
    // All particles emitted have the same color, but the color changes at each emission
    IEnumerator changeColor (int nb_emit) {
        for (int i = 0; i < 10; i++) {
            var main = simpleEmission.main;
            var em = simpleEmission.emission;
            em.enabled = true;
            simpleEmission.Emit (nb_emit);
            main.startColor = colorGradient.Evaluate (Random.Range (0f, 1f));
            yield return new WaitForSeconds (1f);
        }
    }

}