using System;
using System.Linq;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class BasicInkExample : MonoBehaviour
{
    //public float wisdomBar;
    //public float knowledgeBar;
    //public float empathyBar;
    public static event Action<Story> OnCreateStory;
    public player player;

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


        while (story.canContinue)
        {

            string text = story.Continue();
            text = text.Trim();

 
            CreateContentView(text);
        }


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
            //choice.onClick.AddListener(delegate {
            //    StartStory();
            //});
        }


        float knowledge = story.variablesState.Contains("knowledge") ? Convert.ToSingle(story.variablesState["knowledge"]) : 0;
        float wisdom = story.variablesState.Contains("wisdom") ? Convert.ToSingle(story.variablesState["wisdom"]) : 0;
        float empathy = story.variablesState.Contains("empathy") ? Convert.ToSingle(story.variablesState["empathy"]) : 0;


        Debug.Log("Knowledge: " + knowledge);
        Debug.Log("Wisdom: " + wisdom);
        Debug.Log("Empathy: " + empathy);

        UpdatePointsUI(knowledge, wisdom, empathy);
    }


    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);

        RefreshView();
    }

    void UpdatePointsUI(float knowledge, float wisdom, float empathy)
    {
        Debug.Log("Knowledge: " + knowledge + ", Wisdom: " + wisdom + ", Empathy: " + empathy);
        player.knowledge += knowledge;
        player.wisdom += wisdom;
        player.empathy += empathy;
    }

    void CreateContentView(string text)
    {
        Text storyText = Instantiate(textPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
    }

    UnityEngine.UI.Button CreateChoiceView(string text)
    {
        UnityEngine.UI.Button choice = Instantiate(buttonPrefab) as UnityEngine.UI.Button;
        choice.transform.SetParent(canvas.transform, false);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;

        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story story;

    [SerializeField]
    private Canvas canvas = null;

    [SerializeField]
    private Text textPrefab = null;
    [SerializeField]
    private UnityEngine.UI.Button buttonPrefab = null;
}

public static class PlayerPoints
{
    public static float knowledge;
    public static float wisdom;
    public static float empathy;
}