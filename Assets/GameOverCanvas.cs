using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    public Text pointScore = null;
    public Text voidScore = null;
    public Text timeScore = null;

    private ManageLogic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = FindAnyObjectByType<ManageLogic>();
        pointScore.text = "Points: " + (logic.time*logic.time * logic.voids*logic.voids).ToString("E1");
        voidScore.text = "Chips: " + logic.voids.ToString();
        timeScore.text = "Time: " + logic.time.ToString();
    }

    public void LoadMainGameScene()
    {

        SceneManager.LoadScene("MainGameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            LoadMainGameScene();
        }
    }

}
