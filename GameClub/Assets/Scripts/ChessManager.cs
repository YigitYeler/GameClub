using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    Animator anim;
    public GameObject PressE;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PressE.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && Input.GetKey("e"))
        {
            anim.SetBool("IsOpen", true);
            Destroy(gameObject, 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PressE.SetActive(false);
        }
    }
}
