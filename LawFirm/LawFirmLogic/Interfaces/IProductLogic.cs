using LawFirmLogic.BindingModels;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductBindingModel model);

        void CreateOrUpdate(ProductBindingModel model);

        void Delete(ProductBindingModel model);
    }
}