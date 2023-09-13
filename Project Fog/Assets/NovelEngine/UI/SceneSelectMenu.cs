using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class SceneSelectMenu : MonoBehaviour
{
    [SerializeField]
    private Button SceneSelectPrefab;
    [SerializeField]
    private GameObject ButtonGrid;
    private string[] files;

    // Start is called before the first frame update
    void Start()
    {
        string directoryPath = Path.Combine(Application.streamingAssetsPath, "Dialogue");
        files = Directory.GetFiles(directoryPath);
        files.ToList().ForEach(file => {
            if (!file.Contains(".meta"))
            {
                string name = file.Remove(0, directoryPath.Length + 1);
                name = name.Remove(name.IndexOf(".csv"), 4);
                Button button = GameObject.Instantiate(SceneSelectPrefab, ButtonGrid.transform);
                button.GetComponentInChildren<Text>().text = name;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectScene(Button button)
    {
        PlayerPrefs.SetString(DataConstants.PLAYERPREFS_CURRENTSCENE, button.GetComponentInChildren<Text>().text);
        PlayerPrefs.Save();
        SceneManager.LoadScene("TestScene");
    }
}
