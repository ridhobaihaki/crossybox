using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField, Range(0, 10)] float rotationSpeed; 

    public int Value { get => value; }

    public void Collected() 
    {
        GetComponent<Collider>().enabled = false;
        rotationSpeed *= 10;
        this.transform.DOJump(this.transform.position, 1.5f, 1, 0.4f).onComplete = SelfDestruction;
    }

    private void SelfDestruction()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 360 * rotationSpeed * Time.deltaTime, 0);
    }
}
