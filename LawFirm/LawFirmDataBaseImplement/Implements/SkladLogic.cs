using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using LawFirmDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmDataBaseImplement.Implements
{
    public class SkladLogic : ISkladLogic
    {
        public List<SkladViewModel> GetList()
        {
            using (var context = new LawFirmDatabase())
            {
                return context.Sklads
                .ToList()
               .Select(rec => new SkladViewModel
               {
                   Id = rec.Id,
                   SkladName = rec.SkladName,
                   SkladBlanks = context.SkladBlanks
               .Include(recWC => recWC.Blank)
               .Where(recWC => recWC.SkladId == rec.Id).
               Select(x => new SkladBlankViewModel
               {
                   Id = x.Id,
                   SkladId = x.SkladId,
                   BlankId = x.BlankId,
                   BlankName = context.Blanks.FirstOrDefault(y => y.Id == x.BlankId).BlankName,
                   Count = x.Count
               })
               .ToList()
               })
            .ToList();
            }
        }
        public SkladViewModel GetElement(int id)
        {
            using (var context = new LawFirmDatabase())
            {
                var elem = context.Sklads.FirstOrDefault(x => x.Id == id);
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
                        SkladBlanks = context.SkladBlanks
                .Include(recWC => recWC.Blank)
               .Where(recWC => recWC.SkladId == elem.Id)
                        .Select(x => new SkladBlankViewModel
                        {
                            Id = x.Id,
                            SkladId = x.SkladId,
                            BlankId = x.BlankId,
                            BlankName = context.Blanks.FirstOrDefault(y => y.Id == x.BlankId).BlankName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }

        public void AddComponent(SkladBlankBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                var item = context.SkladBlanks.FirstOrDefault(x => x.BlankId == model.BlankId
    && x.SkladId == model.SkladId);

                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new SkladBlank();
                    context.SkladBlanks.Add(elem);
                    elem.SkladId = model.SkladId;
                    elem.BlankId = model.BlankId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }
        public void UpdElement(SkladBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                var elem = context.Sklads.FirstOrDefault(x => x.SkladName == model.SkladName && x.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Sklads.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.SkladName = model.SkladName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void AddElement(SkladBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                var elem = context.Sklads.FirstOrDefault(x => x.SkladName == model.SkladName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var sklad = new Sklad();
                context.Sklads.Add(sklad);
                sklad.SkladName = model.SkladName;
                context.SaveChanges();
            }
        }

        public void DelElement(int id)
        {
            using (var context = new LawFirmDatabase())
            {
                var elem = context.Sklads.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Sklads.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void DeleteFromSklad(int productId, int count)
        {
            using (var context = new LawFirmDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var productBlanks = context.ProductBlanks.Where(x => x.ProductId == productId);
                        if (productBlanks.Count() == 0) return;
                        foreach (var elem in productBlanks)
                        {
                            int left = elem.Count * count;
                            var skladblanks = context.SkladBlanks.Where(x => x.BlankId == elem.BlankId);
                            int available = skladblanks.Sum(x => x.Count);
                            if (available < left) throw new Exception("Недостаточно продуктов на складе");
                            foreach (var rec in skladblanks)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0) break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
