using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorTheif : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private string _tag;
    private bool inTrigger;
    private Transform _target;
    private void Start()
    {
        _target = player.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            _target = other.transform;
            inTrigger = true;

        }
    }
  
    public bool isDetected() { return inTrigger; }
    public void SetDetected(bool flag) => inTrigger = flag;
}
