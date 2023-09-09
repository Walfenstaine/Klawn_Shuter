using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class AddBullets : MonoBehaviour
{
    [SerializeField] private Language language;
    public Data data;
    public AudioClip clip;
    public void ADD()
    {
        if (Bridge.platform.language == "ru")
        {
            Subtitres.regit.subtitres = language.ru + " + " + 30;
        }
        else
        {
            Subtitres.regit.subtitres = language.en + " + " + 30;
        }
        data.bulets += 30;
        SoundPlayer.regit.sorse.PlayOneShot(clip);
        SaveAndLoad.Instance.Save();
        Interface.rid.NullBK();
    }
}
