using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Meta.WitAi;
using Meta.WitAi.Json;

namespace Meta.WitAi
{
public class spellManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireObject;
    public GameObject iceObject;

    public GameObject spellObject;

    [SerializeField] private Wit wit;


    private Dictionary<string, GameObject> spellObjectDictionary = new Dictionary<string, GameObject>();
    void Start()
    {
       spellObjectDictionary["fire"] = fireObject;
        spellObjectDictionary["ice"] = iceObject;
        
    }

   


   void Update()
   {
       
   }


    

    // Update is called once per frame

    // void OnDestroy() {
    //     Scene currentScene = SceneManager.GetActiveScene();

    //     // Iterate through all GameObjects in the scene
    //     foreach (GameObject gameObject in currentScene.GetRootGameObjects())
    //     {
    //         // Destroy each GameObject
    //         Destroy(gameObject);
    //     }
    // }

    public void castSpells(WitResponseNode commandResult){
        string[] spellNames = commandResult.GetAllEntityValues("spell:spell");

        initiateSpells(spellNames);
    }

    public void initiateSpells(string[] spellNames){
        
        if (spellNames.Length == 0){
            return;
        }
        foreach (string spellName in spellNames)
        {
            if (spellObjectDictionary.ContainsKey(spellName))
            {
                // Retrieve the corresponding object and instantiate it, for example
                GameObject spellObject = spellObjectDictionary[spellName];
                Instantiate(spellObject, spellObject.transform.position, spellObject.transform.rotation);
                StartCoroutine(DeactivateAfterDelay(spellObject, 3.0f));
            }
            else
            {
                // Handle the case where the spell name is not found
                Debug.LogError("Spell not found: " + spellName);
            }
        }
    }

    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
{
    yield return new WaitForSeconds(delay);

    // Deactivate the object
    obj.SetActive(false);
}
}
}
