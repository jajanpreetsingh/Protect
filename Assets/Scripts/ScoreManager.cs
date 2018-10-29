using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    private int Score;
    private int HighScore;

    private static int CoinCount;
    private static int TotalCoins;

    public Text ScoreText;
    public Text HighScoreText;
    //public Text CoinsText;

    private void Start()
    {
        Score = 0;

        GameData data = GetGameData();
        HighScore = data != null ? data.HighScore : 0;
        TotalCoins = data != null ? data.CointCount : 0;

        CoinCount = TotalCoins;

        if (HighScoreText != null)
            HighScoreText.text = string.Format("High Score : {0}", HighScore);
    }

    private GameData GetGameData()
    {
        FileStream gameDataFile = null;
        try
        {
            string dataFile = Constants.GameDataFilePath;

            gameDataFile = File.Open(dataFile, FileMode.OpenOrCreate,
                                           FileAccess.Read,
                                           FileShare.None);

            GameData data = new GameData { HighScore = 0 };

            byte[] dataBytes = ObjectToByteArray(data);
            if (gameDataFile == null || new FileInfo(dataFile).Length <= 0) return null;

            gameDataFile.Read(dataBytes, 0, dataBytes.Length);

            data = ByteArrayToGameData(dataBytes);

            return data;
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        finally
        {
            gameDataFile.Close();
            gameDataFile.Dispose();
        }
    }

    public void SaveGameData()
    {
        FileStream gameDataFile = null;
        try
        {
            GameData data = GetGameData();
            if (data == null)
                data = new GameData { HighScore = Score, CointCount = CoinCount };
            else
            {
                data.HighScore = data.HighScore < Score ? Score : data.HighScore;
                data.CointCount = data.CointCount + (CoinCount - TotalCoins);
            }

            string dataFile = Constants.GameDataFilePath;
            gameDataFile = File.Open(dataFile, FileMode.OpenOrCreate,
                                           FileAccess.Write,
                                           FileShare.None);
            if (gameDataFile == null) return;

            byte[] dataBytes = ObjectToByteArray(data);
            gameDataFile.Write(dataBytes, 0, dataBytes.Length);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        finally
        {
            gameDataFile.Close();
            gameDataFile.Dispose();
        }
    }

    private byte[] ObjectToByteArray(GameData obj)
    {
        if (obj == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }

    private GameData ByteArrayToGameData(byte[] bytes)
    {
        if (bytes == null)
            return null;
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(bytes, 0, bytes.Length);
            ms.Seek(0, SeekOrigin.Begin);
            return (GameData)bf.Deserialize(ms);
        }
    }

    public void AddScore(int add)
    {
        Score += add;

        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = string.Format("Score : {0}", Score);
    }
}