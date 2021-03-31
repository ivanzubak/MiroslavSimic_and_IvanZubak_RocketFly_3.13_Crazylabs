using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float valueToIncreaseEverySec = 0.2f;
    public float MoveSpeed = 10;
    Vector3 target;

    public GameObject ParticleFire;
    public GameObject LevelGeneration;
    public GameObject DeadMenuUi;

    public Transform spawnLocations1;
    public GameObject SpawnDeadPlayer;
    public GameObject SpawnDeadPlayerPrefab;

    public GameObject alivePlayer;
    public GameObject StartingAnimationCharachter;

    public GameObject SaveGame;

    public GameObject PlayerControlls;
    public Slider movespeedslider;
    public Slider speedOverTimeSlider;



    void Start()
    {
        //PlayerScript
        StartCoroutine(PlayerActivater());
    }


    void OnTriggerEnter(Collider other) //player hitting obstacle
    {
        if (other.gameObject.tag == "Obstacle")
        {
            MoveSpeed = 0;
            valueToIncreaseEverySec = 0;
            PlayerControlls.SetActive(false);
            ParticleFire.SetActive(false);
            DeadMenuUi.SetActive(true);
            alivePlayer.SetActive(false);
            SpawnDeadPlayerPrefab = Instantiate(SpawnDeadPlayer, spawnLocations1.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
        MoveSpeed += valueToIncreaseEverySec * Time.deltaTime;
    }



    IEnumerator PlayerActivater()
    {
        yield return new WaitForSeconds(4.0f);
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        SaveGame.SetActive(false);
        ParticleFire.SetActive(true);
        DeadMenuUi.SetActive(false);
        alivePlayer.SetActive(true);
        StartingAnimationCharachter.SetActive(false);
        PlayerControlls.SetActive(true);
        target = new Vector3(20, transform.position.y, 20000000000000);


    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }


    //DEBUG MENU SCRIPT_____________________________________________________
    public void SpeedSlider(float newSpeed)
    {
        MoveSpeed = (float)movespeedslider.value;
    }
    public void OverTimeSpeedSlider(float newOverSpeed)
    {
        valueToIncreaseEverySec = (float)speedOverTimeSlider.value;
    }


    public void EasyGame()
    {
        MoveSpeed = 10;
        valueToIncreaseEverySec = 0.2f;
    }

    public void MediumGame()
    {
        MoveSpeed = 12;
        valueToIncreaseEverySec = 0.3f;
    }

    public void HardGame()
    {
        MoveSpeed = 15;
        valueToIncreaseEverySec = 0.4f;
    }
    public void GhostMode()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    public void NormalMode()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

}