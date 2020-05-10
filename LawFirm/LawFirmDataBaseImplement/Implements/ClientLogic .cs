using LawFirmDataBaseImplement.Models;
using LawFirmLogic.BindingModels;
using LawFirmLogic.Interfaces;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LawFirmDataBaseImplement.Implements
{
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Client client;
                if (model.Id.HasValue)
                {
                    client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (client == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    client = new Client();
                    context.Clients.Add(client);
                }
                client.ClientFIO = model.ClientFIO;
                client.Email = model.Email;
                client.Password = model.Password;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new LawFirmDatabase())
            {

                List<ClientViewModel> clients = context.Clients.Where(
                         rec => model == null
                      || rec.Id == model.Id
                      || rec.Id == model.Id
                       || rec.Email == model.Email && rec.Password == model.Password
                    ).Select(rec => new ClientViewModel
                    {
                        Id = rec.Id,
                        ClientFIO = rec.ClientFIO,
                        Email = rec.Email,
                        Password = rec.Password
                    })
                    .ToList();
                if (clients.Count > 0)
                    return clients;
                return null;
            }
        }
    }
}