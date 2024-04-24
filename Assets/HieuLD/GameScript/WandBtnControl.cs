using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WandBtnControl : MonoBehaviour
{
    public Button wandBtn;
    public GameObject frameObj;

    private GameScene gameScene;

    private void Start()
    {
        gameScene = GameScene.Instance;
        wandBtn.onClick.AddListener(OnClick_UseWand);
    }

    private void OnClick_UseWand()
    {
        gameScene.isUsingWand = !gameScene.isUsingWand;
        gameScene.isUsingBoom = false;
    }

    private void Update()
    {
        frameObj.SetActive(gameScene.isUsingWand);
    }
}
