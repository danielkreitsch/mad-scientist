using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI content;

    [SerializeField]
    private GameObject continueHint;

    private string finalText;
    private int currentCharIndex = 0;
    private bool typing = true;
    private float typeTimer = 0;
    private float typeDuration = 1;
    
    private float blinkTimer = 0;

    private void Awake()
    {
        this.finalText = this.content.text;
        this.content.text = "";
    }

    void Update()
    {
        if (this.typing)
        {
            this.typeTimer += Time.deltaTime;

            if (this.typeTimer > this.typeDuration)
            {
                this.typeTimer = 0;

                char currentChar = this.finalText[this.currentCharIndex];

                this.content.text = this.finalText.Substring(0, this.currentCharIndex + 1) + "|";
                
                if (currentChar == '.')
                {
                    this.typeDuration = Random.Range(0.40f, 0.80f);
                }
                else  if (currentChar == ',')
                {
                    this.typeDuration = Random.Range(0.20f, 0.40f);
                }
                else  if (currentChar == ' ')
                {
                    this.typeDuration = Random.Range(0.05f, 0.10f);
                }
                else
                {
                    this.typeDuration = Random.Range(0.03f, 0.06f);
                }

                this.currentCharIndex++;
                
                if (this.currentCharIndex >= this.finalText.Length)
                {
                    this.content.text = this.finalText;
                    this.typing = false;
                }
            }
            
            if (Input.anyKeyDown)
            {
                this.content.text = this.finalText;
                this.typing = false;
            }
        }
        else
        {
            this.blinkTimer += Time.deltaTime;

            if (this.blinkTimer > 0.4f)
            {
                this.blinkTimer = 0;
                
                this.continueHint.SetActive(!this.continueHint.activeInHierarchy);
            }

            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
