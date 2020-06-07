using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawFirmBusinessLogics.BindingModels;
using LawFirmBusinessLogics.Interfaces;
using LawFirmBusinessLogics.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LawFirmRestAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkladController : ControllerBase
    {
        private readonly ISkladLogic skladLogic;
        private readonly IBlankLogic blankLogic;

        public SkladController(ISkladLogic sklad, IBlankLogic blank)
        {
            skladLogic = sklad;
            blankLogic = blank;
        }

        [HttpGet]
        public List<SkladModel> GetSkladsList() => skladLogic.GetList()?.Select(rec => Convert(rec)).ToList();

        [HttpGet]
        public List<BlankViewModel> GetBlanksList() => blankLogic.Read(null)?.ToList();

        [HttpGet]
        public SkladModel GetSklad(int skladId) => Convert(skladLogic.GetElement(skladId));

        [HttpPost]
        public void CreateOrUpdateSklad(SkladBindingModel model)
        {
            if (model.Id.HasValue)
            {
                skladLogic.UpdElement(model);
            }
            else
            {
                skladLogic.AddElement(model);
            }
        }

        [HttpPost]
        public void DeleteSklad(SkladBindingModel model) => skladLogic.DelElement(model);

        [HttpPost]
        public void ReplanishSklad(SkladBlankBindingModel model) => skladLogic.AddComponent(model);

        private SkladModel Convert(SkladViewModel model)
        {
            if (model == null) return null;

            return new SkladModel
            {
                Id = model.Id,
                SkladName = model.SkladName
            };
        }
    }
}