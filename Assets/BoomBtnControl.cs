using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomBtnControl : MonoBehaviour
{
    public Button boomBtn;
    public GameObject frameObj;

    private GameScene gameScene;

    private void Start()
    {
        gameScene = GameScene.Instance;
        boomBtn.onClick.AddListener(OnClick_UseBoom);
    }

    private void OnClick_UseBoom()
    {
        gameScene.isUsingBoom = !gameScene.isUsingBoom;
        gameScene.isUsingWand = false;
    }

    private void Update()
    {
        frameObj.SetActive(gameScene.isUsingBoom);
    }
}
