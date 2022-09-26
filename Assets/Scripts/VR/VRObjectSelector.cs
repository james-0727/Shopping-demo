using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRObjectSelector : MonoBehaviour
{
    [SerializeField] public UnityEvent OnSelected;
    [SerializeField] public UnityEvent OnUnSelected;
    public bool _Selected;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "XR Ray")
        {
            _Selected = true;
            OnSelected.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "XR Ray")
        {
            _Selected = false;
            OnUnSelected.Invoke();
        }
    }
}
