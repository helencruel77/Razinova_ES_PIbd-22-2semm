using LawFirmLogic.BindingModels;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.Interfaces
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);
        void CreateOrUpdate(ImplementerBindingModel model);
        void Delete(ImplementerBindingModel model);
    }
}