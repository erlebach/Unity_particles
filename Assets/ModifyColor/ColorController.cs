using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {
    public ParticleSystem simpleEmission;
    Gradient colorGradient; // = new Gradient ();
    GradientColorKey[] colorKeys; //= new GradientColorKey[4];
    GradientAlphaKey[] alphaKeys; //= new GradientAlphaKey[2];

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
    }

    // IEnumerator 
    void changeColor (int nb_emit, float waitTime) {
        var main = simpleEmission.main;

        var em = simpleEmission.emission;
        em.enabled = true;
        simpleEmission.Emit (1);
        main.startColor = colorGradient.Evaluate (Random.Range (0f, 1f));
        return;
    }

    // Update is called once per frame
    void Update () {
        changeColor (1, 1f); // emission every frame
    }
}