using Harmony;
using RimWorld;
using RimWorld.Planet;
using System.Reflection;
using UnityEngine;
using Verse;

namespace RenameColony
{
    public class Mod : Verse.Mod
    {
        public Mod(ModContentPack content) : base(content)
        {
            HarmonyInstance rchi = HarmonyInstance.Create("neon.rimworld.renamecolony");
            MethodInfo targetMethoderino = AccessTools.Method(typeof(PlaySettings), "DoPlaySettingsGlobalControls");
            HarmonyMethod postFixerino = new HarmonyMethod(typeof(RenameColony).GetMethod("AddWidget"));
            rchi.Patch(targetMethoderino, null, postFixerino);
            Log.Message("[RenameColony] Postfixed");
        }

        public class RenameColony
        {
            public static void AddWidget(WidgetRow row, bool worldView)
            {
                if (worldView)
                {
                    #if DEBUG
                    Log.Message("femboy foxes are gay");
                    #endif
                    return;
                }
                if (row.ButtonIcon(ContentFinder<Texture2D>.Get("Rename"), "Rename the Colony!"))
                {
                    FactionBase factionBase = (FactionBase)Find.VisibleMap.info.parent;
                    Find.WindowStack.Add(new Dialog_RenameColony(factionBase));
                    #if DEBUG
                    Log.Message("femboy foxes are gay");
                    #endif
                }
            }
        }
    }
}