using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOnDoor : MonoBehaviour
{
    public GameObject OpenDoorText;
    public GameObject CloseDoorText;
    public GameObject AnimeObject;
    public AudioSource DoorOpenSound;
    public AudioSource DoorCloseSound;
    public bool Action = false;
    public bool isClosed;

    // Start is called before the first frame update
    void Start()
    {
        OpenDoorText.SetActive(false);
        CloseDoorText.SetActive(false);
        isClosed = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Action = true;
            if (isClosed)
            {
                OpenDoorText.SetActive(true);
            }
            else
            {
                CloseDoorText.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        OpenDoorText.SetActive(false);
        CloseDoorText.SetActive(false);
        Action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action && isClosed)
            {
                OpenDoorText.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorOpening2");
                DoorOpenSound.Play();
                isClosed = false;
                Action = false;
            }
            if (Action && !isClosed)
            {
                CloseDoorText.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorClosing2");
                DoorCloseSound.Play();
                isClosed = true;
                Action = false;
            }
        }
    }
}

