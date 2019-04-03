using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
	public Transform target;
	public GameObject parent;
	public GameObject Dial;
	public Text nameText;
	public Text dialogueText;
	public Text r1;
	public Text r2;

	[Header("DialogueSystem")]
	[SerializeField]
    private bool enDial = false;
    [SerializeField]
    bool rep1 = false;
    [SerializeField]
    bool rep2 = false;
    [SerializeField]
    bool rep3 = false;
    [SerializeField]
    bool rep4 = false;
    [SerializeField]
    bool p1 = false;

    [SerializeField]
    private bool finConv = false;
  
   private void Start()
    {
      
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !finConv)
        {
            Dial.SetActive(true);
            nameText.text = parent.name;
            dialogueText.text = "Bonjour, avez vous quelque minutes a m'accorder ??";
            r1.text = "Oui [Y]";
            r2.text = "Non [N]";

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            parent.transform.LookAt(target);
            if (Input.GetKeyDown(KeyCode.Y) && rep2 == false)
            {
                Oui();
                enDial = true;
                rep1 = true;
                
            }
            if (Input.GetKeyDown(KeyCode.N) && rep1 == false)
            {
                Non();
                enDial = true;
                rep2 = true;
                
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Dial.SetActive(false);
            enDial = false;
        }
    }

    public void Oui()
    {
        Debug.Log("test");
        dialogueText.text = "Merci. Je me presente je m'appelle Marie ...";
        r1.text = "Enchanté [Y]";
        r2.text = "Oui et ?? [N]";
        if (Input.GetKeyDown(KeyCode.Y) && rep1 == true)
        {
            dialogueText.text = "l'association bidule ...";
            r1.text = "blabla";
            r2.text = "";
            rep3 = true;
           
        }
        if (Input.GetKeyDown(KeyCode.N) && rep1 == true)
        {
            dialogueText.text = "D'accord enfin bref. L'association machin ...";
            r1.text = "";
            r2.text = "blablabla";
            rep4 = true;
            
        }
        if (rep3 == true)
        {
            r1.text = "sdfghj";
        }
        if (rep4 == true)
        {
            r2.text = "efbnjhgfc";
        }
    }

    public void Non()
    {
        Debug.Log("test");
        dialogueText.text = "Merci quand même. Bonne journée";
        r1.text = "Bonne journée";
        r2.text = "";
        finConv = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && rep1 == true && enDial == true && rep3 == false)
        {
            dialogueText.text = "D'accord enfin bref. L'association machin ...";
            r1.text = "";
            r2.text = "blablabla";
            rep4 = true;
        }
        /*else if(Input.GetKeyDown(KeyCode.N) && rep1 != true || enDial != true || rep3 != false)
        {
            Debug.Log("pas en conv");
        }*/
    }
}
