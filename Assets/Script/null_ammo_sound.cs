using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class null_ammo_sound : MonoBehaviour
{[SerializeField] 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void null_ammo_sound_ ()
    {
        audioSource.Play();
    }
}
