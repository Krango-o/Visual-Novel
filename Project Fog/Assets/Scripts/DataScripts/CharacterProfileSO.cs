using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterProfileSO", menuName = "ScriptableObjects/CharacterProfileSO", order = 1)]
public class CharacterProfileSO : ScriptableObject {

    [field: SerializeField] public string Id { get; private set; }

    [Header("Character Images")]
    public Sprite listItemImage;
    public Sprite portraitImage;

    [Header("Gallery Images")]
    public Sprite galleryImage1;
    public Sprite galleryImage2;
    public Sprite galleryImage3;
    public Sprite galleryImage4;

    [Header("Character Info")]
    public string characterName;
    public string age;
    public string pronouns;
    public string occupation;
    [TextArea(5, 20)]
    public string firstBio;
    [TextArea(5, 20)]
    public string secondBio;

    private void OnValidate() {
#if UNITY_EDITOR
        Id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
