using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt_sounds : MonoBehaviour
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

    public void bolt_sound_ ()
    {
        audioSource.Play();
    }
}
