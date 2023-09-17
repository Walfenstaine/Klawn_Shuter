using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data: ScriptableObject
{
    public int record;
    public int bulets;
    public int coins;
    public float sens;
    public bool soundOn;

    public int pl_Helse;
    public int pl_Atak;
    public int pl_Fortune;
}
