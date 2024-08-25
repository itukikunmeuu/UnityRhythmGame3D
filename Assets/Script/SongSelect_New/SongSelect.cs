using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SongSelect : MonoBehaviour
{
    [SerializeField] SongDataBase dataBase;
    [SerializeField] TextMeshProUGUI[] songNameText;
    [SerializeField] TextMeshProUGUI[] songLevelText;
    [SerializeField] Image songImage;

    AudioSource audio;
    AudioClip Music;
    string songName;

    int select;
    private void Start()
    {
        select = 0;
        audio = GetComponent<AudioSource>();
        songName = dataBase.songData[select].songName;//new
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        SongUpdateALL();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (select < dataBase.songData.Length)
            {
                select++;
                SongUpdateALL();
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (select > 0)
            {
                select--;
                SongUpdateALL();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SongStart();
        }
    }
    private void SongUpdateALL()
    {
        songName = dataBase.songData[select].songName;
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        audio.Stop();
        audio.PlayOneShot(Music);
        for (int i = 0; i < 5; i++)
        {
            SongUpdate(i - 2);
        }
    }
    private void SongUpdate(int id)
    {
        try
        {
            songNameText[id + 2].text = dataBase.songData[select + id].songName;
            songLevelText[id + 2].text = "Lv." + dataBase.songData[select + id].songLevel;
        }
        catch
        {
            songNameText[id + 2].text = "";
            songLevelText[id + 2].text = "";
        }
        if (id == 0)
        {
            songImage.sprite = dataBase.songData[select + id].songImage;
        }
    }
    public void SongStart()
    {
        GManager.instance.songID = select;
        SceneManager.LoadScene("GameScene");
    }
}