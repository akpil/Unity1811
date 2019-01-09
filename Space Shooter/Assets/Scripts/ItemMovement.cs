using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum eItemType
{
    powerUP, Life
}
public class ItemMovement : MonoBehaviour {
    public float AngularSpeed;
    public float Speed;
    private Rigidbody rb;
    private PlayerController player;
    public eItemType itemType;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * AngularSpeed;
        rb.velocity = Vector3.back * Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.SendMessage("GetItem", itemType);
            gameObject.SetActive(false);
        }
    }
}
