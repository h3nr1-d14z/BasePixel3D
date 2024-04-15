using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppPause : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        Debug.Log("focus " + focus);
        UnitySingleton<ProgressManager>.Instance.SaveWork(null);
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("pause " + pause);
        UnitySingleton<ProgressManager>.Instance.SaveWork(null);
    }
}
