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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (select > 9)
            {
                select -= 10;
                SongUpdateALL();
            }
            else
            {
                select = 31;
                SongUpdateALL();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (select < 39)
            {
                select += 10;
                SongUpdateALL();
            }
            else
            {
                select = 0;
                SongUpdateALL();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (select < 9)
            {
                //難易度easy譜面
                if (select < 1)
                {
                    select++;
                    SongUpdateALL();
                    Debug.Log(select);

                }
                else
                {
                    select = 0;
                    SongUpdateALL();
                    Debug.Log("select");
                }
            }
            else if (select < 19)
            {
                //難易度Normal用
                if (select < 11)
                {
                    select++;
                    SongUpdateALL();
                    Debug.Log(select);

                }
                else
                {
                    select = 10;
                    SongUpdateALL();
                    Debug.Log("select");
                }
            }
            else if (select < 29)
            {
                //難易度Expert用
                if (select < 21)
                {
                    select++;
                    SongUpdateALL();
                    Debug.Log(select);

                }
                else
                {
                    select = 20;
                    SongUpdateALL();
                    Debug.Log("select");
                }
            }
            else if (select < 39)
            {
                //難易度Master用
                if (select < 31)
                {
                    select++;
                    SongUpdateALL();

                }
                else
                {
                    select = 30;
                    SongUpdateALL();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (select < 9)
            {
                if (select > 0)
                {
                    select--;
                    SongUpdateALL();
                    Debug.Log(select);
                }
                else
                {
                    select = 1;
                    Debug.Log(select);
                }
            }
            else if(select < 19)
            {
                if (select > 10)
                {
                    select--;
                    SongUpdateALL();
                }
                else
                {
                    select = 11;
                }
            }
            else if (select < 29)
            {
                if (select > 20)
                {
                    select--;
                    SongUpdateALL();
                }
                else
                {
                    select = 21;
                }
            }
            else if (select < 39)
            {
                if (select > 30)
                {
                    select--;
                    SongUpdateALL();
                }
                else
                {
                    select = 31;
                }
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