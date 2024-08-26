using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "楽曲データを作成")]

public class SongData : ScriptableObject
{
    [SerializeField] public string songID;
    [SerializeField] public string songName;
    [SerializeField] public string songDifficult;
    [SerializeField] public string songNameopen;
    [SerializeField] public int songLevel;
    [SerializeField] public Sprite songImage;
}
