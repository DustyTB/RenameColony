using RimWorld;
using RimWorld.Planet;
using Verse;

namespace RenameColony
{
    class Dialog_RenameColony : Dialog_GiveName
    {
        private FactionBase factionBase;

        public Dialog_RenameColony(FactionBase factionBase)
        {
            this.factionBase = factionBase;
            if (factionBase.HasMap && factionBase.Map.mapPawns.FreeColonistsSpawnedCount != 0)
            {
                Pawn suggestingPawn = factionBase.Map.mapPawns.FreeColonistsSpawned.RandomElement<Pawn>();
            }
            this.curName = Faction.OfPlayer.Name;
            this.nameMessageKey = "RCNamePlayerFactionMessage";
            this.invalidNameMessageKey = "PlayerFactionNameIsInvalid";
            this.useSecondName = true;
            this.curSecondName = factionBase.Name;
            this.secondNameMessageKey = "RCNamePlayerFactionBaseMessage_NameFactionContinuation";
            this.invalidSecondNameMessageKey = "RCPlayerFactionBaseNameIsInvalid";
            this.gainedNameMessageKey = "RCPlayerFactionAndBaseGainsName";
        }

        public override void PostOpen()
        {
            base.PostOpen();
            if (this.factionBase.Map != null)
            {
                Current.Game.VisibleMap = this.factionBase.Map;
            }
        }

        protected override bool IsValidName(string s)
        {
            return NamePlayerFactionDialogUtility.IsValidName(s);
        }

        protected override bool IsValidSecondName(string s)
        {
            return NamePlayerFactionBaseDialogUtility.IsValidName(s);
        }

        protected override void Named(string s)
        {
            NamePlayerFactionDialogUtility.Named(s);
        }

        protected override void NamedSecond(string s)
        {
            NamePlayerFactionBaseDialogUtility.Named(this.factionBase, s);
        }
    }
}
