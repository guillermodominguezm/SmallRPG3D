using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyOnDoor : MonoBehaviour
{
    public GameObject Instruction1;
    public GameObject Instruction2;
    public GameObject AnimeObject;
    public AudioSource DoorOpenSound;
    public AudioSource DoorCloseSound;
    public bool Action = false;
    public bool isClosed;

    // Start is called before the first frame update
    void Start()
    {
        Instruction1.SetActive(false);
        Instruction2.SetActive(false);
        isClosed = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Action = true;
            if (isClosed)
            {
                Instruction1.SetActive(true);
            }
            else
            {
                Instruction2.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction1.SetActive(false);
        Instruction2.SetActive(false);
        Action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action && isClosed)
            {
                Instruction1.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorOpening2");
                DoorOpenSound.Play();
                isClosed = false;
                Action = false;
            }
            if (Action && !isClosed)
            {
                Instruction2.SetActive(false);
                AnimeObject.GetComponent<Animator>().Play("DoorClosing2");
                DoorCloseSound.Play();
                isClosed = true;
                Action = false;
            }
        }
    }
}
