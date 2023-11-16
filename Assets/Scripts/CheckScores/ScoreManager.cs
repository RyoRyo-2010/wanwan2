using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextAsset FirstJson;

    [SerializeField]
    public Text ScoreText;

    private ScoresJson Scores;
    // Start is called before the first frame update
    void Start()
    {
        //セーブデータあるか確認

        if (!File.Exists(FilePath))
        {
            StreamWriter sw = new StreamWriter(FilePath, false, Encoding.UTF8);
            sw.Write(FirstJson.text);
            sw.Flush();
            sw.Close();
        }
		//データ読み込み
		Scores = ReadJson();
        string scoreText = "";
        //画面に表示させる
        foreach (Score s in Scores.scores)
        {
            scoreText += $"{s.rank}.{s.date} {s.score / 10.0f}秒{Environment.NewLine}";
        }
        ScoreText.text = scoreText;

		
		Debug.Log(FilePath);
    }

    public static void UpdateHighScore(int score)
    {
        //読み込み
        ScoresJson scores = ReadJson();
		//更新
		scores = UpdateData(scores, score);
		//JSONへ変換
		string json = JsonConvert.SerializeObject(scores, Formatting.Indented);
		//書き込み
		StreamWriter sw = new StreamWriter(FilePath,false, Encoding.UTF8);
		sw.Write(json);
		sw.Flush();
		sw.Close();
    }

	private static ScoresJson UpdateData(ScoresJson data, int input)
	{
		int where = WhereInsert(input, data);
		if (where == -1)
		{
			return data;
		}
		data = ArrayShift(where, data);
		data.scores[where].score = input;
		data.scores[where].date = DateTime.Now.ToString("d");
		return data;
	}
	private static int WhereInsert(int input, ScoresJson data)
	{
		//1つづつ、どこに入れるか検証
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
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "<保留中>")]
public class ScoresJson
{

    public IList<Score> scores
    {
        get; set;
    }
}
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名スタイル", Justification = "<保留中>")]
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
    public long score
    {
        get; set;
    }//10で割ること
}