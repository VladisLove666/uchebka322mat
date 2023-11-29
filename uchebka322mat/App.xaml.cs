using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using uchebka322mat.Components;

namespace uchebka322mat
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static TehnikumshamatEntities2 db = new TehnikumshamatEntities2();
    }
}
