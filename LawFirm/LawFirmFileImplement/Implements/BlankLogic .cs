using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmFileImplement.Implements
{
    public class BlankLogic : IBlankLogic
    {
        private readonly FileDataListSingleton source;
        public BlankLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(BlankBindingModel model)
        {
            Blank element = source.Blanks.FirstOrDefault(rec => rec.BlankName
           == model.BlankName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть бланк с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Blanks.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Blanks.Count > 0 ? source.Blanks.Max(rec =>
               rec.Id) : 0;
                element = new Blank { Id = maxId + 1 };
                source.Blanks.Add(element);
            }
            element.BlankName = model.BlankName;
        }
        public void Delete(BlankBindingModel model)
        {
            Blank element = source.Blanks.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Blanks.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<BlankViewModel> Read(BlankBindingModel model)
        {
            return source.Blanks
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new BlankViewModel
            {
                Id = rec.Id,
                BlankName = rec.BlankName
            })
            .ToList();
        }
    }
}