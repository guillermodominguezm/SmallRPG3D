using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public bool isOpen = false;
    public KeyCode openKey = KeyCode.E;
    private bool playerInRange = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private Collider doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
        doorCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(openKey))
        {
            isOpen = !isOpen;
            doorCollider.enabled = !isOpen; // Desactiva el collider cuando se abre
        }

        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
