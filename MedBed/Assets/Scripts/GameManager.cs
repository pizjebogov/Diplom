using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject head;
    public GameObject body;
    public GameObject legs;
    public GameObject spine;
    public string mode;
    public GameObject anchorheadbody;
    public GameObject anchorbodylegs;
    public bool up=false;
    public bool down = false;
    public Material normal;
    public Material glowing;
    public float rotationspeed;
    public float countermotion;
    public Text textforhead;
    public Text textforbody;
    public Text textforlegs;
    public Text textforspine;
    public float fixedangle;
    public bool mooving;
    public bool collided;
    public Button[] buttons = new Button[10];
    public Slider slide;
    public GameObject rightside;
    public GameObject leftside;
    public Text general;
    public string collisioned;
    public float forinf;
    public bool cycling;
    public Button cyclebut;
    void Start()
    {
        InvokeRepeating("countermove", 0.1f, 0.1f);
        InvokeRepeating("infinitycycle", 0.1f, 0.1f);
        mooving = false;
        collided = false;
        leftside.SetActive(true);
        rightside.SetActive(true);
        cyclebut.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        leftside.GetComponent<LineRenderer>().SetPosition(0, leftside.transform.position);
        leftside.GetComponent<LineRenderer>().SetPosition(1, head.transform.position + new Vector3(0, 0.25f));
        rightside.GetComponent<LineRenderer>().SetPosition(0, rightside.transform.position);
        rightside.GetComponent<LineRenderer>().SetPosition(1, legs.transform.position + new Vector3(0,0.25f));
        rotationspeed = slide.value;
        if (rotationspeed == 0)
        {
            foreach (Button button in buttons)
            {
                countermotion = 0;
                button.GetComponent<Button>().interactable = true;
            }
        }
        //legs.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(legs.transform.localEulerAngles.z, 0, 90));
       /* textforhead.text = "Head " +Math.Round( (head.transform.localEulerAngles.z>180? -(head.transform.localEulerAngles.z-360) : -head.transform.localEulerAngles.z),1) + " angles";
        textforbody.text = "Body " + Math.Round((body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z)) + " angles";
        textforlegs.text = "Legs " + Math.Round((legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z)) + " angles";
        textforspine.text = "Spine " + Math.Round((spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z)) + " angles";*/
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (Input.GetMouseButton(0))
            {
                switch (hit.transform.gameObject.tag)
                {
                    case ("head"):
                        general.text = "Name:Head\n" + "Local Coordinates:" + Math.Round((head.transform.localEulerAngles.z > 180 ? -(head.transform.localEulerAngles.z - 360) : -head.transform.localEulerAngles.z), 1);
                        break;
                    case ("body"):
                        general.text = "Name:Body\n" +"Local Coordinates:" + Math.Round((body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z));
                        break;
                    case ("legs"):
                        general.text = "Name:Legs\n" +  "Local Coordinates:" + Math.Round((legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z));
                        break;
                    case ("spine"):
                        general.text = "Name:Spine\n" + "Local Coordinates:" + Math.Round((spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z));
                        break;
                }
            }
            else
            {
                general.text = "Speed:" + Math.Round(rotationspeed / 10, 1) + "\n" + "Current Mode:" + mode + "\n" + collisioned;
            }
        }
        else
        {
            general.text = "Speed:" + Math.Round(rotationspeed / 10, 1) + "\n" + "Current Mode:" + mode + "\n" + collisioned; 
        }


        /*if (mode == "Cycling")
        {
            foreach (Button button in buttons)
            {
                button.GetComponent<Button>().interactable = false;
            }
        }*/


        if (mooving && !collided)
        {
            switch (mode)
            {
                
                case "head": 
                foreach(Button button in buttons)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                buttons[2].GetComponent<Button>().interactable = true;
                    break;
                case "body":
                    foreach (Button button in buttons)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    buttons[3].GetComponent<Button>().interactable = true;
                    break;
                case "legs":
                    foreach (Button button in buttons)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    buttons[4].GetComponent<Button>().interactable = true;
                    break;
                case "spine":
                    foreach (Button button in buttons)
                    {
                        button.GetComponent<Button>().interactable = false;
                    }
                    buttons[5].GetComponent<Button>().interactable = true;
                    break;

            }
        }
        else if(!mooving && !collided)
        {
            foreach (Button button in buttons)
            {
                button.GetComponent<Button>().interactable = true;
            }
        }
        /*if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (hit.transform.gameObject.tag)
                {
                    case "head":
                        switchtohead();
                        break;
                    case "body":
                        switchtobody();
                        break;
                    case "legs":
                        switchtolegs();
                        break;
                    case "spine":
                        switchtospine();
                        break;
                }
            }
        }*/
        
        if ((Input.GetMouseButton(0)) && (up || down))
        {
            rotateupdown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            up = false;
            down = false;
        }
    }
    public void switchtoup()
    {
        if (up)
        {
            up = false;
        }
        else
        {
            up = true;
        }
    }
    public void switchtodown()
    {
        if (down)
        {
            down = false;
        }
        else
        {
           down = true;
        }
    }

    public void switchtohead()
    {
        mode = "head";
        head.GetComponent<Renderer>().material = glowing;
        body.GetComponent<Renderer>().material = normal;
        legs.GetComponent<Renderer>().material = normal;
        spine.GetComponent<Renderer>().material = normal;
    }
    public void switchtobody()
    {
        mode = "body";
        head.GetComponent<Renderer>().material = normal;
        body.GetComponent<Renderer>().material = glowing;
        legs.GetComponent<Renderer>().material = normal;
        spine.GetComponent<Renderer>().material = normal;
    }
    public void switchtolegs()
    {
        mode = "legs";
        head.GetComponent<Renderer>().material = normal;
        body.GetComponent<Renderer>().material = normal;
        legs.GetComponent<Renderer>().material = glowing;
        spine.GetComponent<Renderer>().material = normal;
    }
    public void switchtospine()
    {
        mode = "spine";
        head.GetComponent<Renderer>().material = normal;
        body.GetComponent<Renderer>().material = normal;
        legs.GetComponent<Renderer>().material = normal;
        spine.GetComponent<Renderer>().material = glowing;
    }

    public void rotateupdown()
    {
        if (up)
        {
            switch (mode)
            {
                case "head":
                    head.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed * Time.deltaTime) ;
                    break;
                case "body":
                    body.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed * Time.deltaTime);
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back,2* rotationspeed * Time.deltaTime);
                    break;
                case "legs":
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, rotationspeed * Time.deltaTime);
                    break;
                case "spine":
                    spine.transform.eulerAngles += Vector3.forward * rotationspeed * Time.deltaTime;
                    break;
            }
        }
        else if (down)
        {
            switch (mode)
            {
                case "head":
                    head.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed * Time.deltaTime);
                    break;
                case "body":
                    body.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed * Time.deltaTime);
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, 2 * rotationspeed * Time.deltaTime);
                    break;
                case "legs":
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back,  rotationspeed * Time.deltaTime);
                    break;
                case "spine":
                    spine.transform.eulerAngles += Vector3.back * rotationspeed * Time.deltaTime;
                    break;
            }
        }
    }
    public void thirty()
    {
        
        switch (mode)
        {
            case "head":
                fixedangle = (head.transform.localEulerAngles.z > 180 ? -(head.transform.localEulerAngles.z - 360) : -head.transform.localEulerAngles.z);
                if (fixedangle < 30)
                {
                    countermotion = 30-fixedangle;
                }
                else if (fixedangle > 30)
                {
                    countermotion = -(fixedangle-30);
                }
                break;
            case "body":
                fixedangle = (body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z);
                if (fixedangle < 30)
                {
                    countermotion = 30 - fixedangle;
                }
                else if (fixedangle > 30)
                {
                    countermotion = -(fixedangle - 30);
                }
                break;
            case "legs":
                fixedangle = (legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z);
                if (fixedangle < 30)
                {
                    countermotion = 30 - fixedangle;
                }
                else if (fixedangle > 30)
                {
                    countermotion = -(fixedangle - 30);
                }
                break;
            case "spine":
                fixedangle = (spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z);
                if (fixedangle < 30)
                {
                    countermotion = 30 - fixedangle;
                }
                else if (fixedangle > 30)
                {
                    countermotion = -(fixedangle - 30);
                }
                break;
        }
    }
    public void fourtyfive()
    {
        switch (mode)
        {
            case "head":
                fixedangle = (head.transform.localEulerAngles.z > 180 ? -(head.transform.localEulerAngles.z - 360) : -head.transform.localEulerAngles.z);
                if (fixedangle < 45)
                {
                    countermotion = 45 - fixedangle;
                }
                else if (fixedangle > 45)
                {
                    countermotion = -(fixedangle - 45);
                }
                break;
            case "body":
                fixedangle = (body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z);
                if (fixedangle < 45)
                {
                    countermotion = 45 - fixedangle;
                }
                else if (fixedangle > 45)
                {
                    countermotion = -(fixedangle - 45);
                }
                break;
            case "legs":
                fixedangle = (legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z);
                if (fixedangle < 45)
                {
                    countermotion = 45 - fixedangle;
                }
                else if (fixedangle > 45)
                {
                    countermotion = -(fixedangle - 45);
                }
                break;
            case "spine":
                fixedangle = (spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z);
                if (fixedangle < 45)
                {
                    countermotion = 45 - fixedangle;
                }
                else if (fixedangle > 45)
                {
                    countermotion = -(fixedangle - 45);
                }
                break;
        }
    }
    public void sixty()
    {
        switch (mode)
        {
            case "head":
                fixedangle = (head.transform.localEulerAngles.z > 180 ? -(head.transform.localEulerAngles.z - 360) : -head.transform.localEulerAngles.z);
                if (fixedangle < 60)
                {
                    countermotion = 60 - fixedangle;
                }
                else if (fixedangle > 60)
                {
                    countermotion = -(fixedangle - 60);
                }
                break;
            case "body":
                fixedangle = (body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z);
                if (fixedangle < 60)
                {
                    countermotion = 60 - fixedangle;
                }
                else if (fixedangle > 60)
                {
                    countermotion = -(fixedangle - 60);
                }
                break;
            case "legs":
                fixedangle = (legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z);
                if (fixedangle < 60)
                {
                    countermotion = 60 - fixedangle;
                }
                else if (fixedangle > 60)
                {
                    countermotion = -(fixedangle - 60);
                }
                break;
            case "spine":
                fixedangle = (spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z);
                if (fixedangle < 60)
                {
                    countermotion = 60 - fixedangle;
                }
                else if (fixedangle > 60)
                {
                    countermotion = -(fixedangle - 60);
                }
                break;
        }
    }
    public void ninety()
    {
        switch (mode)
        {
            case "head":
                fixedangle = (head.transform.localEulerAngles.z > 180 ? -(head.transform.localEulerAngles.z - 360) : -head.transform.localEulerAngles.z);
                if (fixedangle < 90)
                {
                    countermotion = 90 - fixedangle;
                }
                else if (fixedangle > 90)
                {
                    countermotion = -(fixedangle - 90);
                }
                break;
            case "body":
                fixedangle = (body.transform.localEulerAngles.z > 180 ? (body.transform.localEulerAngles.z - 360) : body.transform.localEulerAngles.z);
                if (fixedangle < 90)
                {
                    countermotion = 90 - fixedangle;
                }
                else if (fixedangle > 90)
                {
                    countermotion = -(fixedangle - 90);
                }
                break;
            case "legs":
                fixedangle = (legs.transform.localEulerAngles.z > 180 ? (legs.transform.localEulerAngles.z - 360) : legs.transform.localEulerAngles.z);
                if (fixedangle < 90)
                {
                    countermotion = 90 - fixedangle;
                }
                else if (fixedangle > 90)
                {
                    countermotion = -(fixedangle - 90);
                }
                break;
            case "spine":
                fixedangle = (spine.transform.localEulerAngles.z > 180 ? (spine.transform.localEulerAngles.z - 360) : spine.transform.localEulerAngles.z);
                if (fixedangle < 90)
                {
                    countermotion = 90 - fixedangle;
                }
                else if (fixedangle > 90)
                {
                    countermotion = -(fixedangle - 90);
                }
                break;
        }
    }
    public void countermove()
    {
        if (countermotion < -rotationspeed / 20)
        {
            mooving = true;
            switch (mode)
            {
                case "head":
                    head.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed/20);
                    countermotion += rotationspeed / 20;
                    break;
                case "body":
                    body.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed / 20);
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, rotationspeed / 10);
                    countermotion += rotationspeed / 20;
                    break;
                case "legs":
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back, rotationspeed / 20);
                    countermotion += rotationspeed / 20;
                    break;
                case "spine":
                    spine.transform.eulerAngles += new Vector3(0,0, -rotationspeed / 20);
                    countermotion += rotationspeed / 20;
                    break;
            }
        }
        else if (countermotion > rotationspeed / 20)
        {
            mooving = true;
            switch (mode)
            {
                case "head":
                    head.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed / 20);
                    countermotion -= rotationspeed / 20;
                    break;
                case "body":
                    body.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed / 20);
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back, rotationspeed / 10);
                    countermotion -= rotationspeed / 20;
                    break;
                case "legs":
                    legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, rotationspeed / 20);
                    countermotion -= rotationspeed / 20;
                    break;
                case "spine":
                    spine.transform.eulerAngles += new Vector3(0, 0, rotationspeed / 20);
                    countermotion -= rotationspeed / 20;
                    break;
            }
        }
        else if(countermotion<= rotationspeed / 20 || countermotion>=-rotationspeed / 20)
        {
            mooving = false;
        }

        
    }
    public void infinitycycle()
    {
        if (cycling) {
            if(forinf>170 && forinf <= 200)
            {
                head.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed / 20);
                forinf -= rotationspeed / 60;
            }
            else if (forinf<=170 && forinf > 160)
            {
                forinf -= 0.1f;
            }
            else if( forinf<=160 &&forinf>130)
            {
                body.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed / 20);
                legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back, rotationspeed / 10);
                forinf -= rotationspeed / 20;
            }
            else if(forinf<=130 && forinf > 110)
            {
                legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, rotationspeed / 20);
                forinf -= rotationspeed / 50;
            }
            else if (forinf <= 110 && forinf > 100)
            {
                forinf -= 0.1f;
            }
            else if (forinf <= 100 && forinf > 90)
            {
                spine.transform.eulerAngles += new Vector3(0, 0, rotationspeed / 20);
                forinf -= rotationspeed / 20;
            }
            else if (forinf > 60 && forinf <= 90)
            {
                head.transform.RotateAround(anchorheadbody.transform.position, Vector3.forward, rotationspeed / 20);
                forinf -= rotationspeed / 20;
            }
            else if (forinf <= 60 && forinf > 30)
            {
                body.transform.RotateAround(anchorheadbody.transform.position, Vector3.back, rotationspeed / 20);
                legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.forward, rotationspeed / 10);
                forinf -= rotationspeed / 20;
            }
            else if (forinf <= 30 && forinf > 10)
            {
                legs.transform.RotateAround(anchorbodylegs.transform.position, Vector3.back,  rotationspeed / 20);
                forinf -= rotationspeed/50 ;
            }
            else if (forinf <= 10 && forinf > 0)
            {
                spine.transform.eulerAngles -= new Vector3(0, 0, rotationspeed / 20);
                forinf -= rotationspeed / 20;
            }
            else if (forinf <= 0)
            {
                forinf = 180;
            }
        }
        else
        {
            forinf = 0;
        }
    }
    public void letcyclebegin()
    {
        if (cycling)
        {
            cycling = false;
            cyclebut.GetComponent<Image>().color = Color.green;
            mode = null;
            mooving = false;
        }
        else
        {
            cycling = true;
            cyclebut.GetComponent<Image>().color = Color.red;
            mode = "Cycling";
            mooving = true;
        }
    }
}
