using PBShared.DataTransferObject.Transaksi.TR_Partais.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBShared.DataTransferObject.Transaksi.TR_Partais
{
    public interface ITR_Partai
    {
        #region Partai
        public List<TRPartai> GetTRPartais();
        public List<TRPartaiDetail> GetTRPartaiDetailsById(int partaiId);
        public List<TRPartaiAdditionalItem> GetTRPartaiAdditionalItemById(int partaiId);
        public List<TRPartaiPemain> GetTRPartaiPemainById(int partaiId);
        #endregion
    }
}
