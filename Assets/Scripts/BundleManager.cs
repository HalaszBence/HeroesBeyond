using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundleManager : MonoBehaviour
{
    private AssetBundle heroesBundle;

    void Start()
    {
        string BundleDirectory = Application.dataPath + "/AssetBundles/HeroesBundle";
        heroesBundle = AssetBundle.LoadFromFile(BundleDirectory);
        if (heroesBundle == null) {
            Debug.Log("Failed to load AssetBundle!");
            return;
        }
        GameObject prefab = heroesBundle.LoadAsset<GameObject>("hero1");
        Instantiate(prefab);
    }
}