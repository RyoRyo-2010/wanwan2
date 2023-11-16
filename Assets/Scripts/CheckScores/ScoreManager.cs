using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    public Text ScoreText;

    private ScoresJson Scores;
    // Start is called before the first frame update
    void Start()
    {
        //�Z�[�u�f�[�^���邩�m�F

        if (!File.Exists(FilePath))
        {
			MakeJsonFile();
        }
		//�f�[�^�ǂݍ���
		Scores = ReadJson();
        string scoreText = "";
        //��ʂɕ\��������
        foreach (Score s in Scores.scores)
        {
            scoreText += $"{s.rank}.{s.date} {s.score.ToString("F1")}�b{Environment.NewLine}";
        }
        ScoreText.text = scoreText;

		
		Debug.Log(FilePath);
    }

	public static void MakeJsonFile()
	{
		ScoresJson scoresJson = new ScoresJson();
		scoresJson.scores = new List<Score>();
		
		for (int i = 1; i <= 5; i++)
		{
			scoresJson.scores.Add(new Score { rank = i, score = 0, date = "�f�[�^�Ȃ�" });
		}

		//JSON�֕ϊ�
		string json = JsonConvert.SerializeObject(scoresJson, Formatting.None);
		//��������
		StreamWriter sw = new StreamWriter(FilePath, false, Encoding.UTF8);
		sw.Write(json);
		sw.Flush();
		sw.Close();
	} 
	/// <summary>
	/// �n�C�X�R�A���X�V���܂��B
	/// </summary>
	/// <param name="score">����o���X�R�A</param>
	/// <returns>�X�V�ɐ���������true�A�X�V���Ȃ�������false</returns>
    public static bool UpdateHighScore(float score)
    {
        //�ǂݍ���
        ScoresJson scores = ReadJson();
		//�X�V
		int where = WhereInsert(score, scores);
		if (where == -1)
		{
			return false;
		}
		scores = ArrayShift(where, scores);
		scores.scores[where].score = score;
		scores.scores[where].date = DateTime.Now.ToString("d");
		//JSON�֕ϊ�
		string json = JsonConvert.SerializeObject(scores, Formatting.None);
		//��������
		StreamWriter sw = new StreamWriter(FilePath,false, Encoding.UTF8);
		sw.Write(json);
		sw.Flush();
		sw.Close();
		return true;
    }

	private static int WhereInsert(float input, ScoresJson data)
	{
		//1�ÂA�ǂ��ɓ���邩����
		for (int i = 0; i < data.scores.Count; i++)
		{
			if (data.scores[i].score < input)
			{
				return i;
			}
			if (data.scores[i].score == input)
			{
				return -1;
			}
		}
		return -1;
	}
	private static ScoresJson ArrayShift(int from, ScoresJson data)
	{
		for (int i = data.scores.Count - 1; i > from; i--)
		{
			//data.scores[i] = data.scores[i-1];
			data.scores[i].date = data.scores[i - 1].date;
			data.scores[i].score = data.scores[i - 1].score;
		}

		return data;
	}

	public static ScoresJson ReadJson()
    {
        StreamReader sr = new StreamReader(FilePath, Encoding.UTF8);

        string jsonStr = sr.ReadToEnd();

        sr.Close();
        return JsonConvert.DeserializeObject<ScoresJson>(jsonStr);
    }

    public static string FilePath
    {
        get
        {
            return Path.Combine(Application.persistentDataPath, "Scores.json");
        }
    }
}
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:�����X�^�C��", Justification = "<�ۗ���>")]
public class ScoresJson
{

    public IList<Score> scores
    {
        get; set;
    }
}
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:�����X�^�C��", Justification = "<�ۗ���>")]
public class Score
{
    public int rank
    {
        get; set;
    }
    public string date
    {
        get; set;
    }
    public float score
	{
		get; set;
	}
}