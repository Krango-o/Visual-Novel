using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AnimDialogueManager : MonoBehaviour, IPointerClickHandler
{
    private string DialogueFileName;
    [SerializeField]
    protected GameObject BackgroundsParent;
    [SerializeField]
    protected GameObject SpritesParent;
    [SerializeField]
    protected GameObject HitBox;
    [SerializeField]
    protected GameObject BackgroundPrefab;
    [SerializeField]
    protected GameObject SpritesPrefab;
    [SerializeField]
    protected DialogueBox DialogueBox;
    [SerializeField]
    protected Image Dimmer;
    [SerializeField]
    protected Image FadeImage;
    [SerializeField]
    protected AudioSource MusicTrack;
    [SerializeField]
    protected AudioSource SoundEffect;
    [SerializeField]
    protected CanvasGroup NovelCanvasGroup;
    [SerializeField]
    protected ChoiceList ChoicesList;
    [SerializeField]
    protected CanvasGroup ButtonsCanvasGroup;

    protected int currentLine = -1;
    private float timeScale = 1.0f;
    private float delayTimer = 0.0f;
    public float delayTimerMax = 0.2f;
    public bool Active { get { return active; } set { active = value; } }
    private bool active = false;
    public bool MoveOn { get { return moveOn; } set { moveOn = value; } }
    private bool moveOn = false;
    private bool paused = false;
    private bool choosing = false;
    private List<DialogueLine> lines;
    private Sequence tweenSequence;
    private Image currentBackground;
    private Dictionary<string, GameObject> prefabDictionary = new Dictionary<string, GameObject>();
    private Dictionary<string, Sprite> backgroundDictionary = new Dictionary<string, Sprite>();
    private Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    private int dataLoaded = 0;
    private Dictionary<string, AnimatedSprite> characterDictionary = new Dictionary<string, AnimatedSprite>();
    private List<string> choices = new List<string>();
    private SaveObject currentSave;
    private float[] spritePositions = { -1500.0f, -600.0f, -350.0f, 0.0f, 350.0f, 600.0f, 1500.0f };

    const string DIALOGUE = "Dialogue";
    const string CHARACTER = "Character";
    const string FADE_IN_LIST = "Fade In (List Characters)";
    const string FADE_OUT_LIST = "Fade Out (List Characters)";
    const string BACKGROUND = "Background";
    const string MUSIC = "Music";
    const string SOUND = "Sound";
    const string EXCLAIM_TEXT_BOX = "Exclaim Text Box";
    const string SCREEN_FADE_IN = "Screen Fade In";
    const string SCREEN_FADE_OUT = "Screen Fade Out";
    const string SPECIAL_ACTIONS = "Special Actions";
    const string CHOICE1 = "Choice 1";
    const string CHOICE2 = "Choice 2";
    const string CHOICE3 = "Choice 3";
    const string REQUIREMENT_KEY = "Requirement Key";
    const string REACTION_EFFECT = "Reaction Effect";

    const string NORMAL_TEXTBOX_NAME = "Background";
    const string EXCLAIM_TEXTBOX_NAME = "Background";

    const string VNSPRITEPATH = "Assets/Images/VNSprites/";
    const string VNBGPATH = "Assets/Images/Background/";

    // Start is called before the first frame update
    void Start()
    {
        NovelCanvasGroup.DOFade(0.0f, 0.0f);
        currentSave = NovelManager.instance.SaveManager.GetLoaded();
        if (currentSave != null)
        {
            DialogueFileName = currentSave.sceneName;
            choices = currentSave.choices.ToList();
        }
        else if (PlayerPrefs.GetString(DataConstants.PLAYERPREFS_CURRENTSCENE) != "")
        {
            DialogueFileName = PlayerPrefs.GetString(DataConstants.PLAYERPREFS_CURRENTSCENE);
        }
        NovelManager.instance.EventManager.Pause.AddListener(() => { paused = true; tweenSequence?.Pause(); timeScale = 0.0f; });
        NovelManager.instance.EventManager.Unpause.AddListener(() => { paused = false; tweenSequence?.TogglePause(); timeScale = 1.0f; });
        // DEBUG 
        // LoadDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        if (Input.GetButtonDown("Jump") && !paused) {
            HandleInput();
        }
        if (delayTimer > 0) {
            delayTimer -= Time.deltaTime;
        }

        //Text Animation
        if (active) {
            bool shouldEndLine = DialogueBox.TextAnimation(timeScale);
            if (shouldEndLine) {
                EndLine();
            }
        }
    }

    public void OnPointerClick(PointerEventData e)
    {
        if (e.pointerCurrentRaycast.gameObject == HitBox && !paused)
        {
            HandleInput();
        }
    }

    public void LoadDialogue(string pDialogueFileName = "")
    {
        if(pDialogueFileName == DialogueFileName)
        {
            CheckDoneLoading(true);
        }
        else
        {
            DialogueFileName = pDialogueFileName == "" ? DialogueFileName : pDialogueFileName;
            using (TextFieldParser parser = new TextFieldParser(Path.Combine(Application.streamingAssetsPath, "Dialogue/" + DialogueFileName + ".csv")))
            {
                parser.SetDelimiters(",");
                lines = new List<DialogueLine>();
                string[] titles = parser.ReadFields();
                Dictionary<string, int> fieldsDictionary = new Dictionary<string, int>();
                for (int i = 0; i < titles.Length; i++)
                {
                    fieldsDictionary[titles[i]] = i;
                }
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    DialogueLine line = new DialogueLine();
                    line.Text = fieldsDictionary.ContainsKey(DIALOGUE) ? fields[fieldsDictionary[DIALOGUE]] : "";
                    line.Character = fieldsDictionary.ContainsKey(CHARACTER) ? fields[fieldsDictionary[CHARACTER]] : "";
                    line.FadeInList = fieldsDictionary.ContainsKey(FADE_IN_LIST) && fields[fieldsDictionary[FADE_IN_LIST]] != "" ? fields[fieldsDictionary[FADE_IN_LIST]].Trim('"').Split(',') : null;
                    if (line.FadeInList != null)
                    {
                        List<string> sList = line.FadeInList.ToList();
                        line.FadeInList.ToList().ForEach(s => {
                            prefabDictionary[s.Split(' ')[0].Split('_')[0]] = null;
                        });
                    }
                    line.FadeOutList = fieldsDictionary.ContainsKey(FADE_OUT_LIST) && fields[fieldsDictionary[FADE_OUT_LIST]] != "" ? fields[fieldsDictionary[FADE_OUT_LIST]].Trim('"').Split(',') : null;
                    line.Background = fieldsDictionary.ContainsKey(BACKGROUND) ? fields[fieldsDictionary[BACKGROUND]] : "";
                    if (line.Background != "") { backgroundDictionary[line.Background] = null; }
                    line.Music = fieldsDictionary.ContainsKey(MUSIC) ? fields[fieldsDictionary[MUSIC]] : "";
                    if (line.Music != "" && line.Music != "none") { musicDictionary[line.Music] = null; }
                    line.Sound = fieldsDictionary.ContainsKey(SOUND) ? fields[fieldsDictionary[SOUND]] : "";
                    if (line.Sound != "") { soundDictionary[line.Sound] = null; }
                    line.ExclaimTextBox = fieldsDictionary.ContainsKey(EXCLAIM_TEXT_BOX) && fields[fieldsDictionary[EXCLAIM_TEXT_BOX]] != "" ? bool.Parse(fields[fieldsDictionary[EXCLAIM_TEXT_BOX]]) : false;
                    line.ScreenFadeIn = fieldsDictionary.ContainsKey(SCREEN_FADE_IN) && fields[fieldsDictionary[SCREEN_FADE_IN]] != "" ? bool.Parse(fields[fieldsDictionary[SCREEN_FADE_IN]]) : false;
                    line.ScreenFadeOut = fieldsDictionary.ContainsKey(SCREEN_FADE_OUT) && fields[fieldsDictionary[SCREEN_FADE_OUT]] != "" ? bool.Parse(fields[fieldsDictionary[SCREEN_FADE_OUT]]) : false;
                    line.SpecialActions = fieldsDictionary.ContainsKey(SPECIAL_ACTIONS) ? fields[fieldsDictionary[SPECIAL_ACTIONS]].Trim('"').Split(';') : null;
                    line.Choice1 = fieldsDictionary.ContainsKey(CHOICE1) ? fields[fieldsDictionary[CHOICE1]].Trim('"').Split(';') : null;
                    line.Choice2 = fieldsDictionary.ContainsKey(CHOICE2) ? fields[fieldsDictionary[CHOICE2]].Trim('"').Split(';') : null;
                    line.Choice3 = fieldsDictionary.ContainsKey(CHOICE3) ? fields[fieldsDictionary[CHOICE3]].Trim('"').Split(';') : null;
                    line.RequirementKey = fieldsDictionary.ContainsKey(REQUIREMENT_KEY) ? fields[fieldsDictionary[REQUIREMENT_KEY]].Trim('"') : null;
                    line.ReactionEffect = fieldsDictionary.ContainsKey(REACTION_EFFECT) && fields[fieldsDictionary[REACTION_EFFECT]] != "" ? fields[fieldsDictionary[REACTION_EFFECT]].Trim('"').Split(',') : null;
                    lines.Add(line);
                }
            }
            Addressables.InitializeAsync().Completed += (result) =>
            {
                LoadBackgrounds();
                LoadSpritePrefabs();
                LoadMusic();
                LoadSound();
                if (prefabDictionary.Keys.Count == 0 && backgroundDictionary.Keys.Count == 0 && musicDictionary.Keys.Count == 0 && soundDictionary.Keys.Count == 0)
                {
                    CheckDoneLoading();
                }
            };
        }
    }

    void LoadMusic()
    {
        foreach (string s in musicDictionary.Keys)
        {
            Addressables.LoadResourceLocationsAsync("Assets/Audio/Music/" + s).Completed += (loc) =>
            {
                if (loc.Result.Count > 0)
                {
                    AsyncOperationHandle<AudioClip[]> handle = Addressables.LoadAssetAsync<AudioClip[]>("Assets/Audio/Music/" + s);
                    handle.Completed += MusicLoaded;
                }
                else
                {
                    Debug.LogWarning("Trying to load an asset that doesn't exist: " + s);
                }
            };
        }
    }

    void MusicLoaded(AsyncOperationHandle<AudioClip[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            AudioClip[] clipArray = handleToCheck.Result;
            foreach (string s in musicDictionary.Keys)
            {
                if (s.Substring(0, s.Length - 4) == clipArray[0].name)
                {
                    musicDictionary[s] = clipArray[0];
                    dataLoaded++;
                    CheckDoneLoading();
                    return;
                }
            }
            Debug.LogWarning("Music name not consistent: " + clipArray[0].name);
        }
        else
        {
            Debug.LogWarning("Issue with Loading Music: " + handleToCheck.Status);
        }
        CheckDoneLoading();
    }

    void LoadSound()
    {
        foreach (string s in soundDictionary.Keys)
        {
            Addressables.LoadResourceLocationsAsync("Assets/Audio/Sound Effects/" + s).Completed += (loc) =>
            {
                if (loc.Result.Count > 0)
                {
                    AsyncOperationHandle<AudioClip[]> handle = Addressables.LoadAssetAsync<AudioClip[]>("Assets/Audio/Sound Effects/" + s);
                    handle.Completed += SoundLoaded;
                }
                else
                {
                    Debug.LogWarning("Trying to load an asset that doesn't exist: " + s);
                }
            };
        }
    }

    void SoundLoaded(AsyncOperationHandle<AudioClip[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            AudioClip[] clipArray = handleToCheck.Result;
            foreach (string s in soundDictionary.Keys)
            {
                if (s.Substring(0, s.Length - 4) == clipArray[0].name)
                {
                    soundDictionary[s] = clipArray[0];
                    dataLoaded++;
                    CheckDoneLoading();
                    return;
                }
            }
            Debug.LogWarning("Sound name not consistent: " + clipArray[0].name);
        }
        else
        {
            Debug.LogWarning("Issue with Loading Sounds: " + handleToCheck.Status);
        }
        CheckDoneLoading();
    }

    void LoadBackgrounds()
    {
        if (backgroundDictionary.ContainsKey("None"))
        {
            backgroundDictionary.Remove("None");
        }
        foreach (string s in backgroundDictionary.Keys)
        {
            Addressables.LoadResourceLocationsAsync(VNBGPATH + s + ".png").Completed += (loc) =>
            {
                if (loc.Result.Count > 0)
                {
                    AsyncOperationHandle<Sprite[]> spriteHandle = Addressables.LoadAssetAsync<Sprite[]>(VNBGPATH + s + ".png");
                    spriteHandle.Completed += BackgroundsLoaded;
                }
                else
                {
                    Debug.LogError("Trying to load an asset that doesn't exist: " + s);
                }
            };
        }
    }

    void BackgroundsLoaded(AsyncOperationHandle<Sprite[]> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite[] spriteArray = handleToCheck.Result;
            if (!backgroundDictionary.ContainsKey(spriteArray[0].name))
            {
                Debug.LogWarning("Background name not consistent: " + spriteArray[0].name);
            }
            backgroundDictionary[spriteArray[0].name] = spriteArray[0];
            dataLoaded++;
        }
        else
        {
            Debug.LogWarning("Issue with Loading Backgrounds: " + handleToCheck.Status);
        }
        CheckDoneLoading();
    }

    void LoadSpritePrefabs()
    {
        foreach (string s in prefabDictionary.Keys)
        {
            string characterName = s.Split('_')[0];
            AsyncOperationHandle<GameObject> spriteHandle = Addressables.LoadAssetAsync<GameObject>(VNSPRITEPATH + characterName + "/" + characterName + ".prefab");
            spriteHandle.Completed += SpritePrefabsLoaded;
        }
    }

    void SpritePrefabsLoaded(AsyncOperationHandle<GameObject> handleToCheck)
    {
        if (handleToCheck.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject loadedObject = handleToCheck.Result;
            if (!prefabDictionary.ContainsKey(loadedObject.name))
            {
                Debug.LogWarning("Sprite Prefab name not consistent: " + loadedObject.name);
            }
            prefabDictionary[loadedObject.name] = loadedObject;
            dataLoaded++;
        }
        else
        {
            Debug.LogWarning("Issue with Loading Sprites: " + handleToCheck.Status);
        }
        CheckDoneLoading();
    }

    void CheckDoneLoading(bool pForceDone = false)
    {
        if (dataLoaded == backgroundDictionary.Keys.Count + prefabDictionary.Keys.Count + musicDictionary.Keys.Count + soundDictionary.Keys.Count || pForceDone)
        {
            NovelCanvasGroup.DOFade(1.0f, 0.2f);
            if (currentSave != null)
            {
                CatchUp();
            }
            else
            {
                if (lines[0].Background != "")
                {
                    if (lines[0].Background == "None")
                    {
                        currentBackground.DOFade(0, 0);
                    }
                    else
                    {
                        if (currentBackground == null)
                        {
                            currentBackground = GameObject.Instantiate(BackgroundPrefab, BackgroundsParent.transform).GetComponent<Image>();
                        }
                        currentBackground.sprite = backgroundDictionary[lines[0].Background];
                    }
                }
                Dimmer.color = new Color(0, 0, 0, 0);
                Dimmer.DOFade(0.8f, 1.0f);
                FadeImage.color = new Color(0, 0, 0, 1);
                FadeIn().onComplete = () =>
                {
                    DialogueBox.FadeBoxIn().onComplete = () => { ContinueDialogue(); };
                    ButtonsCanvasGroup.DOFade(1, 0.3f);
                    NovelCanvasGroup.interactable = true;
                };
            }
        }
    }

    void CatchUp()
    {
        currentLine = currentSave.line;
        string catchupBackground = "";
        Dictionary<string, float> currentSprites = new Dictionary<string, float>();
        for (int i = 0; i <= currentLine; i++)
        {
            catchupBackground = lines[i].Background != "" ? lines[i].Background : catchupBackground;
            if (lines[i].FadeInList != null)
            {
                foreach (string sprite in lines[i].FadeInList)
                {
                    string characterName = sprite.Split(' ')[0].Split('_')[0];
                    string matchingKey = "";
                    foreach (string spriteKey in currentSprites.Keys)
                    {
                        if (spriteKey.Split('_')[0] == characterName)
                        {
                            matchingKey = spriteKey;
                            break;
                        }
                    }
                    float position = 3;
                    if (matchingKey == "")
                    {
                        if (sprite.Split(' ').Length > 1)
                        {
                            position = float.Parse(sprite.Split(' ')[1]);
                        }
                    }
                    else
                    {
                        position = currentSprites[matchingKey];
                        currentSprites.Remove(matchingKey);
                    }
                    currentSprites.Add(sprite.Split(' ')[0], position);
                }
            }
            if (lines[i].FadeOutList != null)
            {
                foreach (string sprite in lines[i].FadeOutList)
                {
                    string characterName = sprite.Split(' ')[0].Split('_')[0];
                    string matchingKey = "";
                    foreach (string spriteKey in currentSprites.Keys)
                    {
                        if (spriteKey.Split('_')[0] == characterName)
                        {
                            matchingKey = spriteKey;
                            break;
                        }
                    }
                    currentSprites.Remove(matchingKey);
                }
            }
        }
        DisplayBackground(catchupBackground);
        ShowCharacters(currentSprites);
        DialogueBox.FadeBoxIn();
        moveOn = true;
        DialogueBox.SetCompleteLine(lines[currentLine]);
    }

    void ShowCharacters(Dictionary<string, float> characters)
    {
        foreach (string key in characters.Keys)
        {
            string characterName = key.Split('_')[0];
            string animName = key.Split('_')[1];
            GameObject characterObject = GameObject.Instantiate(prefabDictionary[key], SpritesParent.transform);
            Image currentSprite = characterObject.GetComponent<Image>();
            characterObject.GetComponent<AnimatedSprite>().PlayAnimation(animName);
            currentSprite.rectTransform.anchoredPosition = new Vector2(GetSpritePosition(characters[key]), 0);
            characterDictionary[key.Split('_')[0]] = characterObject.GetComponent<AnimatedSprite>();
        }
    }

    void DisplayBackground(string spriteName)
    {
        if (spriteName != "None")
        {
            currentBackground = GameObject.Instantiate(BackgroundPrefab, BackgroundsParent.transform).GetComponent<Image>();
            currentBackground.sprite = backgroundDictionary[spriteName];
            currentBackground.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    void ContinueDialogue()
    {
        if (tweenSequence != null) { tweenSequence.Kill(true); }
        tweenSequence = DOTween.Sequence();
        if (currentLine >= 1 && lines[currentLine].FadeOutList != null && lines[currentLine].FadeOutList.Length > 0)
        {
            foreach (string character in lines[currentLine].FadeOutList)
            {
                string characterName = character.Split('_')[0];
                if (characterDictionary.ContainsKey(characterName))
                {
                    tweenSequence.Join(characterDictionary[characterName].GetComponent<Image>().DOFade(0.0f, 1.0f).OnComplete(() => {
                        GameObject.Destroy(characterDictionary[characterName].gameObject);
                        characterDictionary.Remove(characterName);
                    }));
                }
                else
                {
                    Debug.LogWarning("Character Name not found in Fade Out List on line " + currentLine + 2);
                }
                //find character image and start fade out tween
            }
        }
        if (currentLine >= 0 && lines[currentLine].ScreenFadeOut)
        {
            tweenSequence.Append(FadeOut());
        }
        currentLine++;
        DialogueLine current = lines[currentLine];
        //DialogueBox.SetLine(lines[currentLine]);
        // Doesn't have the correct requirement key saved
        if (current.RequirementKey != "" && !choices.Contains(current.RequirementKey))
        {
            ContinueDialogue();
            return;
        }
        if (current.ScreenFadeIn)
        {
            tweenSequence.Append(FadeIn());
        }
        if (current.Background != "" && currentLine != 0)
        {
            //change backgroundimage image
            //new image on top, .DOFade image on top
            Image prevBackground = currentBackground;
            DisplayBackground(current.Background);
            if (current.Background == "None")
            {
                tweenSequence.Append(currentBackground.DOFade(0, 2.0f));
            }
            else
            {
                tweenSequence.Append(currentBackground.DOFade(1, 2.0f).OnComplete(() =>
                {
                    GameObject.Destroy(prevBackground.gameObject);
                }));
            }
        }
        if (current.Music != "")
        {
            //music
            Tween musicTween = Dimmer.DOFade(Dimmer.color.a, 0.1f);
            musicTween.onComplete = () => {
                Debug.Log("ChangeMusic: " + current.Music);
                if (current.Music != "none")
                {
                    MusicTrack.Stop();
                    MusicTrack.clip = musicDictionary[current.Music];
                    MusicTrack.Play();
                    MusicTrack.DOFade(1.0f, 1.0f);
                }
                else
                {
                    MusicTrack.DOFade(0, 1.0f);
                }
            };
            tweenSequence.Append(musicTween);
        }
        Tween soundTween = Dimmer.DOFade(Dimmer.color.a, 0.1f);
        soundTween.onComplete = () => {
            if (current.Sound != "")
            {
                Debug.Log("ChangeSound: " + current.Sound);
                SoundEffect.clip = soundDictionary[current.Sound];
                SoundEffect.Play();
            }
            DialogueBox.SetTextBoxImage(current.ExclaimTextBox);
        };
        tweenSequence.Append(soundTween);
        if (current.FadeInList != null && current.FadeInList.Length > 0)
        {
            foreach (string character in current.FadeInList)
            {
                //find character image and start fade in tween
                string[] characterArray = character.Split(' ');
                string characterName = characterArray[0].Split('_')[0];
                string animName = characterArray[0].Split('_')[1];
                if (characterDictionary.ContainsKey(characterName))
                {
                    tweenSequence.Join(DOVirtual.DelayedCall(0, () => { characterDictionary[characterName].PlayAnimation(animName); }));
                }
                else
                {
                    AnimatedSprite currentCharacter = GameObject.Instantiate(prefabDictionary[characterName], SpritesParent.transform).GetComponent<AnimatedSprite>();
                    Image currentImage = currentCharacter.GetComponent<Image>();
                    currentImage.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                    if (characterArray.Length > 1)
                    {
                        currentImage.rectTransform.anchoredPosition = new Vector2(GetSpritePosition(float.Parse(characterArray[1])), 0);
                    }
                    characterDictionary[characterName] = currentCharacter.GetComponent<AnimatedSprite>();
                    currentCharacter.PlayAnimation(animName);
                    tweenSequence.Join(currentImage.DOFade(1.0f, 1.0f));
                }
            }
        }
        AddSpecialActions(); 
        Tween nameTween = Dimmer.DOFade(Dimmer.color.a, 0.1f);
        nameTween.onComplete = () => { 
            DialogueBox.NextLine(lines[currentLine]);
            if (lines[currentLine].Character != "" && lines[currentLine].Character != "Player" && characterDictionary.ContainsKey(lines[currentLine].Character))
            {
                characterDictionary[lines[currentLine].Character].ToggleTalking(DialogueBox.isLineComplete());
                characterDictionary[lines[currentLine].Character].transform.SetAsLastSibling();
            }
            Canvas.ForceUpdateCanvases();
        };
        Tween reactionTween = Dimmer.DOFade(Dimmer.color.a, 0.1f);
        reactionTween.onComplete = () => {
            if(current.ReactionEffect != null && current.ReactionEffect.Length > 0) {
                foreach(string effect in current.ReactionEffect) {
                    string trimmedEffect = effect.Trim();
                    string character = trimmedEffect.Split(' ')[0];
                    string reaction = trimmedEffect.Split(' ')[1];
                    characterDictionary[character].PlayReaction(reaction);
                }
            }
        };
        active = false;
        tweenSequence.Append(nameTween);
        tweenSequence.Append(reactionTween);
        DialogueBox.ResetText();
    }

    float GetSpritePosition(float pos)
    {
        float newPos = 0.0f;
        int baseIndex = Mathf.FloorToInt(pos);
        if (baseIndex < spritePositions.Length - 1)
        {
            newPos = Mathf.Lerp(spritePositions[baseIndex], spritePositions[baseIndex + 1], pos % 1.0f);
        }
        else
        {
            newPos = spritePositions[baseIndex - 1];
        }
        return newPos;
    }

    void AddSpecialActions()
    {
        if (lines[currentLine].SpecialActions != null && lines[currentLine].SpecialActions[0] != "")
        {
            foreach (string actions in lines[currentLine].SpecialActions)
            {
                foreach (string action in actions.Split(','))
                {
                    string trimmedAction = action.Trim();
                    string character = trimmedAction.Split(' ')[0];
                    string keyword = trimmedAction.Split(' ')[1];
                    switch (keyword)
                    {
                        case "Flip":
                            tweenSequence.Join(characterDictionary[character].GetComponent<Image>().rectTransform.DOScaleX(characterDictionary[character].GetComponent<Image>().rectTransform.localScale.x * -1, 0.1f));
                            break;
                        case "Move":
                            float movePos = float.Parse(trimmedAction.Split(' ')[2]);
                            tweenSequence.Join(characterDictionary[character].GetComponent<Image>().rectTransform.DOAnchorPosX(GetSpritePosition(movePos), 1.0f));
                            break;
                        default:
                            Debug.Log("Could not find correct special actions keyword at line " + currentLine + " in sheet " + DialogueFileName);
                            break;
                    }
                }
            }
        }
    }

    void HandleInput()
    {
        if (currentLine > -1 && delayTimer <= 0)
        {
            if (moveOn)
            {
                if (currentLine + 1 < lines.Count)
                {
                    //Next line
                    if(lines[currentLine].Character != "" && lines[currentLine].Character != "Player" && characterDictionary.ContainsKey(lines[currentLine].Character))
                    {
                        characterDictionary[lines[currentLine].Character].ToggleTalking(false);
                    }
                    ContinueDialogue();
                    moveOn = false;
                    delayTimer = delayTimerMax;
                }
                else
                {
                    SceneEnd();
                }
            }
            else if(!choosing)
            {
                //Skip animation.
                tweenSequence?.Complete();
                moveOn = true;
                DialogueBox.SkipAnimation();
                EndLine();
            }
        }
    }

    void EndLine()
    {
        if (lines[currentLine].Character != "" && characterDictionary.ContainsKey(lines[currentLine].Character))
        {
            characterDictionary[lines[currentLine].Character].ToggleTalking(false);
        }
        //Populate Choices
        if(lines[currentLine].Choice1.Length > 1 || lines[currentLine].Choice2.Length > 1 || lines[currentLine].Choice3.Length > 1)
        {
            choosing = true;
            ChoicesList.SetData(lines[currentLine].Choice1, lines[currentLine].Choice2, lines[currentLine].Choice3);
        }
        else
        {
            moveOn = true;
        }
    }

    public void MakeChoice(string choiceKey)
    {
        if (!choices.Contains(choiceKey))
        {
            choices.Add(choiceKey);
        }
        moveOn = false;
        choosing = false;
        ContinueDialogue();
    }

    void SceneEnd()
    {
        active = false;
        ButtonsCanvasGroup.DOFade(0, 0.3f);
        DialogueBox.ResetBox();
        DialogueBox.FadeBoxOut().onComplete = () => {
            MusicTrack.DOFade(0.0f, 1.0f);
            FadeOut().onComplete = () =>
            {
                NovelCanvasGroup.DOFade(0.0f, 0.2f).onComplete = () => {
                    GameManager.instance.SetState(GameState.OVERWORLD);
                    Reset();
                    NovelCanvasGroup.interactable = false;
                };
            };
        };
    }

    void Reset()
    {
        currentLine = -1;
        moveOn = false;
        choosing = false;
        DialogueBox.ResetBox();
        foreach ( string k in characterDictionary.Keys)
        {
            Destroy(characterDictionary[k].gameObject);
        }
        characterDictionary = new Dictionary<string, AnimatedSprite>();
        currentSave = null;
    }

    Tween FadeIn()
    {
        return FadeImage.DOFade(0, 1);
    }

    Tween FadeOut()
    {
        return FadeImage.DOFade(1, 1);
    }

    public int GetCurrentLine()
    {
        return currentLine;
    }

    public List<DialogueLine> GetLines()
    {
        return lines;
    }

    public string[] GetChoices()
    {
        return choices.ToArray();
    }
}
