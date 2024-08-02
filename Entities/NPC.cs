namespace Entities;

using RenderLib;

class NPC 
{
    public NPC(string name = "Johnny")
    {
        Name = name;
    }

    public string Name {get; set;}
    public Sprite NPCSprite{get; set;}
    public DialogueDriver dialogue{get; set;}
}