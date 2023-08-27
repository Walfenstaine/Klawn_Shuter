using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class GameInterfase : MonoBehaviour
{
    [SerializeField] private Language language;
    public Data data;
    public Image hPbar;
    public Text bullets, record, killed;
    public int killers;
    private float mHalse;
    public static GameInterfase rid { get; set; }
    void Awake()
    {
        killers = 0;
        killers = data.record;
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void Kill()
    {
        int index = data.record + 10;
        killers += 1;
        if (killers >= index)
        {
            data.record = killers;
            SaveAndLoad.Instance.Save();
            if (Bridge.platform.language == "ru")
            {
                Subtitres.regit.subtitres = language.ru;
            }
            else
            {
                Subtitres.regit.subtitres = language.en;
            }

        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    void Update()
    {
        hPbar.fillAmount = Gun.rid.helse / 10;
        bullets.text = "" + data.bulets;
        record.text = "" + (data.record);
        killed.text = "" + killers;
    }
}
