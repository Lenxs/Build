using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerStats : MonoBehaviour
{

	public Image MoralImg;
	public Text mtext;
	public float currentMoral;
	public float maxMoral;
	public Image BonheurImg;
	public Text btext;
	public float currentBonheur;
	public float maxBonheur;
	public Image LiberteImg;
	public Text ltext;
	public float currentLiberte;
	public float maxLiberte;
	public Image fadePlane;

	public GameObject gameOverUI;
	public FirstPersonController Player;

    // Start is called before the first frame update
    void Start()
    {
        Player= GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        float percentageMoral =((currentMoral * 100)/maxMoral) / 100;
        MoralImg.fillAmount = percentageMoral;
        mtext.text =percentageMoral.ToString();

        float percentageBonheur =((currentBonheur * 100)/maxBonheur)/ 100;
        BonheurImg.fillAmount =  percentageBonheur;
       btext.text = percentageBonheur.ToString();

        float percentageLiberte = ((currentLiberte	* 100)/maxLiberte)/100;
        LiberteImg.fillAmount = percentageLiberte;
        ltext.text = percentageLiberte.ToString();

        if(Input.GetKeyDown(KeyCode.K))
        {
        	Action(20);
        }


    }

    public	void Action(float TheAction)
    {
    	currentMoral = currentMoral	- TheAction;
    	currentLiberte	= currentLiberte - TheAction;
    	currentBonheur	= currentBonheur- TheAction;

    	if(currentMoral <= 0|| currentLiberte <=0|| currentBonheur <= 0)
    	{
    		GameOver();
    	}
    }



    public void GameOver()
    {
    	gameOverUI.SetActive(true);
    	Player.gameOver = true;
    	Debug.Log("Perdu");
    	StartCoroutine(Fade(Color.clear,new Color(0,0,0, .95f),1));
    }

    IEnumerator	Fade(Color from, Color to, float time)
    {
    	float	speed= 1/time;
    	float	percent = 0;

    	while(percent < 1)
    	{
    		percent+= Time.deltaTime * speed;
    		fadePlane.color= Color.Lerp(from,to,percent);
    		yield return null;
    	}
    }
}
