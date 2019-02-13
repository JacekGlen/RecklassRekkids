using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RR.GRM.Core.Repositories;

namespace RR.GRM.Core
{
    public class PartnerAssetProvider : IPartnerAssetProvider
    {
        private readonly IMusicContractRepository _musicContractRepository;
        private readonly IPartnerRepository _partnerRepository;

        public PartnerAssetProvider(IMusicContractRepository musicContractRepository, IPartnerRepository partnerRepository)
        {
            _musicContractRepository = musicContractRepository;
            _partnerRepository = partnerRepository;
        }

        public IList<MusicContract> Get(string partnerName, DateTime effectiveDate)
        {
            var partner = _partnerRepository.GetAll().FirstOrDefault(p => p.Name == partnerName);

            if (partner == null)
            {
                return  new List<MusicContract>();
            }

            var partnerContracts = _musicContractRepository
                .GetAll()
                .Where(mc => mc.DistributionChannels.Any(dc => partner.SupportedDistributionChannels.Contains(dc)))
                .Where(mc => !mc.StartDate.HasValue || mc.StartDate.Value <= effectiveDate)
                .Where(mc => !mc.EndDate.HasValue || mc.EndDate.Value >= effectiveDate)
                .ToList();

            foreach (var partnerContract in partnerContracts)
            {
                partnerContract.DistributionChannels = partnerContract.DistributionChannels.Where(dc => partner.SupportedDistributionChannels.Contains(dc)).ToList();
            }

            return partnerContracts;
        }
    }
}
