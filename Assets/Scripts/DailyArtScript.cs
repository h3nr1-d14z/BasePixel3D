using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyArtScript : MonoBehaviour {

    public Text title;
    // Use this for initialization
    private void Awake()
    {
#if UNITY_IOS
        //fix for iPhone X
        //bool deviceIsIphoneX = UnityEngine.iOS.Device.generation == UnityEngine.iOS.DeviceGeneration.iPhoneX;
        if (Screen.width == 1125)
        {
            title.fontSize = 35;
            var pos = title.transform.localPosition;
            title.transform.localPosition = new Vector3(pos.x - 45, pos.y, pos.z);
            // Do something for iPhone X
        }
#endif
    }
}
