using System;
using System.Linq;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    public static event Action<Story> OnCreateStory;

    // Tambahkan referensi ke kontainer baru
    [SerializeField]
    private GameObject contentPanel; // Kontainer untuk teks cerita
    [SerializeField]
    private GameObject choicesPanel; // Kontainer untuk pilihan

    void Awake()
    {
        RemoveChildren();
        StartStory();
    }

    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        OnCreateStory?.Invoke(story);
        RefreshView();
    }

    void RefreshView()
    {
        RemoveChildren();

        // Menampilkan teks cerita
        while (story.canContinue)
        {
            string text = story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }

        // Menampilkan pilihan (Choices)
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                UnityEngine.UI.Button button = CreateChoiceView(choice.text.Trim());
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        else
        {
            UnityEngine.UI.Button choice = CreateChoiceView("End of story.\nRestart?");
            choice.onClick.AddListener(delegate {
                StartStory();
            });
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        // Mengatur `parent` menjadi `contentPanel` untuk teks cerita
        storyText.transform.SetParent(contentPanel.transform, false);
    }

    UnityEngine.UI.Button CreateChoiceView(string text)
    {
        UnityEngine.UI.Button choice = Instantiate(buttonPrefab) as UnityEngine.UI.Button;
        // Mengatur `parent` menjadi `choicesPanel` untuk pilihan
        choice.transform.SetParent(choicesPanel.transform, false);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        return choice;
    }

    void RemoveChildren()
    {
        // Menghapus anak-anak dari kontainer masing-masing
        foreach (Transform child in contentPanel.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in choicesPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private Text textPrefab = null;
    [SerializeField]
    private UnityEngine.UI.Button buttonPrefab = null;
}
