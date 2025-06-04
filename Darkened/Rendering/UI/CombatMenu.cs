using Darkened.Core.Systems.Combat;
using Darkened.Data;
using SFML.Graphics;
using SFML.System;

namespace Darkened.Rendering.UI;

// public sealed class CombatMenu : UIMenu
// {
//     // public CombatMenu(RenderWindow window, Tree<string> menuTree) : base(window, menuTree)
//     // {
//     //     ActionHandler.ActionTaken += OnTurnEnded;
//     // }
//
//     // public void TakeStateAndDrawMenu(Tree<string> combatorMenuTree, ICombator combator)
//     // {
//     //     combatorName = combator.Name;
//     //     combatorHealth = combator.Health;
//     //     combatorStamina = combator.Stamina;
//     //     combatorMaxHealth = combator.MaxHealth;
//     //     combatorMaxStamina = combator.MaxStamina;
//     //     
//     //     UpdateItemsTree(combatorMenuTree);
//     //     turnEnded = false;
//     //
//     //     var attackNode = _itemsTree.FindNode(ActionHandler.ToString(ActionHandler.Actions.Attack));
//     //     
//     //     while (window.IsOpen && !turnEnded)
//     //     {
//     //         window.DispatchEvents();
//     //         window.Clear();
//     //         Render();
//     //         // HandleInput();
//     //         window.Display();
//     //     }
//     // }
//
//     // public void Render()
//     // {
//     //     var statText = new Text($"Health: {combatorHealth}/{combatorMaxHealth}", Globals.DefaultFont);
//     //     statText.Position = new Vector2f(200f, 500f);
//     //     window.Draw(statText);
//     //     base.Render();
//     // }
//     public void OnTurnEnded()
//     {
//         turnEnded = true;
//     }
//
//     private string combatorName;
//     private int combatorHealth;
//     private int combatorStamina;
//     private int combatorMaxHealth;
//     private int combatorMaxStamina;
//     private bool turnEnded;
// }