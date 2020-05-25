
using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmListImplement.Implements
{
    public class BlankLogic : IBlankLogic
    {
        private readonly DataListSingleton source;
        public BlankLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(BlankBindingModel model)
        {
            Blank tempBlank = model.Id.HasValue ? null : new Blank
            {
                Id = 1
            };
            foreach (var blank in source.Blanks)
            {
                if (blank.BlankName == model.BlankName && blank.Id !=
               model.Id)
                {
                    throw new Exception("Уже есть бланк с таким названием");
                }
                if (!model.Id.HasValue && blank.Id >= tempBlank.Id)
                {
                    tempBlank.Id = blank.Id + 1;
                }
                else if (model.Id.HasValue && blank.Id == model.Id)
                {
                    tempBlank = blank;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempBlank == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempBlank);
            }
            else
            {
                source.Blanks.Add(CreateModel(model, tempBlank));
            }
        }
        public void Delete(BlankBindingModel model)
        {
            for (int i = 0; i < source.Blanks.Count; ++i)
            {
                if (source.Blanks[i].Id == model.Id.Value)
                {
                    source.Blanks.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        public List<BlankViewModel> Read(BlankBindingModel model)
        {
            List<BlankViewModel> result = new List<BlankViewModel>();
            foreach (var blank in source.Blanks)
            {
                if (model != null)
                {
                    if (blank.Id == model.Id)
                    {
                        result.Add(CreateViewModel(blank));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(blank));
            }
            return result;
        }
        private Blank CreateModel(BlankBindingModel model, Blank blank)
        {
            blank.BlankName = model.BlankName;
            return blank;
        }
        private BlankViewModel CreateViewModel(Blank blank)
        {
            return new BlankViewModel
            {
                Id = blank.Id,
                BlankName = blank.BlankName
            };
        }
    }
}