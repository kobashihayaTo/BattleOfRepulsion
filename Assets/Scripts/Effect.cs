using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public ParticleSystem ParticleEffect;
    // Start is called before the first frame update
    void Start()
    {
        ParticleEffect= ParticleEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleEffect.Play();
    }
}
