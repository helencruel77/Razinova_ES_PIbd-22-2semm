using LawFirmLogic.BindingModels;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.Interfaces
{
    public interface IBlankLogic
    {
        List<BlankViewModel> Read(BlankBindingModel model);

        void CreateOrUpdate(BlankBindingModel model);

        void Delete(BlankBindingModel model);
    }
}