using UnityEngine;


[CreateAssetMenu(menuName =("Spells/ Spell data"))]
public class SpellData : ScriptableObject
{
    public string spellName;
    public float cooldown;
    public float range;
    public GameObject vfxPrefab;
    public AudioClip castSfx;
}
