using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "�y�ȃf�[�^���쐬")]

public class SongData : ScriptableObject
{
    [SerializeField] public string songID;
    [SerializeField] public string songName;
    [SerializeField] public int songLevel;
    [SerializeField] public Sprite songImage;
}
