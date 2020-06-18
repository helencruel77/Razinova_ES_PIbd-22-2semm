using LawFirmListImplement.Models;
using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmListImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly DataListSingleton source;

        public ImplementerLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer element = source.Implementers.FirstOrDefault(c => c.ImplementerFIO == model.ImplementerFIO && c.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть исполнитель с таким именем");
            }
            if (model.Id.HasValue)
            {
                element = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    element.ImplementerFIO = model.ImplementerFIO;
                    element.PauseTime = model.PauseTime;
                    element.WorkingTime = model.WorkingTime;
                }
            }
            else
            {
                element = new Implementer
                {
                    ImplementerFIO = model.ImplementerFIO,
                    PauseTime = model.PauseTime,
                    WorkingTime = model.WorkingTime
                };
                source.Implementers.Add(element);
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == model.Id)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();

            foreach (var implementer in source.Implementers)
            {
                if (model != null)
                {
                    if (implementer.Id == model.Id)
                    {
                        result.Add(CreateViewModel(implementer));
                        break;
                    }

                    continue;
                }

                result.Add(CreateViewModel(implementer));
            }

            return result;
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer Implementer)
        {
            Implementer.ImplementerFIO = model.ImplementerFIO;
            Implementer.WorkingTime = model.WorkingTime;
            Implementer.PauseTime = model.PauseTime;
            return Implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer Implementer)
        {
            return new ImplementerViewModel
            {
                Id = Implementer.Id,
                ImplementerFIO = Implementer.ImplementerFIO,
                WorkingTime = Implementer.WorkingTime,
                PauseTime = Implementer.PauseTime
            };
        }
    }
}