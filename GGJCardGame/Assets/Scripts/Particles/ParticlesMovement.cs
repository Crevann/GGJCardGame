using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlesMovement : MonoBehaviour
{
    private ParticleSystem mySystemP;
    private ParticleSystem.Particle[] particles;
    int count;
    [SerializeField]Transform targetSoulCoin;
    [SerializeField]Transform targetBodyIngot;
    bool pointAtSoul;

    private void Awake()
    { 
        particles = new ParticleSystem.Particle[10];
    }
    void Start()
    {
        mySystemP = GetComponent<ParticleSystem>();
        mySystemP.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        mySystemP.SetParticles(particles, count);
    }
}
