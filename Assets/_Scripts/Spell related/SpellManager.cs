using System;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public static SpellManager Instance;

    public event Action FireSpell;
    public event Action DestroySpell;

    public Dictionary<string,SpellBase> spells = new Dictionary<string,SpellBase>(); 

    //public List<SpellBase> spells=new List<SpellBase>();

    void Awake()
    {
        Instance = this;
    }

    //public void HandleIntent(string intent)
    //{
    //    if (intent == "fire_spell")
    //        FireSpell?.Invoke();

    //    if (intent == "destroy_spell")
    //        DestroySpell?.Invoke();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spell"))
        {

            
            //spells.Add(other.gameObject.GetComponent<SpellBase>());
            if (!spells.ContainsKey(other.gameObject.name))
            {
                Debug.Log("added spell--> " + other.gameObject.name);
                spells.Add(other.gameObject.name, other.gameObject.GetComponent<SpellBase>());
            }
            
        }
    }
}
