//ノーツが流れてくるのが遅ければoffsetを小さくし、早ければ大きくする

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Data
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Note[] notes;

}
[Serializable]
public class Note
{
    public int type;
    public int num;
    public int block;
    public int LPB;
}

public class NotesManager : MonoBehaviour
{
    public int noteNum;
    private string songName;

    public List<int> LaneNum = new List<int>();
    public List<int> NoteType = new List<int>();
    public List<float> NotesTime = new List<float>();
    public List<GameObject> NotesObj = new List<GameObject>();

    public List<int> LaneNumL = new List<int>();
    public List<float> NotesTimeL = new List<float>();
    public List<int> NotesNumL = new List<int>();
    public List<GameObject> NotesObjL = new List<GameObject>();

    [SerializeField] private float NotesSpeed;
    [SerializeField] GameObject noteObj;
    [SerializeField] SongDataBase dataBase;

    void OnEnable()
    {
        Debug.Log("呼び出す順番1");
        NotesSpeed = GManager.instance.noteSpeed;
        noteNum = 0;
        songName = dataBase.songData[GManager.instance.songID].songName;//change
        Load(songName);
    }

    private void Load(string SongName)
    {
        string inputString = Resources.Load<TextAsset>(SongName).ToString();
        Data inputJson = JsonUtility.FromJson<Data>(inputString);

        noteNum = inputJson.notes.Length;
        GManager.instance.maxScore = noteNum * 5;

        for (int i = 0; i < inputJson.notes.Length; i++)
        {
            float kankaku = 60 / (inputJson.BPM * (float)inputJson.notes[i].LPB);
            float beatSec = kankaku * (float)inputJson.notes[i].LPB;
            float time = (beatSec * inputJson.notes[i].num / (float)inputJson.notes[i].LPB) + inputJson.offset * 0.01f;
            NotesTime.Add(time);
            LaneNum.Add(inputJson.notes[i].block);
            NoteType.Add(inputJson.notes[i].type);

            float z = NotesTime[i] * NotesSpeed;
            NotesObj.Add(Instantiate(noteObj, new Vector3(inputJson.notes[i].block - 1.5f, 0.55f, z), Quaternion.identity));
        }
    }
}
