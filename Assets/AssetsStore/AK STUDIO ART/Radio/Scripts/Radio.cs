using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField]
    private bool TurnOn;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Light _light;
    private void Awake()
    {
        _light.gameObject?.SetActive(false);
    }
    public void ToogleRadio()
    {
        TurnOn = !TurnOn;
        if (TurnOn)
        {
            _audioSource?.Play();
            _light.gameObject?.SetActive(true);
        }
        else
        {
            _audioSource?.Stop();
            _light.gameObject?.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
