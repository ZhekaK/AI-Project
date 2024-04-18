using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public int yes;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(slotButton, inventory.slots[4].transform);
            yes++;
            Destroy(gameObject);
        }
    } 
}
