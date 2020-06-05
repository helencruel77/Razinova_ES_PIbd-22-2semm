﻿using LawFirmLogic.BusinessLogics;
using LawFirmLogic.Interfaces;
using LawFirmDataBaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;


namespace LawFirmView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBlankLogic, BlankLogic>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISkladLogic, SkladLogic>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductLogic, ProductLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;

        }
    }
}