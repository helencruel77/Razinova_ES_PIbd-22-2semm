using LawFirmListImplement.Models;
using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmListImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        private readonly DataListSingleton source;

        public ClientLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client tempBlank = model.Id.HasValue ? null : new Client
            {
                Id = 1
            };
            foreach (var client in source.Clients)
            {
                if (client.ClientFIO == model.ClientFIO && client.Id != model.Id)
                {
                    throw new Exception("Уже есть бланк с таким названием");
                }
                if (!model.Id.HasValue && client.Id >= tempBlank.Id)
                {
                    tempBlank.Id = client.Id + 1;
                }
                else if (model.Id.HasValue && client.Id == model.Id)
                {
                    tempBlank = client;
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
                source.Clients.Add(CreateModel(model, tempBlank));
            }
        }

        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (model != null)
                {
                    if (client.Id == model.Id)
                    {
                        result.Add(CreateViewModel(client));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(client));
            }
            return result;
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            return client;
        }

        private ClientViewModel CreateViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO
            };
        }
    }
}