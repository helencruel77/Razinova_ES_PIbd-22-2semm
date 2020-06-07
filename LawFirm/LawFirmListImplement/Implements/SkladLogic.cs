using LawFirmListImplement.Models;
using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LawFirmListImplement.Implements
{
    public class SkladLogic : ISkladLogic
    {
        private readonly DataListSingleton source;

        public SkladLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<SkladViewModel> GetList()
        {
            List<SkladViewModel> result = new List<SkladViewModel>();

            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                List<SkladBlankViewModel> skladBlanks = new List<SkladBlankViewModel>();

                for (int j = 0; j < source.SkladBlanks.Count; ++j)
                {
                    if (source.SkladBlanks[j].SkladId == source.Sklads[i].Id)
                    {
                        string blankName = string.Empty;

                        for (int k = 0; k < source.Blanks.Count; ++k)
                        {
                            if (source.SkladBlanks[j].BlankId == source.Blanks[k].Id)
                            {
                                blankName = source.Blanks[k].BlankName;
                                break;
                            }
                        }
                        skladBlanks.Add(new SkladBlankViewModel
                        {
                            Id = source.SkladBlanks[j].Id,
                            SkladId = source.SkladBlanks[j].SkladId,
                            BlankId = source.SkladBlanks[j].BlankId,
                            BlankName = blankName,
                            Count = source.SkladBlanks[j].Count
                        });
                    }
                }

                result.Add(new SkladViewModel
                {
                    Id = source.Sklads[i].Id,
                    SkladName = source.Sklads[i].SkladName,
                    SkladBlanks = skladBlanks
                });
            }
            return result;
        }

        public SkladViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                List<SkladBlankViewModel> skladBlanks = new List<SkladBlankViewModel>();

                for (int j = 0; j < source.SkladBlanks.Count; ++j)
                {
                    if (source.SkladBlanks[j].SkladId == source.Sklads[i].Id)
                    {
                        string blankName = string.Empty;

                        for (int k = 0; k < source.Blanks.Count; ++k)
                        {
                            if (source.SkladBlanks[j].BlankId == source.Blanks[k].Id)
                            {
                                blankName = source.Blanks[k].BlankName;
                                break;
                            }
                        }

                        skladBlanks.Add(new SkladBlankViewModel
                        {
                            Id = source.SkladBlanks[j].Id,
                            SkladId = source.SkladBlanks[j].SkladId,
                            BlankId = source.SkladBlanks[j].BlankId,
                            BlankName = blankName,
                            Count = source.SkladBlanks[j].Count
                        });
                    }
                }

                if (source.Sklads[i].Id == id)
                {
                    return new SkladViewModel
                    {
                        Id = source.Sklads[i].Id,
                        SkladName = source.Sklads[i].SkladName,
                        SkladBlanks = skladBlanks
                    };
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddElement(SkladBindingModel model)
        {
            int maxId = 0;

            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                if (source.Sklads[i].Id > maxId)
                {
                    maxId = source.Sklads[i].Id;
                }

                if (source.Sklads[i].SkladName == model.SkladName)
                {
                    throw new Exception("Склад с таким названием уже существует");
                }
            }
            source.Sklads.Add(new Sklad
            {
                Id = maxId + 1,
                SkladName = model.SkladName
            });
        }

        public void UpdElement(SkladBindingModel model)
        {
            int index = -1;

            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                if (source.Sklads[i].Id == model.Id)
                {
                    index = i;
                }

                if (source.Sklads[i].SkladName == model.SkladName && source.Sklads[i].Id != model.Id)
                {
                    throw new Exception("Склад с таким названием уже существует");
                }
            }

            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }

            source.Sklads[index].SkladName = model.SkladName;
        }

        public void DelElement(SkladBindingModel model)
        {
            for (int i = 0; i < source.SkladBlanks.Count; ++i)
            {
                if (source.SkladBlanks[i].SkladId == model.Id)
                {
                    source.SkladBlanks.RemoveAt(i--);
                }
            }

            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                if (source.Sklads[i].Id == model.Id)
                {
                    source.Sklads.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public void AddComponent(SkladBlankBindingModel model)
        {
            for (int i = 0; i < source.SkladBlanks.Count; ++i)
            {
                if (source.SkladBlanks[i].SkladId == model.SkladId &&
                    source.SkladBlanks[i].BlankId == model.BlankId)
                {
                    source.SkladBlanks[i].Count += model.Count;
                    return;
                }
            }

            int maxWCId = 0;

            for (int i = 0; i < source.SkladBlanks.Count; ++i)
            {
                if (source.SkladBlanks[i].Id > maxWCId)
                {
                    maxWCId = source.SkladBlanks[i].Id;
                }
            }

            source.SkladBlanks.Add(new SkladBlank
            {
                Id = ++maxWCId,
                SkladId = model.SkladId,
                BlankId = model.BlankId,
                Count = model.Count
            });

        }
        public bool CheckAvailable(int ProductId, int ProductsCount)
        {
            bool result = true;
            var productBlanks = source.ProductBlanks.Where(x => x.ProductId == ProductId);
            if (productBlanks.Count() == 0) return false;
            foreach (var elem in productBlanks)
            {
                int count = 0;
                count = source.SkladBlanks.FindAll(x => x.BlankId == elem.BlankId).Sum(x => x.Count);
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
                var skladBlanks = source.ProductBlanks.FindAll(x => x.BlankId == elem.BlankId);
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