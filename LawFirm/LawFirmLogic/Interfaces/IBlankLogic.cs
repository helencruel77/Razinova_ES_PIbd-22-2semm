
using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogics.Interfaces
{
    public interface IBlankLogic
    {
        List<BlankViewModel> Read(BlankBindingModel model);

        void CreateOrUpdate(BlankBindingModel model);

        void Delete(BlankBindingModel model);
    }
}