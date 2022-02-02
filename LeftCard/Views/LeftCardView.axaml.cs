using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using LeftCard.ViewModels;
using DALI.Enum;
using DALI.Models;
using LeftCard.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeftCard.Views
{
    public class LeftCardView : UserControl
    {
        public LeftCardView()
        {
            InitializeComponent();
        }

       


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
