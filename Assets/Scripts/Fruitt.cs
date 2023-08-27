using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruitt : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;
    
    private Rigidbody fruitrb;
    private Collider fruitcollider;

    private ParticleSystem juiceparticleEffect;
    private void Awake()
    {
        fruitrb = GetComponent<Rigidbody>();
        fruitcollider = GetComponent<Collider>();
        juiceparticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        FindObjectOfType<GameManager>().IncreaseScore();
        whole.SetActive(false);
        sliced.SetActive(true);
        
        fruitcollider.enabled = false;
        juiceparticleEffect.Play();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// ugh ılovegoogle
        sliced.transform.rotation=Quaternion.Euler(0f,0f,angle);// slice için
        
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices)
        {
            slice.velocity = fruitrb.velocity;
            slice.AddForceAtPosition(direction*force,position,ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade blade = other.GetComponent<Blade>();
            Slice(blade.direction,blade.transform.position,blade.sliceforce);
        }
    }
}
