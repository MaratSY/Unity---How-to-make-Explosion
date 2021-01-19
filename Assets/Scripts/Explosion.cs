using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float force;
    [SerializeField] private float upwords;
    public GameObject canvas;

    void Update()
    {
        Exploud();
    }

    void Exploud()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            canvas.SetActive(false);
            foreach (var collider in colliders)
            {
                Rigidbody rigidbody = collider.attachedRigidbody;
                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(force, transform.position, radius, upwords, ForceMode.Impulse);
                }               
            }
            
            Destroy(gameObject);
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
