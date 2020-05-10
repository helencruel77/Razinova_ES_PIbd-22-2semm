using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.ViewModels;
using LawFirmLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogics.Interfaces
{
    public interface ISkladLogic
    {
        List<SkladViewModel> GetList();
        SkladViewModel GetElement(int id);
        void AddElement(SkladBindingModel model);
        void UpdElement(SkladBindingModel model);
        void DelElement(int id);
        void FillSklad(SkladBlankBindingModel model);
    }
}
