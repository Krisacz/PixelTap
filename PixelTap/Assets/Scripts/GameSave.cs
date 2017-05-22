using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GData;
using UnityEngine;

namespace Assets.Scripts
{
    public static class GameSave
    {
        private static GameData _gameData = null;

        public static GameData Get()
        {
            if (_gameData != null) return _gameData;
            Log.Error("GameSave", "Get", "GameData = NULL - needs to be loaded first.");
            return null;
        }

        public static void Load()
        {
            var gameDataString = PlayerPrefs.GetString("GameData", null);
            if (string.IsNullOrEmpty(gameDataString))
            {
                _gameData = new GameData().SetDefaults();
                Update(true);
            }
            else
            {
                _gameData = StringToGameData(gameDataString);
            }
        }

        public static void Update(bool save)
        {
            var gameDataString = GameDataToString(_gameData);
            PlayerPrefs.SetString("GameData", gameDataString);
            if(save) PlayerPrefs.Save();
        }

        public static void Reset()
        {
            _gameData = null;
            PlayerPrefs.DeleteAll();
        }

        #region HELP METHODS
        private static string GameDataToString(GameData gd)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, gd);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private static GameData StringToGameData(string gameDataString)
        {
            var bytes = Convert.FromBase64String(gameDataString);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return (GameData) new BinaryFormatter().Deserialize(ms);
            }
        }
        #endregion
    }
}
