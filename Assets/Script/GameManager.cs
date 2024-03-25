using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Text timeTxt;
    public GameObject endTxt;

    public int carCount = 0;
    float time;

    public Card firstCard;
    public Card secondCard;

    AudioSource audioSource;

    public AudioClip clip;
    void Awake(){
        if(Instance==null){
            Instance=this;
        }
        Application.targetFrameRate=60;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
        if(time>30){
            Time.timeScale=0f;
            endTxt.SetActive(true);
        }
    }

    public void Matched(){
        if(firstCard.idx==secondCard.idx){
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            carCount-=2;
            if(carCount ==0){
                Time.timeScale=0;
                endTxt.SetActive(true);
            }
        }else{
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
}
