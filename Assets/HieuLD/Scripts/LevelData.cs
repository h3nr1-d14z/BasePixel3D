using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelInform
{
    public string Name;
    public string Id;
    public AccessStatus AccessStatus;
    public string Url;
    public bool Is3D;
    public string Source;
}

[CreateAssetMenu(menuName = "Datas/LevelData", fileName = "LevelData.asset")]
public class LevelData : ScriptableObject
{
    public List<LevelInform> levels = new List<LevelInform>();
}
