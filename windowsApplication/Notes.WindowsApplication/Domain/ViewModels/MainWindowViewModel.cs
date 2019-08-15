using MaterialDesignThemes.Wpf;
using Notes.UI.Controls.Views;
using Notes.UI.Domain.Enums;
using Notes.UI.Domain.Infrastructure;
using Notes.UI.Domain.Models;
using System;
using System.Configuration;

namespace Notes.UI.Domain.ViewModels.Main
{
    public class MainWindowViewModel
    {
        public IMenuItemModel[] MainMenuItems { get; set; }

        public MainWindowViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));

            MainMenuItems = new IMenuItemModel[]
            {
                new MainMenuItemModel<HomeView>("Dashboard", null, null),
                new MainMenuItemModel<NotesView>("My Notes", new NotesViewModel(), null),
                new MainMenuItemModel<PaletteView>("Palette", new PaletteSelectorViewModel(), null)
            };
        }
    }
}
