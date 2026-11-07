using BepInEx;
using CharmCore.Api;
using UnityEngine;

namespace CharmGoldenCoin
{
	[BepInPlugin(PluginGuid, PluginName, PluginVersion)]
	[BepInDependency("com.osmar.Pockets", BepInDependency.DependencyFlags.HardDependency)]
	[BepInDependency("com.osmar.CharmCore", BepInDependency.DependencyFlags.HardDependency)]
	public class CharmGoldenCoinPlugin : BaseUnityPlugin
	{
		public const string PluginGuid = "com.osmar.CharmGoldenCoin";
		public const string PluginName = "CharmGoldenCoin";
		public const string PluginVersion = "1.0.0";

		internal static new BepInEx.Logging.ManualLogSource Logger { get; private set; } = null!;

		private void Awake()
		{
			Logger = base.Logger;

			// Prevent the plugin from being deleted
			this.gameObject.transform.parent = null;
			this.gameObject.hideFlags = HideFlags.HideAndDontSave;

			// Registering binds Enabled, WearPercent and the Debug section (DebugMode) in this mod's config file.
			GoldenCoinCharm charm = new GoldenCoinCharm();
			CharmsApi.Register(charm, Config);
			HeadsOrTails.Register(charm);

			Logger.LogInfo($"{PluginName} {PluginVersion} loaded!");
		}
	}
}
