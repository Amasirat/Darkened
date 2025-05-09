namespace Darkened.Core.Systems;
// The state machine relies on this Mode enum value to keep track of what mode the game is on
// The game can be in many modes, the 4 major game modes are:
// Combat: When the player is currently engaged in combat
// FreeRoam: When the player is free to roam the map
// Novel: When a narrative section of the game is playing out, this narration section is a specific
// mode in which the game loop largely consists of reading narration and making dialogue choices
// Menu: When the game is paused or is displaying a menu scene
public enum GameMode
{
    Combat,
    FreeRoam,
    Credits,
    Menu,
    Novel
}