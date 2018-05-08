namespace SourceGSI.UI.Core.Entities.Lookup
{
    public enum GameState
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,

        /// <summary>
        /// Disconnected
        /// </summary>
        DOTA_GAMERULES_STATE_DISCONNECT,

        /// <summary>
        /// Game is in progress
        /// </summary>
        DOTA_GAMERULES_STATE_GAME_IN_PROGRESS,

        /// <summary>
        /// Players are currently selecting heroes
        /// </summary>
        DOTA_GAMERULES_STATE_HERO_SELECTION,

        /// <summary>
        /// Game is starting
        /// </summary>
        DOTA_GAMERULES_STATE_INIT,

        /// <summary>
        /// Game is ending
        /// </summary>
        DOTA_GAMERULES_STATE_LAST,

        /// <summary>
        /// Game has ended, post game scoreboard
        /// </summary>
        DOTA_GAMERULES_STATE_POST_GAME,

        /// <summary>
        /// Game has started, pre game preparations
        /// </summary>
        DOTA_GAMERULES_STATE_PRE_GAME,

        /// <summary>
        /// Players are selecting/banning heroes
        /// </summary>
        DOTA_GAMERULES_STATE_STRATEGY_TIME,

        /// <summary>
        /// Waiting for everyone to connect and load
        /// </summary>
        DOTA_GAMERULES_STATE_WAIT_FOR_PLAYERS_TO_LOAD,

        /// <summary>
        /// Game is a custom game
        /// </summary>
        DOTA_GAMERULES_STATE_CUSTOM_GAME_SETUP
    }
}
