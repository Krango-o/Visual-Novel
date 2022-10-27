using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class TestAddSprite : MonoBehaviour
{
    Dictionary<string, AnimatedSprite> sprites;
    [SerializeField]
    GameObject spritePrefab;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new Dictionary<string, AnimatedSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) //Idle
        {
            AddSprite("LI_Idle");
        }
        if (Input.GetKeyDown(KeyCode.S)) //Frown
        {
            AddSprite("LI_Frown");
        }
        if (Input.GetKeyDown(KeyCode.D)) //Content
        {
            AddSprite("LI_Content");
        }
    }

    void AddSprite(string pName)
    {
        string characterName = pName.Split('_')[0];
        string animationName = pName.Split('_')[1];
        if (sprites.ContainsKey(characterName))
        {
            sprites[characterName].PlayAnimation(animationName);
        }
        else
        {
            AsyncOperationHandle<GameObject> animatorHandle = Addressables.LoadAssetAsync<GameObject>("Assets/TestingFolder/" + characterName + "/" + characterName + ".prefab");
            animatorHandle.Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    GameObject spritePrefab = handle.Result;
                    GameObject newSprite = GameObject.Instantiate(spritePrefab, this.transform);
                    AnimatedSprite animSprite = newSprite.GetComponent<AnimatedSprite>();
                    sprites.Add(characterName, animSprite);
                    animSprite.PlayAnimation(animationName);
                    float positionIndex = 3.0f;
                    if (pName.Split('_').Length >= 3)
                    {
                        positionIndex = float.Parse(pName.Split('_')[2]);
                    }
                }
                else
                {
                    Debug.LogWarning("Issue with Loading Animator: " + handle.Status);
                }
            };
            //GameObject newSprite = GameObject.Instantiate(spritePrefab, this.transform);
        }
    }
}
