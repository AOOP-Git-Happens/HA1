using AreaControlGame.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AreaControlGame.ViewModels;

public partial class GameViewModel : ObservableObject
{
    [ObservableProperty]
    private string statusText = "";
}