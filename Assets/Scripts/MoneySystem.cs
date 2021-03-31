using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    
    //                      CHARACHTERS
    //-------------------------------------------------
    
    public Transform CharachterDefault;
    public Transform Woman;
    public Transform Alien;
    public Transform Robot;


    //                      ROCKETS
    //-------------------------------------------------


    public Transform RocketDefault;
    public Transform WomanRocket;
    public Transform DroneRocket;
    public Transform AlienRocket;




    //-------------------------------------------------
    public AudioSource PickupCoinSound;
    public GameObject NoMoneyCavnas;
    private static MoneySystem _instance;
    public int money;
    Text moneyText;
    public Text highScoreText;
    public float saveInterval;
    public Text ScoreText;
    public int score;
    public int highscore;

    private static MoneySystem instance

    {
        get
        {
            if (_instance == null)
            {
                if (GameObject.Find("Player"))
                {
                    GameObject g = GameObject.Find("Player");
                    if (g.GetComponent<MoneySystem>())
                    {
                        _instance = g.GetComponent<MoneySystem>();
                    }
                    else
                    {
                        _instance = g.AddComponent<MoneySystem>();
                    }
                }
                else
                {
                    GameObject g = new GameObject();
                    g.name = "Player";
                    _instance = g.AddComponent<MoneySystem>();
                }
            }

            return _instance;
        }


        set
        {
            _instance = value;
        }
    }
    
    void OnTriggerEnter(Collider other) //player Taking Coins
    {
        if (other.gameObject.tag == "Coin")
        {
            instance.money += 1;
            PickupCoinSound.Play ();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Score")
        {
            score = score + 1;
        }
    }


    void Update()
    {
        moneyText.text = "" + money.ToString();
        ScoreText.text = "" + score;

        if (score > highscore)
        {
            highscore = score;
            highScoreText.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highScoreText.text = highscore.ToString();
        ScoreText.text = "0";
        moneyText = GameObject.Find("Money Text").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore Text").GetComponent<Text>();
        //-------------------------------------------------
        gameObject.name = "Player";
        _instance = this;
        AddMoney(PlayerPrefs.GetInt("MoneySave", 0));
        StartCoroutine("SaveMoney");
    }

    public IEnumerator SaveMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(saveInterval);
            PlayerPrefs.SetInt("MoneySave", instance.money);
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }

    public static void AddMoney(int amount)
    {
        instance.money += amount;
    }

    public bool BuyItem(int cost)
    {
        if (instance.money - cost >= 0)

        {
            instance.money -= cost;
            return true;

        }
        else
        {
            NoMoneyCavnas.SetActive(true);
            return false;
        }

    }
    //-------------------------------------------------
    public void Earn10000()
    {
        instance.money +=10000 ;
    }
    //-------------------------------------------------
    public void AlienShip()
    {

        if (instance.money - 500 >= 0)

        {
            instance.money -= 500;
            AlienRocket.transform.localScale = new Vector3(0, 0.0f, 0);
        }
        else

        {
            NoMoneyCavnas.SetActive(true);


        }
    }
    public void AlienCharachter()
    {

        if (instance.money - 500 >= 0)

        {
            Alien.transform.localScale = new Vector3(0, 0.0f, 0);
            instance.money -= 500;
        }
        else

        {
            NoMoneyCavnas.SetActive(true);

        }
    }
    public void RobotCharachter()
    {

        if (instance.money - 1000 >= 0)

        {
            instance.money -= 1000;
            Robot.transform.localScale = new Vector3(0, 0.0f, 0);
        }

        else

        {
            NoMoneyCavnas.SetActive(true);


        }
    }

    public void Robotship()

    {
        if (instance.money - 1000 >= 0)

        {
            instance.money -= 1000;
            DroneRocket.transform.localScale = new Vector3(0, 0.0f, 0);
            }
        else

        {
            NoMoneyCavnas.SetActive(true);


        }
    }
}