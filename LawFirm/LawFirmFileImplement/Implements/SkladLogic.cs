using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.ViewModels;
using LawFirmBusinessLogics.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using LawFirmFileImplement.Models;
using System.Linq;

namespace LawFirmFileImplement.Implements
{
    public class SkladLogic : ISkladLogic
    {
        private readonly FileDataListSingleton source;

        public SkladLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(SkladBindingModel model)
        {
            Sklad element = source.Sklads.FirstOrDefault(s => s.SkladName == model.SkladName && s.Id != model.Id);
            if (element != null)
                throw new Exception("Уже есть бланк с таким названием");
            if (model.Id.HasValue)
            {
                element = source.Sklads.FirstOrDefault(s => s.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Sklads.Count > 0 ? source.Sklads.Max(s => s.Id) : 0;
                element = new Sklad { Id = maxId + 1 };
                source.Sklads.Add(element);
            }
            element.SkladName = model.SkladName;
        }

        public void Delete(SkladBindingModel model)
        {
            Sklad sklad = source.Sklads.FirstOrDefault(s => s.Id == model.Id);
            if (sklad != null)
                source.Sklads.Remove(sklad);
            else
                throw new Exception("Склад не найдено");
        }

        public List<SkladViewModel> GetList()
        {
            return source.Sklads.Select(rec => new SkladViewModel
            {
                Id = rec.Id,
                SkladName = rec.SkladName,
                SkladBlanks = source.SkladBlanks.Where(z => z.SkladId == rec.Id)
                .Select(x => new SkladBlankViewModel
                {
                    Id = x.Id,
                    SkladId = x.SkladId,
                    BlankId = x.BlankId,
                    BlankName = source.Blanks.FirstOrDefault(y => y.Id == x.BlankId)?.BlankName,
                    Count = x.Count
                }).ToList()
            }).ToList();
        }
        public SkladViewModel GetElement(int id)
        {
            var elem = source.Sklads.FirstOrDefault(x => x.Id == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            else
            {
                return new SkladViewModel
                {
                    Id = id,
                    SkladName = elem.SkladName,
                    SkladBlanks = source.SkladBlanks.Where(z => z.SkladId == elem.Id)
                    .Select(x => new SkladBlankViewModel
                    {
                        Id = x.Id,
                        SkladId = x.SkladId,
                        BlankId = x.BlankId,
                        BlankName = source.Blanks.FirstOrDefault(y => y.Id == x.BlankId)?.BlankName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }

        public void FillUpSklad(SkladBlankBindingModel model)
        {
            if (source.SkladBlanks.Count == 0)
            {
                source.SkladBlanks.Add(new SkladBlank()
                {
                    Id = 1,
                    BlankId = model.BlankId,
                    SkladId = model.SkladId,
                    Count = model.Count
                });
            }
            else
            {
                var blank = source.SkladBlanks.FirstOrDefault(sm => sm.SkladId == model.SkladId && sm.BlankId == model.BlankId);
                if (blank == null)
                {
                    source.SkladBlanks.Add(new SkladBlank()
                    {
                        Id = source.SkladBlanks.Max(sm => sm.Id) + 1,
                        BlankId = model.BlankId,
                        SkladId = model.SkladId,
                        Count = model.Count
                    });
                }
                else
                    blank.Count += model.Count;
            }
        }

        public bool CheckAvailable(int ProductId, int ProductsCount)
        {
            bool result = true;
            var productBlanks = source.ProductBlanks
            .Where(x => x.ProductId == ProductId);
            if (productBlanks.Count() == 0)
                return false;
            foreach (var elem in productBlanks)
            {
                int count = 0;
                var skladBlanks = source.SkladBlanks.FindAll(x => x.BlankId == elem.BlankId);
                count = skladBlanks.Sum(x => x.Count);
                if (count < elem.Count * ProductsCount)
                    return false;
            }
            return result;
        }

        public void DeleteFromSklad(int ProductId, int ProductsCount)
        {
            var productBlanks = source.ProductBlanks.Where(x => x.ProductId == ProductId);
            if (productBlanks.Count() == 0) return;
            foreach (var elem in productBlanks)
            {
                int left = elem.Count * ProductsCount;
                var skladBlanks = source.SkladBlanks.FindAll(x => x.BlankId == elem.BlankId);
                foreach (var rec in skladBlanks)
                {
                    int toRemove = left > rec.Count ? rec.Count : left;
                    rec.Count -= toRemove;
                    left -= toRemove;
                    if (left == 0) break;
                }
            }
            return;
        }
    }
}