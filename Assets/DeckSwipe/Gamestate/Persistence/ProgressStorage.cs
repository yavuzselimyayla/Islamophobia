using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace DeckSwipe.Gamestate.Persistence {
	
	public class ProgressStorage {
		
		private static readonly string _gameProgressPath = Application.persistentDataPath + "/progress.json";
		
		private readonly CardStorage cardStorage;
		
		public GameProgress Progress { get; private set; }
		public Task ProgressStorageInit { get; }
		
		public ProgressStorage(CardStorage cardStorage) {
			this.cardStorage = cardStorage;
			ProgressStorageInit = Load();
		}
		
		public void Save() {
			SaveLocally();
		}
		
		private async void SaveLocally() {
			string progressJson = JsonUtility.ToJson(Progress);
			using (FileStream fileStream = File.Create(_gameProgressPath)) {
				StreamWriter writer = new StreamWriter(fileStream);
				await writer.WriteAsync(progressJson);
				await writer.WriteAsync('\n');
				await writer.FlushAsync();
			}
		}
		
		private async Task Load() {
			Progress = await LoadLocally();
			await cardStorage.CardCollectionImport;
			
			if (Progress == null) {
				Progress = new GameProgress();
			}
			Progress.AttachReferences(cardStorage);
			cardStorage.ResolvePrerequisites();
		}
		
		private async Task<GameProgress> LoadLocally() {
			if (File.Exists(_gameProgressPath)) {
				string progressJson;
				using (FileStream fileStream = File.OpenRead(_gameProgressPath)) {
					StreamReader reader = new StreamReader(fileStream);
					progressJson = await reader.ReadToEndAsync();
				}
				return JsonUtility.FromJson<GameProgress>(progressJson);
			}
			return null;
		}
		
	}
	
}
