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

    public GameObject gunObject;

    public GameObject swordObject;

    public GameObject lightObject;

    public GameObject spellManagerObject;

    [SerializeField] private Wit wit;


    private Dictionary<string, GameObject> spellObjectDictionary = new Dictionary<string, GameObject>();
    void Start()
    {
        fireObject.SetActive(true);
        iceObject.SetActive(true);
        gunObject.SetActive(true);
        swordObject.SetActive(true);
        lightObject.SetActive(true);
       spellObjectDictionary["fire"] = fireObject;
        spellObjectDictionary["ice"] = iceObject;
        spellObjectDictionary["gun"] = gunObject;
        spellObjectDictionary["sword"] = swordObject;
        spellObjectDictionary["light"] = lightObject;
        
        
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
                GameObject spellCopy = Instantiate(spellObject, spellManagerObject.transform.position, spellManagerObject.transform.rotation);
                Destroy(spellCopy, 3f);
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
