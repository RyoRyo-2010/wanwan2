using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Text;
using System;

public class ScoreManager : MonoBehaviour
{
    public TextAsset FirstJson;
    private string filePath;
    [SerializeField]
    public Text ScoreText;

    private ScoresJson Scores;
    // Start is called before the first frame update
    void Start()
    {
        //�Z�[�u�f�[�^���邩�m�F
        filePath = Path.Combine(Application.persistentDataPath, "Scores.json");
        if(!File.Exists(filePath))
        {
            StreamWriter sw = new StreamWriter(filePath,false, Encoding.UTF8);
            sw.Write(FirstJson.text);
            sw.Flush();
            sw.Close();
        }

        //�f�[�^�ǂݍ���
        StreamReader sr = new StreamReader(filePath, Encoding.UTF8);

        string jsonStr = sr.ReadToEnd();

        sr.Close();
        Scores = JsonConvert.DeserializeObject<ScoresJson>(jsonStr);
        string scoreText = "";
        //��ʂɕ\��������
        foreach(Score s in Scores.scores)
        {
            scoreText += $"{s.rank}.{s.date} {s.score}{Environment.NewLine}";
        }
        ScoreText.text = scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:�����X�^�C��", Justification = "<�ۗ���>")]
public class ScoresJson
{
    
    public IList<Score> scores { get; set; }
}
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:�����X�^�C��", Justification = "<�ۗ���>")]
public class Score
{
    public int rank { get; set; }
    public string date { get; set; }
    public int score { get; set; }
}