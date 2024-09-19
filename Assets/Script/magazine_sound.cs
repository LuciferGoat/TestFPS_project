using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magazine_sound : MonoBehaviour
{
    [SerializeField] 
    public AudioSource audioSource_Set;

     [SerializeField] 
    public AudioSource audioSource_drop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetM_sound ()
    {
        audioSource_Set.Play();
    }
    public void DropM_sound ()
    {
        audioSource_drop.Play();
    }
}
