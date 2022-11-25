using Microsoft.AspNetCore.Mvc;
using PBShared.DataTransferObject.Transaksi.TR_Partais;
using PBShared.DataTransferObject.Transaksi.TR_Partais.dto;
using PBShared.DBContexts;
using static PBShared.Models.PagingParams;
using PBWebAPI.DataAccess;
using NPOI.SS.Formula.Functions;
using System.Configuration;

namespace PBWebAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly PBManageServiceContext _dbContext;
       
        public TransactionController(ILogger<TransactionController> logger,
            PBManageServiceContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        #region Partai
        [HttpPost]
        [Route("GetPartais")]
        public async Task<GetPartaisResult> GetTRPartais(DynamicCondition input)
        {
            List<TRPartai> res = new List<TRPartai>();

            try
            {
                _logger.LogInformation("GetDataPartai - Start");
                da_Transactions da = new da_Transactions();

                Task<List<TRPartai>?> getData = Task.Factory.StartNew(() => da.GetPartais(input));
                Task<int> getCount = Task.Factory.StartNew(() => da.GetTotalCountPartais(input));

                Task.WaitAll(getData, getCount);

                return new GetPartaisResult
                {
                    TotalCount = await getCount,
                    Models = await getData,
                    errorMessage = null
                };

                _logger.LogInformation("GetDataPartai - End with no error");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPartaiDetailById")]
        public List<TRPartaiDetail> GetTRPartaiDetailsById(int partaiId)
        {
            List<TRPartaiDetail> res = new List<TRPartaiDetail>();
            try
            {
                var getData = (from a in _dbContext.TR_PartaiDetail
                               where a.partaiId == partaiId
                               select a).OrderBy(n => n.partaiId).ThenBy(n => n.timId).ToList();

                foreach (var item in getData)
                {
                    res.Add(new TRPartaiDetail
                    {
                        partaiId = item.partaiId,
                        pemenang = item.pemenang,
                        score = item.score,
                        timId = item.timId
                    });
                }
            }
            catch
            {

                throw;
            }

            return res;
        }

        [HttpGet]
        [Route("GetPartaiAdditionalItemById")]
        public List<TRPartaiAdditionalItem> GetTRPartaiAdditionalItemById(int partaiId)
        {
            List<TRPartaiAdditionalItem> res = new List<TRPartaiAdditionalItem>();
            
            try
            {
                var getData = (from a in _dbContext.TR_PartaiAdditionalItem
                               where a.partaiId == partaiId
                               select a).ToList();

                foreach (var item in getData)
                {
                    res.Add(new TRPartaiAdditionalItem
                    {
                        hargaItem = item.hargaItem,
                        itemId = item.itemId,
                        namaItem = item.namaItem,
                        partaiId = item.partaiId,
                        qty = item.qty,
                        totalHarga = item.totalHarga
                    });
                }
            }
            catch
            {

                throw;
            }

            return res;
        }

        [HttpGet]
        [Route("GetPartaiPemainById")]
        public List<TRPartaiPemain> GetTRPartaiPemainById(int partaiId)
        {
            List<TRPartaiPemain> res = new List<TRPartaiPemain>();

            try
            {
                var getData = (from a in _dbContext.TR_PartaiPemain
                               where a.partaiId == partaiId
                               select a).OrderBy(n => n.partaiId).ThenBy(n => n.timId).ToList();

                foreach (var item in getData)
                {
                    res.Add(new TRPartaiPemain
                    {
                        namaPemain = item.namaPemain,
                        partaiId = item.partaiId,
                        sisaTotalBayar = item.sisaTotalBayar,
                        terbayarPenuh = item.terbayarPenuh,
                        timId = item.timId,
                        totalBayar = item.totalBayar,
                        pemainKe = item.pemainKe
                    });
                }
            }
            catch
            {

                throw;
            }

            return res;
        }
        #endregion
    }
}
