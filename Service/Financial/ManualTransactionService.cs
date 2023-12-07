using AutoMapper;
using Domain.Entities;
using Domain.Entities.Financial;
using Domain.Enum;
using Domain.Interface.Repository;
using Domain.Interface.Repository.Auth;
using Domain.Interface.Repository.Common;
using Domain.Interface.Repository.Financial;
using Domain.Interface.Service.Financial;
using Domain.Model.Financial;
using Service.Common;
using Util.Helpers;

namespace Service.Financial
{
    public class ManualTransactionService : BaseService<ManualTransactionEntity, ManualTransactionRequest, ManualTransactionResponse>, IManualTransactionService
    {
        private readonly IFinancialReleaseService _releaseService;
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IWalletRepository _walletRepository;
        public ManualTransactionService(IManualTransactionRepository repository, IUserRepository userRepository, IContactRepository contactRepository, IWalletRepository walletRepository, IFinancialReleaseService financialReleaseService, IMapper mapper, IUnitOfWork uow) : base(repository, mapper, uow)
        {
            _releaseService = financialReleaseService;
            _userRepository = userRepository;
            _walletRepository = walletRepository;
            _contactRepository = contactRepository;
        }

        public override async Task<ManualTransactionResponse> Create(ManualTransactionRequest request)
        {
            try
            {
                var users = await _userRepository.Get();
                var user = users.Where(x => x.Email == "admin@teste.com").FirstOrDefault();

                var wallets = await _walletRepository.Get();
                var wallet = wallets.Where(x => x.Name.Equals("Conta Padrão")).FirstOrDefault();

                var contact =  request.ContactUuid != null ? await _contactRepository.Get(request.ContactUuid.Value) : new ContactEntity();



                var manualTransaction = new ManualTransactionEntity()
                {
                    Title = request.Title,
                    Description = request.Description,
                    Value = request.Value,
                    Flow = request.Flow,
                    DueDate = DateTime.Now,
                    Status = request.Status,
                    ContactId = contact.Id,
                    Contact = contact,
                    UserId = user.Id,
                    User = user,
                    WalletId = wallet.Id,
                    Wallet = wallet,
                };


                await _repository.Create(manualTransaction);

                var releaseDetails = new FinancialReleaseDetails()
                {
                    Title = EnumHelper.GetDescription(EFinancialReleaseType.MANUAL),
                    Contact = manualTransaction.Contact,
                    Flow = manualTransaction.Flow,
                    TransactionCode = (int)manualTransaction.Id,
                    Type = EFinancialReleaseType.MANUAL,
                    Value = manualTransaction.Value,
                    Status = manualTransaction.Status,
                    Wallet = manualTransaction.Wallet,
                }; 



                await _releaseService.FinancialProcessor(releaseDetails, user);
                _uow.Commit();
                return _mapper.Map<ManualTransactionResponse>(request);
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                return null;
            }
        }
    }
}
