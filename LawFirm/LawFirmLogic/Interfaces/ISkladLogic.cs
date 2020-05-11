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
        void CreateOrUpdate(SkladBindingModel model);
        void Delete(SkladBindingModel model);
        void FillUpSklad(SkladBlankBindingModel model);
        void DeleteFromSklad(int productId, int count);
        bool CheckAvailable(int productId, int count);
    }
}
