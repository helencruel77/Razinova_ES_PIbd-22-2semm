using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmDataBaseImplement;
using LawFirmDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmDataBaseImplement.Implements
{
    public class BlankLogic : IBlankLogic
    {
        public void CreateOrUpdate(BlankBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Blank element = context.Blanks.FirstOrDefault(rec =>
               rec.BlankName == model.BlankName && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть бланк с таким названием");
                }
                if (model.Id.HasValue)
                {
                    element = context.Blanks.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Blank();
                    context.Blanks.Add(element);
                }
                element.BlankName = model.BlankName;
                context.SaveChanges();
            }
        }
        public void Delete(BlankBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Blank element = context.Blanks.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Blanks.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public List<BlankViewModel> Read(BlankBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                return context.Blanks
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
}