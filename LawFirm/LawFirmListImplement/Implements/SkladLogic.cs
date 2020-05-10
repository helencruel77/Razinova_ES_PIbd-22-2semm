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

        public void CreateOrUpdate(SkladBindingModel sklad)
        {
            Sklad tempSklad = sklad.Id.HasValue ? null : new Sklad
            {
                Id = 1
            };
            foreach (var s in source.Sklads)
            {
                if (s.SkladName == sklad.SkladName && s.Id != sklad.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                if (!sklad.Id.HasValue && s.Id >= tempSklad.Id)
                {
                    tempSklad.Id = s.Id + 1;
                }
                else if (sklad.Id.HasValue && s.Id == sklad.Id)
                {
                    tempSklad = s;
                }
            }
            if (sklad.Id.HasValue)
            {
                if (tempSklad == null)
                {
                    throw new Exception("Элемент не найден");
                }
                tempSklad.SkladName = sklad.SkladName;
            }
            else
            {
                source.Sklads.Add(new Sklad()
                {
                    Id = tempSklad.Id,
                    SkladName = sklad.SkladName
                }
                );
            }
        }

        public void Delete(SkladBindingModel model)
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

        public List<SkladViewModel> GetList()
        {
            List<SkladViewModel> result = new List<SkladViewModel>();
            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                List<SkladBlankViewModel> SkladBlanks = new
    List<SkladBlankViewModel>();
                for (int j = 0; j < source.SkladBlanks.Count; ++j)
                {
                    if (source.SkladBlanks[j].SkladId == source.Sklads[i].Id)
                    {
                        string BlankName = string.Empty;
                        for (int k = 0; k < source.Blanks.Count; ++k)
                        {
                            if (source.SkladBlanks[j].BlankId ==
                           source.Blanks[k].Id)
                            {
                                BlankName = source.Blanks[k].BlankName;
                                break;
                            }
                        }
                        SkladBlanks.Add(new SkladBlankViewModel
                        {
                            Id = source.SkladBlanks[j].Id,
                            SkladId = source.SkladBlanks[j].SkladId,
                            BlankId = source.SkladBlanks[j].BlankId,
                            BlankName = BlankName,
                            Count = source.SkladBlanks[j].Count
                        });
                    }
                }
                result.Add(new SkladViewModel
                {
                    Id = source.Sklads[i].Id,
                    SkladName = source.Sklads[i].SkladName,
                    SkladBlanks = SkladBlanks
                });
            }
            return result;
        }
        public SkladViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Sklads.Count; ++i)
            {
                List<SkladBlankViewModel> SkladBlanks = new
    List<SkladBlankViewModel>();
                for (int j = 0; j < source.SkladBlanks.Count; ++j)
                {
                    if (source.SkladBlanks[j].SkladId == source.Sklads[i].Id)
                    {
                        string BlankName = string.Empty;
                        for (int k = 0; k < source.Blanks.Count; ++k)
                        {
                            if (source.SkladBlanks[j].BlankId ==
                           source.Blanks[k].Id)
                            {
                                BlankName = source.Blanks[k].BlankName;
                                break;
                            }
                        }
                        SkladBlanks.Add(new SkladBlankViewModel
                        {
                            Id = source.SkladBlanks[j].Id,
                            SkladId = source.SkladBlanks[j].SkladId,
                            BlankId = source.SkladBlanks[j].BlankId,
                            BlankName = BlankName,
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
                        SkladBlanks = SkladBlanks
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void FillUpSklad(SkladBlankBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.SkladBlanks.Count; ++i)
            {
                if (source.SkladBlanks[i].BlankId == model.BlankId
                    && source.SkladBlanks[i].SkladId == model.SkladId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.SkladBlanks[foundItemIndex].Count =
                    source.SkladBlanks[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.SkladBlanks.Count; ++i)
                {
                    if (source.SkladBlanks[i].Id > maxId)
                    {
                        maxId = source.SkladBlanks[i].Id;
                    }
                }
                source.SkladBlanks.Add(new SkladBlank
                {
                    Id = maxId + 1,
                    SkladId = model.SkladId,
                    BlankId = model.BlankId,
                    Count = model.Count
                });
            }
        }
    }
}
