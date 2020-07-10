using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class trigger : MonoBehaviour
{
    public Quaternion startrotation;
    public Vector3 startrposition;
    public Button[] buttons = new Button[6];
    public GameManager gm;
    public bool locked = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        startrposition = this.gameObject.transform.position;
        startrotation = this.gameObject.transform.rotation;
        

        if (this.gameObject.tag == "spine")
        {
            if (other.gameObject.tag == "stopspineup")
            {
                gm.switchtospine();
                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[5].GetComponent<Button>().interactable = true;
                
            }
            else if (other.gameObject.tag == "stopspinedown")
            {
                gm.switchtospine();

                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;

                gm.collided = true;
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[5].GetComponent<Button>().interactable = true;

            }
        }
        if ((this.gameObject.tag == "head") && (gm.mode == "head"))
        {
            if (other.gameObject.tag == "stophead")
            {
                gm.switchtohead();

                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[2].GetComponent<Button>().interactable = true;
            }
            else if (other.gameObject.tag == "spine")
            {
                gm.switchtohead();

                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[5].GetComponent<Button>().interactable = true;
            }

        }

        if (this.gameObject.tag == "legs" && (gm.mode == "legs" || gm.mode == "body"))
        {
            if (other.gameObject.tag == "stoplegsup")
            {
                gm.switchtolegs();
                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[4].GetComponent<Button>().interactable = true;
                buttons[1].GetComponent<Button>().interactable = true;

            }
            else if (other.gameObject.tag == "stoplegsdown")
            {
                gm.switchtolegs();

                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[4].GetComponent<Button>().interactable = true;
            }
            else if (other.gameObject.tag == "spine")
            {
                gm.switchtolegs();


                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[4].GetComponent<Button>().interactable = true;

            }
            else if (other.gameObject.tag == "body")
            {
                gm.switchtolegs();
                //  this.gameObject.transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z - 2);
                locked = true;
                InvokeRepeating("lockedlegs", 2,0.5f);
                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[4].GetComponent<Button>().interactable = true;
            }
        }
        if (this.gameObject.tag == "body")
        {
            if (other.gameObject.tag == "stopbody")
            {
                gm.switchtobody();

                gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[3].GetComponent<Button>().interactable = true;
            }

            if (other.gameObject.tag == "spine")
            {
                
             gm.switchtobody();


             gm.countermotion = 0;
                gm.up = false;
                gm.down = false;
                gm.collided = true;
                buttons[0].GetComponent<Button>().interactable = true;
                buttons[3].GetComponent<Button>().interactable = true;

            }
        }
        if (this.gameObject.tag == "stophead" && other.gameObject.tag == "stopbody")
        {

        }


    }
    public void OnTriggerStay(Collider other)
    {
       
        if (this.gameObject.tag == "spine")
        {
            if (other.gameObject.tag == "stopspineup") {
                buttons[1].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
            }
            else if (other.gameObject.tag == "stopspinedown")
            {
                buttons[0].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
            }
        }
        if ((this.gameObject.tag == "head")&&(gm.mode=="head"))
        {
            if (other.gameObject.tag == "stophead") 
            {
                buttons[0].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.up = false;
            }
            else if (other.gameObject.tag == "spine")
            {
                buttons[1].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.down = false;
            }
            
        }

        if(this.gameObject.tag=="legs" && (gm.mode == "legs"||gm.mode=="body")){
            if (other.gameObject.tag == "stoplegsup")
            {
                //gm.switchtolegs();
                buttons[0].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.up = false;
            }
            else if (other.gameObject.tag == "stoplegsdown")
            {
              //  gm.switchtolegs();
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;

                buttons[4].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.down = false;
            }
            else if (other.gameObject.tag == "spine")
            {
                buttons[1].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;

                buttons[4].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.down = false;
            }
            else if (other.gameObject.tag == "body")
            {
                //  gm.switchtolegs();
                buttons[1].GetComponent<Button>().interactable = true;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[3].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;

                buttons[4].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.down = false;
            }
        }
        if(this.gameObject.tag=="body")
        {
            if (other.gameObject.tag == "stopbody")
            {
                buttons[0].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;

                buttons[3].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.up = false;
            }
            if (other.gameObject.tag == "spine")
            {

                buttons[1].GetComponent<Button>().interactable = false;
                buttons[2].GetComponent<Button>().interactable = false;
                buttons[4].GetComponent<Button>().interactable = false;
                buttons[5].GetComponent<Button>().interactable = false;

                buttons[3].GetComponent<Button>().interactable = true;
                this.gameObject.transform.position = startrposition;
                this.gameObject.transform.rotation = startrotation;
                gm.down = false;

            }
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
      foreach(Button button in buttons)
        {
            button.GetComponent<Button>().interactable = true;

            gm.collided = false;
        }
        locked = false;
    }
    public void lockedlegs()
    {
        if (locked)
        {
            gm.legs.transform.RotateAround(gm.anchorbodylegs.transform.position, Vector3.forward,2.5f);
        }
    }
}
