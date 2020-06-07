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
        public void AddElement(SkladBindingModel model)
        {

            var elem = source.Sklads.FirstOrDefault(x => x.SkladName == model.SkladName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Sklads.Count > 0 ? source.Sklads.Max(rec => rec.Id) : 0;
            source.Sklads.Add(new Sklad
            {
                Id = maxId + 1,
                SkladName = model.SkladName
            });
        }
        public void UpdElement(SkladBindingModel model)
        {
            var elem = source.Sklads.FirstOrDefault(x =>
                x.SkladName == model.SkladName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Sklads.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.SkladName = model.SkladName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(SkladBindingModel model)
        {
            var elem = source.Sklads.FirstOrDefault(x => x.Id == model.Id);
            if (elem != null)
                source.Sklads.Remove(elem);
            else
                throw new Exception("Элемент не найден");
        }
        public void AddComponent(SkladBlankBindingModel model)
        {
            Sklad sklad = source.Sklads.FirstOrDefault(rec => rec.Id == model.SkladId);

            if (sklad == null)
            {
                throw new Exception("Склад не найден");
            }

            Blank blank = source.Blanks.FirstOrDefault(rec => rec.Id == model.BlankId);

            if (blank == null)
            {
                throw new Exception("Компонент не найден");
            }

            SkladBlank element = source.SkladBlanks
                        .FirstOrDefault(rec => rec.SkladId == model.SkladId && rec.BlankId == model.BlankId);

            if (element != null)
            {
                element.Count += model.Count;
                return;
            }

            source.SkladBlanks.Add(new SkladBlank
            {
                Id = source.SkladBlanks.Count > 0 ? source.SkladBlanks.Max(rec => rec.Id) + 1 : 0,
                SkladId = model.SkladId,
                BlankId = model.BlankId,
                Count = model.Count
            });
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