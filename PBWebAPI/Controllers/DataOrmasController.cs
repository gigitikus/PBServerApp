using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBShared.DataTransferObject;
using PBShared.DBContexts;
using PBShared.Models;
using PBWebAPI.Auth;

namespace PBWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataOrmasController : ControllerBase
    {
        private readonly ILogger<DataOrmasController> _logger;
        private PBManageServiceContext _dbContext;

        public DataOrmasController(ILogger<DataOrmasController> logger,
            PBManageServiceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
       
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("CreateDataOrmas")]
        public GeneralReturnValue CreateDataOrmas(DT_Ormas input)
        {
            GeneralReturnValue res = new GeneralReturnValue();

            try
            {

                input.inputTime = DateTime.Now;
                input.modifiedUN = null;
                input.modifiedTime = null;

                _dbContext.DT_Ormas.Add(input);
                _dbContext.SaveChanges();

                var dtOrmas = (from a in _dbContext.DT_Ormas
                                 select a).OrderByDescending(n => n.inputTime).FirstOrDefault();
                
                List<string> data = new List<string>();
                
                if (dtOrmas != null)
                {
                    data.Add(dtOrmas.kodeOrmas);
                    data.Add(dtOrmas.namaOrmas);
                }

                res.status = "success";
                res.message = "Data Ormas berhasil disimpan";
                res.data = data;
            }
            catch (Exception ex)
            {
                res.status = "failed";
                res.message = ex.Message;
                res.data = null;
            }

            return res;
        }

        [HttpGet]
        [Route("GetDataOrmas/{kodeOrmas}")]
        public DT_Ormas GetDataOrmas(string kodeOrmas)
        {
            DT_Ormas res = new DT_Ormas();

            try
            {
                var data = (from a in _dbContext.DT_Ormas
                            where a.kodeOrmas == kodeOrmas
                            select a).FirstOrDefault();

                if(data != null)
                {
                    res = data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return res;
        }

        [HttpPut]
        [Route("UpdateDataOrmas")]
        public GeneralReturnValue UpdateDataOrmas(DT_Ormas input)
        {
            GeneralReturnValue res = new GeneralReturnValue();

            try
            {
                input.modifiedTime = DateTime.Now;

                _dbContext.DT_Ormas.Update(input);
                _dbContext.SaveChanges();

                var dtOrmas = (from a in _dbContext.DT_Ormas
                               select a).OrderByDescending(n => n.modifiedTime).FirstOrDefault();

                List<string> data = new List<string>();

                if (dtOrmas != null)
                {
                    data.Add(dtOrmas.kodeOrmas);
                    data.Add(dtOrmas.namaOrmas);
                }

                res.status = "success";
                res.message = "Data Ormas berhasil diupdate";
                res.data = data;
            }
            catch (Exception ex)
            {
                res.status = "failed";
                res.message = ex.Message;
                res.data = null;
            }

            return res;
        }

        [HttpDelete]
        [Route("DeleteDataOrmas/{kodeOrmas}")]
        public GeneralReturnValue DeleteDataOrmas(string kodeOrmas)
        {
            GeneralReturnValue res = new GeneralReturnValue();

            try
            {
                var data = _dbContext.DT_Ormas.FirstOrDefault(n =>
                n.kodeOrmas == kodeOrmas);

                List<string> datax = new List<string>();

                if (data != null)
                {
                    datax.Add(data.kodeOrmas);
                    datax.Add(data.namaOrmas);

                    _dbContext.DT_Ormas.Remove(data);
                    _dbContext.SaveChanges();
                }

                res.status = "success";
                res.message = "Data Ormas berhasil dihapus";
                res.data = datax;
            }
            catch (Exception ex)
            {
                res.status = "failed";
                res.message = ex.Message;
                res.data = null;
            }

            return res;
        }
    }
}
