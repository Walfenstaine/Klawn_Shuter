using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skils_Creator : MonoBehaviour
{
    public AudioClip clip;
    public Data data;
    public SkillserKlic helse, atak, fortune;

    private void Start()
    {
        helse.level = data.pl_Helse;
        atak.level = data.pl_Atak;
        fortune.level = data.pl_Fortune;
    }

    public void Save()
    {
        SaveAndLoad.Instance.Save();
        Debug.Log("Save");
    }
    public void UpHelse()
    {
        if (data.pl_Helse <= data.coins)
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            data.pl_Helse += 1;
            data.coins -= data.pl_Helse;
            helse.level = data.pl_Helse;
        }
        else
        {
            helse.Upgreid(false);
        }
    }
    public void UpAtak()
    {
        if (data.pl_Atak <= data.coins)
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            data.pl_Atak += 1;
            data.coins -= data.pl_Atak;
            atak.level = data.pl_Atak;
        }
        else
        {
            atak.Upgreid(false);
        }
    }
    public void UpFortune()
    {
        if (data.pl_Fortune <= data.coins)
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            data.pl_Fortune += 1;
            data.coins -= data.pl_Fortune;
            fortune.level = data.pl_Fortune;
            
        }
        else
        {
            fortune.Upgreid(false);
        }
    }
    void Update()
    {
        if (helse.level >= data.coins)
        {
            helse.Upgreid(false);
        }
        else
        {
            helse.Upgreid(true);
        }

        if (atak.level >= data.coins)
        {
            atak.Upgreid(false);
        }
        else
        {
            atak.Upgreid(true);
        }

        if (fortune.level >= data.coins)
        {
            fortune.Upgreid(false);
        }
        else
        {
            fortune.Upgreid(true);
        }
    }
}
