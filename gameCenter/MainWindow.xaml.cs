﻿using gameCenter.Projects.CurrencyConverter;
using gameCenter.Projects.Project1;
using gameCenter.Projects.TodoList;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace gameCenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image image = (sender as Image)!;
            image.Opacity = 0.7;
            GameText.Content = (image.Name) switch
            {
                "Image1" => "a User Management System",
                "Image2" => "To do list project",
                "Image3" => "Currency convertor",
                "Image4" => "Game No. 4 is a game about lorm ipsum & happy birthday",
                "Image5" => "Game No. 5 is a game about lorm ipsum & happy birthday",
                "Image6" => "Game No. 6 is a game about lorm ipsum & happy birthday",
                _ => "please pick a game"
            };
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Image)!.Opacity = 1;
            GameText.Content = "please pick a game";
        }

        private void Image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Project1 project1 = new();
            Hide();
            project1.ShowDialog();
            Show();
        }
        private void Image2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TodoList todoListProject = new();
            Hide();
            todoListProject.ShowDialog();
            Show();
        }
        private void Image3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CurrencyConvertorView currencyProject = new();
            Hide();
            currencyProject.ShowDialog();
            Show();
        }


    }
}
