using LawFirmLogic.BindingModels;
using LawFirmLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmLogic.Interfaces
{
    public interface IMessageInfoLogic
    {
        List<MessageInfoViewModel> Read(MessageInfoBindingModel model);
        void Create(MessageInfoBindingModel model);
    }
}