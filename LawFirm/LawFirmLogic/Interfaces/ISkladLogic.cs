using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.ViewModels;
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

        void AddComponent(SkladBlankBindingModel model);
        void DeleteFromSklad(int ProductId, int ProductsCount);
    }
}
