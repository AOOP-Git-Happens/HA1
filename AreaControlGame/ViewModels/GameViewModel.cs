// Idea: is the translator for the overall gameboard and match status. I write in here to connect the game logic to the ui 

using AreaControlGame.Models;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System;

namespace AreaControlGame.ViewModels;

public partial class GameViewModel : ObservableObject
{
    [ObservableProperty]
    private string statusText = "";
}

    