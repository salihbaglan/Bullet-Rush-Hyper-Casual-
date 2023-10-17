using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeCollider : MonoBehaviour
{

    public UnityEvent<Collider> onTriggerEnter;
    public UnityEvent<Collider> onTriggerExit;
    public UnityEvent<Collider> onTriggerStay;


    public UnityEvent<Collision> onCollisionEnter;
    public UnityEvent<Collision> onCollisionExit;
    public UnityEvent<Collision> onCollisionStay;

    private void OnTriggerEnter(Collider other) { onTriggerEnter.Invoke(other); }

    private void OnTriggerExit(Collider other) { onTriggerExit.Invoke(other); }
    private void OnTriggerStay(Collider other) { onTriggerStay.Invoke(other); }

    private void OnCollisionEnter(Collision collision) { onCollisionEnter.Invoke(collision); }

    private void OnCollisionExit(Collision collision) { onCollisionExit.Invoke(collision); }
    private void OnCollisionStay(Collision collision) { onCollisionStay.Invoke(collision); }

}
