using HarmonyLib;
using System.Linq;
using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;


namespace HighwayNameRemover
{
    public class Mod : IMod
    {
        private static readonly ILog log = LogManager.GetLogger($"{nameof(HighwayNameRemover)}").SetShowsErrorsInUI(false);

        private Harmony harmony;

        public void OnLoad(UpdateSystem updateSystem)
        {
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            harmony = new($"{nameof(HighwayNameRemover)}.{nameof(Mod)}");
            harmony.PatchAll(typeof(Mod).Assembly);
            var patchedMethods = harmony.GetPatchedMethods().ToArray();
            log.Info($"Plugin HighwayNameRemover made patches! Patched methods: " + patchedMethods.Length);
            foreach (var patchedMethod in patchedMethods)
            {
                log.Info($"Patched method: {patchedMethod.Module.Name}:{patchedMethod.Name}");
            }

        }

        public void OnDispose()
        {

        }
    }
}