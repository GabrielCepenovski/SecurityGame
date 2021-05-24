using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Area : MonoBehaviour
{
    [SerializeField] private UnityEvent _penetration;
    [SerializeField] private UnityEvent _escaped;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
            _penetration.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
            _escaped.Invoke();
    }
}
