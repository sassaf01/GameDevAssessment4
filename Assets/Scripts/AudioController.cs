using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource startUpMusic;

    [SerializeField]
    public AudioSource backgroundMusic;

    [SerializeField]
    public AudioSource pacmanMovement;
    // Start is called before the first frame update
    void Start()
    {
        startUpMusic.Play();
        backgroundMusic.PlayDelayed(startUpMusic.clip.length);
        pacmanMovement.PlayDelayed(startUpMusic.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
