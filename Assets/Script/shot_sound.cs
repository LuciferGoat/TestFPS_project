using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_sound : MonoBehaviour
{
    [SerializeField] 
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shot_B_sound ()
    {
        audioSource.Play();
    }
}
